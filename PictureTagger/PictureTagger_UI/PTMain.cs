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
		}

		private void PTMain_Closing(object sender, FormClosingEventArgs e)
		{
			ptData = null;
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

	}
}
