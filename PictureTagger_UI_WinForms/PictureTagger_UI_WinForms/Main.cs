using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using PictureTagger_System;

namespace PictureTagger_UI_WinForms
{
	public partial class Main : Form
	{
		private Point mousePos;
		private Layout layout;
		private PTData data;

		public Main()
		{
			InitializeComponent();
			MakeLayout();

			this.FormClosed += Main_FormClosed;
			this.Load += Main_Load;
			this.Paint += Main_Paint;
			this.MouseMove += Main_MouseMove;
		}

		private void Main_FormClosed(object sender, FormClosedEventArgs e)
		{
			layout.Dispose();
		}

		private void Main_MouseMove(object sender, MouseEventArgs e)
		{
			mousePos.X = e.X;
			mousePos.Y = e.Y;
		}

		private void MakeLayout()
		{
			// Colours
			SetStyle(ControlStyles.SupportsTransparentBackColor, true);
			BackColor = AppColor.BG.ToColor();
			ForeColor = AppColor.FG.ToColor();

			// Size + Positioning
			FormBorderStyle = FormBorderStyle.None;
			Size = new Size(1000, 600);
			StartPosition = FormStartPosition.CenterScreen;

			// Layout elements
			layout = new Layout(this);

			//
			// Controls
			//

			// Sidebar buttons
			{
				int size = 60;
				int y = 0;
				foreach (var button in layout.AppButtons.OfType<SidebarButton>())
				{
					Button b = new Button()
					{
						BackgroundImage = button.Image,
						BackgroundImageLayout = ImageLayout.Stretch,
						Size = new Size(size, size),
						Location = new Point(0, y)
					};

					button.Button = b;
					b.Labelify();
					b.Click += (s, e) => ChangeView(button.Page);

					Controls.Add(b);
					y += size;
				}
			}

			// Subtitle buttons
			{
				int buttonWidth = 120;
				var buttons = layout.AppButtons.OfType<SubtitleButton>();

				TableLayoutPanel panel = new TableLayoutPanel()
				{
					ColumnCount = buttons.Count(),
					AutoSize = true,
					BackColor = Color.Transparent,
					Height = layout.SubtitleFont.Height,
					Location = new Point(
						(layout.TitleRect.Right - buttonWidth * buttons.Count()) / 2 + layout.SidebarRect.Width / 2,
						layout.TitleRect.Height / 2 + 30
					)
				};

				foreach (var button in buttons)
				{
					Button b = new Button()
					{
						Text = button.Text,
						Dock = DockStyle.Fill,
						TextAlign = ContentAlignment.TopCenter,
						Font = layout.SubtitleFont,
					};

					button.Button = b;
					b.Labelify();
					b.Click += (s, e) => ChangeView(button.Page);

					panel.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, buttonWidth));
					panel.Controls.Add(b);
				}

				Controls.Add(panel);
			}
		}

		private void ChangeView(AppPage page)
		{
			// Mark navigation layout items as "selected"
			foreach (var button in layout.AppButtons)
			{
				if (button.Page == page)
				{
					button.Select();
				}
				else
				{
					button.Deselect();
				}
			}
		}

		private void Main_Load(object sender, EventArgs e)
		{
			data = new PTData();
		}

		private void DrawGraphicsStatic(Graphics g)
		{
			// Sidebar
			g.FillRectangle(AppColor.Sidebar.ToBrush(), layout.SidebarRect);

			// Mountains
			g.DrawImage(layout.BackgroundImage, layout.SidebarRect.Width, 0, layout.ContentRect.Width, layout.ContentRect.Width / 3.5f);

			// Text
			StringFormat center = new StringFormat();
			center.LineAlignment = StringAlignment.Center;
			center.Alignment = StringAlignment.Center;

			using (Brush b = AppColor.FG.ToBrush())
			{
				g.DrawString("PictureTagger", layout.HeaderFont, b, layout.TitleRect, center);
			}
		}

		private void Main_Paint(object sender, PaintEventArgs e)
		{
			DrawGraphicsStatic(e.Graphics);
		}
	}
}
