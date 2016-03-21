using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureTagger_UI_WinForms.CustomControls
{
	class PlaceholderTextBox : TextBox
	{
		private bool IsShowingPlaceholder;

		public string Placeholder { get; set; }

		public PlaceholderTextBox(string placeholder)
		{
			this.Placeholder = placeholder;

			if (!HasText()) ShowPlaceholder();
			else HidePlaceholder();

			this.GotFocus += PlaceholderTextBox_GotFocus;
			this.LostFocus += PlaceholderTextBox_LostFocus;
		}

		private bool HasText()
		{
			return this.Text.Length > 0;
		}

		private void ShowPlaceholder()
		{
			IsShowingPlaceholder = true;
			this.ForeColor = AppColor.FG.ToColor().Darken(100);
			this.Text = Placeholder;
		}

		private void HidePlaceholder()
		{
			IsShowingPlaceholder = false;
			this.ForeColor = AppColor.FG.ToColor();
			this.Text = "";
		}

		private void PlaceholderTextBox_GotFocus(object sender, EventArgs e)
		{
			if (IsShowingPlaceholder)
			{
				HidePlaceholder();
			}
		}

		private void PlaceholderTextBox_LostFocus(object sender, EventArgs e)
		{
			if (!HasText())
			{
				ShowPlaceholder();
			}
		}
	}
}
