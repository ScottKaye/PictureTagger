using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureTagger_UI_WinForms.Pages
{
	class BrowsePanel : Panel
	{
		public BrowsePanel(Layout layout, Rectangle bounds)
		{
			Location = bounds.Location;
			Size = bounds.Size;

			// Search field
			{
				int margin = 100;

				Panel panel = new Panel()
				{
					Location = new Point(margin, 0),
					Size = new Size(bounds.Width - margin * 2, 40),
					BackColor = AppColor.Sidebar.ToColor(),
					Padding = new Padding(10)
				};

				RichTextBox search = new RichTextBox()
				{
					Text = "Hello",
					Dock = DockStyle.Fill,
					Font = layout.BodyFont,
					BackColor = AppColor.Sidebar.ToColor(),
					ForeColor = AppColor.FG.ToColor(),
					BorderStyle = BorderStyle.None,
					Multiline = false
				};

				panel.Controls.Add(search);
				Controls.Add(panel);
			}
		}
	}
}
