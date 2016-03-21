using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PictureTagger_UI_WinForms
{
	public class Layout : IDisposable
	{
		private Rectangle bounds;

		public Rectangle SidebarRect;
		public Rectangle ContentRect;
		public Rectangle TitleRect;

		public List<AppButton> AppButtons = new List<AppButton>();
		public Image BackgroundImage;

		public Font HeaderFont;
		public Font SubtitleFont;
		public Font BodyFont;

		public Pages.Pager[] Pages;

		public Layout(Rectangle bounds)
		{
			this.bounds = bounds;

			SidebarRect = new Rectangle(0, 0, 60, bounds.Height);
			AppButtons.AddRange(new AppButton[] {
				new SidebarButton()
				{
					Image = Properties.Resources.PhotoCollection,
					Page = AppPage.Collections,
				},
				new SidebarButton()
				{
					Image = Properties.Resources.PhotoAdd,
					Page = AppPage.Import,
				},
				new SidebarButton()
				{
					Image = Properties.Resources.Settings,
					Page = AppPage.Preferences,
				},
				new SubtitleButton()
				{
					Text = "Browse",
					Page = AppPage.Collections,
				},
				new SubtitleButton()
				{
					Text = "Import",
					Page = AppPage.Import,
				}
			});

			ContentRect = new Rectangle(SidebarRect.Width, 200, bounds.Width - SidebarRect.Width, bounds.Height - 200);
			TitleRect = new Rectangle(SidebarRect.Width, 0, bounds.Width - SidebarRect.Width, 200);

			BackgroundImage = Properties.Resources.Mountains;

			// TODO embed Roboto
			HeaderFont = new Font("Roboto Light", 32);
			SubtitleFont = new Font("Roboto Black", 12);
			BodyFont = new Font("Roboto", 12);

			Pages = new[]
			{
				new Pages.Pager() {
					Panel = new Pages.BrowsePanel(this, ContentRect),
					Page = AppPage.Collections
				}
			};
		}

		public void Dispose()
		{
			foreach (var b in AppButtons)
			{
				if (b.Image != null)
					b.Image.Dispose();
			}

			BackgroundImage.Dispose();
			HeaderFont.Dispose();
			SubtitleFont.Dispose();
			BodyFont.Dispose();
		}
	}
}
