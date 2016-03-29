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
		private PTData ptData = null;

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

			foreach (var control in pictureLayout.Controls)
			{
				PTPictureBox pt = (PTPictureBox)control;
				pt.Dispose();
			}

		}

		private void PTMain_Closing(object sender, FormClosingEventArgs e)
		{
			ptData.Dispose();
		}

		private void setupImage(PTPicture picture)
		{
			PTPictureBox picturebox = new PTPictureBox(picture);
			pictureLayout.Controls.Add(picturebox);

			ContextMenuStrip pictureboxContextMenuStrip = new ContextMenuStrip();

			ToolStripMenuItem deletePictureBoxMenuItem = new ToolStripMenuItem("Delete");
			deletePictureBoxMenuItem.Tag = picturebox;
			deletePictureBoxMenuItem.Click += DeletePictureBoxMenuItem_Click;

			pictureboxContextMenuStrip.Items.Add(deletePictureBoxMenuItem);
			picturebox.ContextMenuStrip = pictureboxContextMenuStrip;
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
			openFileDialogImageImport.ShowDialog(this);
        }

        private void optionsPTMainStripItem_Click(object sender, EventArgs e)
        {
            optionsForm.ShowDialog(this);
        }

		private void openFileDialogImageImport_FileOk(object sender, CancelEventArgs e)
		{
			var dialog = ((OpenFileDialog)sender);
			foreach (var file in dialog.FileNames)
			{
				var fileName = Path.GetFileName(file);
				var oldDir = Path.GetDirectoryName(file);
				var newDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\PictureTagger\";

				var oldFile = file;
				var newFile = newDir + fileName;

				File.Copy(oldFile, newFile, true);

				PTPicture picture = null;

				ptData.Insert(newFile, "", ref picture);

				setupImage(picture);

			}
		}

		private void DeletePictureBoxMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem deletePictureBox = (ToolStripMenuItem)sender;
			PTPictureBox picturebox = (PTPictureBox)deletePictureBox.Tag;
			pictureLayout.Controls.Remove(picturebox);
			picturebox.Picture.Delete();
			if (File.Exists(picturebox.Picture.Path))
			{
				File.Delete(picturebox.Picture.Path);
			}
		}

	}
}
