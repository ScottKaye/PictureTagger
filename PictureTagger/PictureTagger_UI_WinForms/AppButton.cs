using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureTagger_UI_WinForms
{
	public abstract class AppButton
	{
		private Bitmap _Image { get; set; }
		protected bool Selected = false;

		public Button Button { get; set; }
		public Bitmap Image
		{
			get
			{
				return _Image.Clone(ImageRegion, _Image.PixelFormat);
			}
			set { _Image = value; }
		}
		public Rectangle ImageRegion { get; set; }
		public AppPage Page { get; set; }

		public abstract void Select();
		public abstract void Deselect();
	}

	public class SidebarButton : AppButton
	{
		public override void Select()
		{
			if (Selected) return;

			Button.BackColor = AppColor.BG.ToColor();
			this.ImageRegion = new Rectangle(ImageRegion.X, 60, 60, 60);
			Button.BackgroundImage = this.Image;
			Selected = true;
		}

		public override void Deselect()
		{
			if (!Selected) return;

			Button.BackColor = Color.Transparent;
			this.ImageRegion = new Rectangle(ImageRegion.X, 0, 60, 60);
			Button.BackgroundImage = this.Image;
			Selected = false;
		}
	}

	public class SubtitleButton : AppButton
	{
		private string _Text;
		public string Text
		{
			get { return _Text.ToUpperInvariant(); }
			set { _Text = value; }
		}

		private void Paint(object sender, PaintEventArgs e)
		{
			int shadowOffset = 25;
			int shadowHeight = 8;
			LinearGradientBrush grad = new LinearGradientBrush(new Point(0, 0), new Point(0, shadowOffset + shadowHeight + 2), Color.White, Color.Transparent);
			e.Graphics.FillRectangle(grad, 10, shadowOffset + 2, Button.Width - 20, shadowHeight);
			e.Graphics.FillRectangle(Brushes.White, 10, shadowOffset, Button.Width - 20, 2);
		}

		public override void Select()
		{
			if (Selected) return;

			Button.Height = 50;
			Button.Paint += Paint;
			Button.Invalidate();
			Selected = true;
		}

		public override void Deselect()
		{
			if (!Selected) return;

			Button.Paint -= Paint;
			Button.Invalidate();
			Selected = false;
		}
	}
}
