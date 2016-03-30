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
	public partial class PTTag : Form
	{
		public PTPicture Picture { get; private set; }

		public PTTag(PTPicture picture)
		{
			InitializeComponent();
		}

		private void PTTag_Load(object sender, EventArgs e)
		{
			foreach(var keyword in Picture.Keywords)
			{
				this.pictureKeywrods.Items.Add(keyword);
			}
		}

		private void PTTag_Closing(object sender, FormClosingEventArgs e)
		{
			foreach(var keyword in this.pictureKeywrods.Items)
			{
				if(!Picture.Keywords.Contains(keyword.ToString()))
				{
					Picture.Keywords.Add(keyword.ToString());
				}
			}
			this.Picture.Update();
		}

		private void Insert_Click(object sender, EventArgs e)
		{
			if(this.pictureKeyword.Text.Length > 0)
			{

			}
			else
			{
				MessageBox.Show("No Text Inputted", "Invalid Keyword Input", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void Delete_Click(object sender, EventArgs e)
		{
			if(pictureKeywrods.SelectedIndex > -1)
			{

			}
			else
			{
				MessageBox.Show("No Selected Item", "Invalid Keyword Selected", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void Keyword_TextChanged(object sender, EventArgs e)
		{
			addKeyword.Enabled = pictureKeyword.Text.Length > 0;
		}

		private void Keywords_SelectedIndexChanged(object sender, EventArgs e)
		{
			removeKeyword.Enabled = pictureKeywrods.SelectedIndex > -1;
		}
	}
}
