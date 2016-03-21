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
		private Form form;

		public Rectangle SidebarRect;
		public Rectangle ContentRect;
		public Rectangle TitleRect;

		public List<AppButton> AppButtons = new List<AppButton>();
		public Image BackgroundImage;

		public Font HeaderFont;
		public Font SubtitleFont;

		public Layout(Form form)
		{
			this.form = form;

			SidebarRect = new Rectangle(0, 0, 60, form.Height);
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

			ContentRect = new Rectangle(SidebarRect.Width, 0, form.Width - SidebarRect.Width, form.Height);
			TitleRect = ContentRect;
			TitleRect.Height = 200;

			BackgroundImage = Properties.Resources.Mountains;

			// TODO embed Roboto
			HeaderFont = new Font("Roboto Light", 32);
			SubtitleFont = new Font("Roboto Black", 12);
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
		}
	}
}
