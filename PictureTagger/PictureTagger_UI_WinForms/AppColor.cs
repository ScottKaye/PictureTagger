using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;

namespace PictureTagger_UI_WinForms
{
	public enum AppColor : uint
	{
		BG = 0xff011111,
		FG = 0xffffffff,
		Sidebar = 0xff263238
	};

	public static partial class Extensions
	{
		public static Color ToColor(this AppColor color)
		{
			return Color.FromArgb((int)color);
		}

		public static Brush ToBrush(this AppColor color)
		{
			return new SolidBrush(color.ToColor());
		}
	}
}
