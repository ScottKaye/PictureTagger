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
	public partial class MainPanel : Panel
	{
		private Point mousePos;
		private Layout layout;
		private PTData data;
		private Rectangle bounds;

		public MainPanel(Rectangle bounds)
		{
			this.bounds = bounds;
			this.HandleDestroyed += MainPanel_Destroy;
			this.HandleCreated += MainPanel_Load;
			this.Paint += MainPanel_Paint;
			this.MouseMove += MainPanel_MouseMove;

			MakeLayout();
		}

		~MainPanel()
		{
			layout.Dispose();
		}

		private void MainPanel_Destroy(object sender, EventArgs e)
		{
			layout.Dispose();
		}

		private void MainPanel_MouseMove(object sender, MouseEventArgs e)
		{
			mousePos.X = e.X;
			mousePos.Y = e.Y;
		}

		private void MakeLayout()
		{
			SuspendLayout();

			// Colours
			BackColor = AppColor.BG.ToColor();
			ForeColor = AppColor.FG.ToColor();

			// Layout elements
			Location = bounds.Location;
			Size = bounds.Size;
			TabStop = false;
			layout = new Layout(bounds);

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
						BackgroundImageLayout = ImageLayout.None,
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

			// Pages
			{
				foreach(var pager in layout.Pages)
				{
					Controls.Add(pager.Panel);
				}
			}

			// Starting page
			ChangeView(AppPage.Collections);

			ResumeLayout(true);
		}

		private void ChangeView(AppPage page)
		{
			// Mark navigation layout items as "selected"
			foreach (var button in layout.AppButtons)
			{
				if (button.Page == page)
					button.Select();
				else
					button.Deselect();
			}

			// Select page
			foreach(var pager in layout.Pages)
			{
				if (pager.Page == page)
					pager.Panel.Show();
				else
					pager.Panel.Hide();
			}
		}

		private void MainPanel_Load(object sender, EventArgs e)
		{
			data = new PTData();

			var pics = data.Select("tagone");
			foreach (var pic in pics)
			{
				Debug.WriteLine(pic.Path);
			}
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

		private void MainPanel_Paint(object sender, PaintEventArgs e)
		{
			DrawGraphicsStatic(e.Graphics);
		}
	}
}
