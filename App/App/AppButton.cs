﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace App
{
	public abstract class AppButton
	{
		public Button Button { get; set; }
		public Image Image { get; set; }
		public AppPage Page { get; set; }

		public abstract void Select();
		public abstract void Deselect();
	}

	public class SidebarButton : AppButton
	{
		public override void Select()
		{
			Button.BackColor = AppColor.BG.ToColor();
		}

		public override void Deselect()
		{
			Button.BackColor = Color.Transparent;
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
			Button.Height = 50;
			Button.Paint += Paint;
			Button.Invalidate();
		}

		public override void Deselect()
		{
			Button.Paint -= Paint;
			Button.Invalidate();
		}
	}
}
