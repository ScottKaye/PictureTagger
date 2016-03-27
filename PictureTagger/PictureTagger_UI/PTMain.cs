using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PictureTagger_System;

namespace PictureTagger_UI
{
    public partial class PTMain : Form
    {

        //Data
        protected PTData ptData = new PTData();

        //UI
        protected PTOptions optionsForm = null;

        public PTMain()
        {
            InitializeComponent();
            optionsForm = new PTOptions();

            loadImages();
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

        }

        private void optionsPTMainStripItem_Click(object sender, EventArgs e)
        {
            optionsForm.ShowDialog(this);
        }

        private void loadImages()
        {
            List<PTPicture> myPictures = ptData.Select();

            foreach(PTPicture p in myPictures)
            {
                PTPictureBox tempPictureBox = new PTPictureBox(p);
                pictureFlowLayout.Controls.Add(tempPictureBox);
            }

            //ContextMenuStrip mainContentMenuStrip = new ContextMenuStrip();
            //ToolStripMenuItem tagToolStripItem = new ToolStripMenuItem("Tag");
            //mainContentMenuStrip.Items.Add(tagToolStripItem);
            //imagePictureBox.ContextMenuStrip = mainContentMenuStrip;
        }


    }
}
