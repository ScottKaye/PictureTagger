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
		public PTData ptData;
		public List<string> deletes = new List<string>() { };  // Batch deletes into a single transaction

		public PTTag(PTPicture picture, PTData data)
		{
			InitializeComponent();
			this.Picture = picture;
			ptData = data;
		}

		private void PTTag_Load(object sender, EventArgs e)
		{
			foreach (var keyword in Picture.Tags)
			{
				this.pictureKeywords.Items.Add(keyword.Tag);
			}
		}

		/// <summary>
		/// Add unsaved tags to pictures when the tag is closed
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void PTTag_Closing(object sender, FormClosingEventArgs e)
		{
			// Handle deletes
			foreach (var tag in Picture.Tags.ToList())
			{
				if (deletes.Contains(tag.Tag))
				{
					ptData.Delete(tag);
				}
			}

			// Add tags that aren't already associated with this picture
			foreach (var tag in this.pictureKeywords.Items)
			{
				if (!Picture.Tags.Select(t => t.Tag).Contains(tag.ToString()))
				{
					Picture.Tags.Add(new PictureTagger_System.PTTag
					{
						Picture = Picture,
						Tag = tag.ToString()
					});
				}
			}

			// Save changes
			ptData.Save();
		}

		private void Insert_Click(object sender, EventArgs e)
		{
			if (this.pictureKeyword.Text.Length > 0)
			{
				if (this.pictureKeyword.Text.IsAlphaNum())
				{
					this.pictureKeywords.Items.Add(this.pictureKeyword.Text.NormalizeKeyword());
					this.pictureKeywords.Update();
				}
			}
			else
			{
				MessageBox.Show("No Text Inputted", "Invalid Keyword Input", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void Delete_Click(object sender, EventArgs e)
		{
			if (pictureKeywords.SelectedIndex > -1)
			{
				var x = pictureKeywords.SelectedIndex;
				pictureKeywords.ClearSelected();
				deletes.Add(this.pictureKeywords.Items[x].ToString());
				this.pictureKeywords.Items.RemoveAt(x);
				this.pictureKeywords.Update();
			}
			else
			{
				MessageBox.Show("No Selected Item", "Invalid Keyword Selected", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
			}
		}

		private void Commit_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(this, "Save changes to keywords?", "Update Keywords", MessageBoxButtons.OKCancel, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2) == DialogResult.OK)
			{
				this.Close();
			}
		}

		private void Keyword_TextChanged(object sender, EventArgs e)
		{
			addKeyword.Enabled = pictureKeyword.Text.Length > 0 && this.pictureKeyword.Text.IsAlphaNum();
		}

		private void Keywords_SelectedIndexChanged(object sender, EventArgs e)
		{
			removeKeyword.Enabled = pictureKeywords.SelectedIndex > -1;
		}

	}
}
