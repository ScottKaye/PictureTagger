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

        }

		private void PTMain_Load(object sender, EventArgs e)
		{
			ptData = new PTData();

			List<PTPicture> pictures = ptData.Select();
			foreach (var picture in pictures)
			{
				setupImage(picture);
			}

		}

		private void PTMain_Closing(object sender, FormClosingEventArgs e)
		{
			ptData.Dispose();
		}

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
            if(MessageBox.Show(this, "Exit confirmation", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2 ) == DialogResult.OK)
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

				var oldFile = file;
				var newFile = newDir + fileName;

				PTPicture p = ptData.Select(newFile);

				if (p != null && File.Exists(newFile))
				{
					MessageBox.Show("File Already Exists", "Invalid File", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
					continue;
				}

				if (!File.Exists(newFile))
					File.Copy(oldFile, newFile);

				PTPicture picture = null;
				ptData.Insert(newFile, "unknown", out picture);

				setupImage(picture);

			}
		}

		private void DeletePictureBoxMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem deletePictureBox = (ToolStripMenuItem)sender;
			PTPictureBox picturebox = (PTPictureBox)deletePictureBox.Tag;
			pictureLayout.Controls.Remove(picturebox); //Remove from UI
			picturebox.Picture.Delete(); //Remove from DB
			if (File.Exists(picturebox.Picture.Path))
			{
				File.Delete(picturebox.Picture.Path); //Remove from File System
			}
		}

		public void TagPictureBoxMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem deletePictureBox = (ToolStripMenuItem)sender;
			PTPictureBox picturebox = (PTPictureBox)deletePictureBox.Tag;

			PTTag tagForm = new PTTag(picturebox.Picture);
			tagForm.ShowDialog(this);
		}
	}
}
