using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using PictureTagger_System;

namespace PictureTagger_UI
{
	public partial class PTMain : Form
	{
		//Data
		private PTData ptData;

		//UI
		private PTOptions optionsForm = null;

		public PTMain()
		{
			InitializeComponent();
			optionsForm = new PTOptions();
			txtSearch.KeyUp += (s, e) =>
			{
				if (e.KeyCode == Keys.Enter)
				{
					Search(txtSearch.Text);
				}
			};
		}

		private void refreshPictures()
		{
			pictureLayout.Controls.Clear();
			foreach (var picture in ptData.Pictures())
			{
				setupImage(picture);
			}
		}

		/// <summary>
		/// Repopulates the main view with pictures matching a comma|string-separated search value
		/// </summary>
		/// <param name="value">comma and space-separated string to search for tags</param>
		private void Search(string value)
		{
			// Empty searches reset and display all pictures
			if (value.Length == 0)
			{
				pictureLayout.Controls.Clear();
				foreach (var pic in ptData.Pictures())
				{
					setupImage(pic);
				}
				return;
			}

			// List to keep track of search result matches
			var matches = new List<SearchMatch>();

			// Get each normalized tag from the search string
			var tags = value
				.Split(new[] { ',', ' ' })
				.Select(tag => tag.NormalizeKeyword())
				.Where(tag => tag.Length > 0);

			// For every tag, find matching pictures and add their scores to the results list
			foreach (var tag in tags)
			{
				// Match this tag
				var tagMatches = from pic in ptData.Pictures()
								 where pic.Tags.Select(t => t.Tag).Contains(tag)
								 select pic;

				// For every picture that matches this tag, check if it already exists in the results list
				// If it does exist, increment it's "score" so more relevant pictures appear first
				foreach (var match in tagMatches)
				{
					var existing = matches.FirstOrDefault(sm => sm.Picture.PictureID == match.PictureID);

					if (existing == null)
					{
						matches.Add(new SearchMatch(match));
					}
					else
					{
						existing.Score++;
					}
				}
			}

			pictureLayout.Controls.Clear();

			// Display each picture in the results, ordered by how well they matched the search query
			foreach (var match in matches.OrderByDescending(match => match.Score))
			{
				setupImage(match.Picture);
			}
		}

		private void PTMain_Load(object sender, EventArgs e)
		{
			ptData = new PTData();

			refreshPictures();
		}

		private void PTMain_Closing(object sender, FormClosingEventArgs e)
		{
			ptData.Save();
		}

		/// <summary>
		/// Adds a picture to the form to be displayed on the grid
		/// </summary>
		/// <param name="picture">Picture to add</param>
		private void setupImage(PTPicture picture)
		{
			PTPictureBox picturebox = new PTPictureBox(picture); //Encapsulate PTPicture in PictureBox
			pictureLayout.Controls.Add(picturebox); //Add to UI

			ContextMenuStrip pictureboxContextMenuStrip = new ContextMenuStrip(); //Create Context Menu Strip (Right Click Menu)

			ToolStripMenuItem deletePictureBoxMenuItem = new ToolStripMenuItem("Delete"); //Create Tool Strip Menu Item (Delete)
			deletePictureBoxMenuItem.Tag = picturebox; //Encapsulate PTPicture in Tool Strip Menu Item
			deletePictureBoxMenuItem.Click += DeletePictureBoxMenuItem_Click; //Hook Delete Click Event

			ToolStripMenuItem tagPictureBoxMenuItem = new ToolStripMenuItem("Tag"); //Create Tool Strip Menu Item (Delete)
			tagPictureBoxMenuItem.Tag = picturebox; //Encapsulate PTPicture in Tool Strip Menu Item
			tagPictureBoxMenuItem.Click += TagPictureBoxMenuItem_Click; //Hook Delete Click Event

			pictureboxContextMenuStrip.Items.Add(deletePictureBoxMenuItem); //Add Delete Tool Strip Menu Item to Context Menu Strip
			pictureboxContextMenuStrip.Items.Add(tagPictureBoxMenuItem); //Add Tag Tool Strip Menu Item to Context Menu Strip
			picturebox.ContextMenuStrip = pictureboxContextMenuStrip; //Assign Context Menu Strip to PictureBox
		}

		private void exitPTMainStripItem_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Exit confirmation", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.OK)
			{
				Application.Exit();
			}
		}

		private void importPTMainStripItem_Click(object sender, EventArgs e)
		{
			openFileDialogImageImport.ShowDialog(this); //Display Open Dialog for Importing Image
		}

		private void optionsPTMainStripItem_Click(object sender, EventArgs e)
		{
			optionsForm.ShowDialog(this); //Options Form for any Customizing
		}

		private void openFileDialogImageImport_FileOk(object sender, CancelEventArgs e)
		{
			var dialog = ((OpenFileDialog)sender);
			foreach (var file in dialog.FileNames)
			{
				if (!File.Exists(file))
				{
					MessageBox.Show("File Doesn't Exist!", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					continue;
				}

				var fileName = Path.GetFileName(file);
				var oldDir = Path.GetDirectoryName(file);
				var newDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PictureTagger\";

				Directory.CreateDirectory(newDir);

				var oldFile = file;
				var newFile = newDir + fileName;

				PTPicture p = ptData.Pictures().FirstOrDefault(pic => pic.Path == newFile);

				if (p != null && File.Exists(newFile))
				{
					MessageBox.Show("File Already Exists", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					continue;
				}

				if (!File.Exists(newFile))
					File.Copy(oldFile, newFile);

				PTPicture picture = new PTPicture()
				{
					Path = newFile,
					PrimaryColour = ColorTranslator.ToHtml(PictureAnalyzer.GetDominantColour(newFile))
				};

				ptData.Insert(picture);
			}

			// Make sure to save the database file, otherwise additions only exist in memory
			ptData.Save();

			refreshPictures();
		}

		private void DeletePictureBoxMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem deletePictureBox = (ToolStripMenuItem)sender;
			PTPictureBox picturebox = (PTPictureBox)deletePictureBox.Tag;
			pictureLayout.Controls.Remove(picturebox); //Remove from UI

			if (File.Exists(picturebox.Picture.Path))
			{
				File.Delete(picturebox.Picture.Path); //Remove from File System
			}

			ptData.Delete(picturebox.Picture); //Remove from DB
			ptData.Save();

			refreshPictures();
		}

		public void TagPictureBoxMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem deletePictureBox = (ToolStripMenuItem)sender;
			PTPictureBox picturebox = (PTPictureBox)deletePictureBox.Tag;

			PTTag tagForm = new PTTag(picturebox.Picture, ptData);
			tagForm.ShowDialog(this);
		}
	}

	class SearchMatch
	{
		internal PTPicture Picture { get; set; }
		internal uint Score = 0;

		public SearchMatch(PTPicture pic)
		{
			Picture = pic;
		}
	}
}
