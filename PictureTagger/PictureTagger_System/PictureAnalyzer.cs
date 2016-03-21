using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace PictureTagger_System
{
	internal static class PictureAnalyzer
	{
		internal static Color GetDominantColour(string filename)
		{
			return GetDominantColour(new Bitmap(filename));
		}

		internal static Color GetDominantColour(Bitmap bitmap)
		{
			int cost = 50;
			Color dominant = Color.Black;

			using (Bitmap small = new Bitmap(bitmap, new Size(cost, bitmap.Height / (bitmap.Width / cost))))
			{
				var colors = new List<Color>();
				for (int x = 0; x < small.Width; ++x)
				{
					for (int y = 0; y < small.Height; ++y)
					{
						colors.Add(small.GetPixel(x, y));
					}
				}

				var averageSaturation = colors.Average(c => c.GetSaturation());
				var averageBrightness = colors.Average(c => c.GetBrightness());
				var ordered = from col in colors
							  where col.GetBrightness() < 0.9
							  where col.GetSaturation() > 0.6
							  where col.GetBrightness() > averageBrightness
							  where col.GetSaturation() > averageSaturation
							  orderby col.GetBrightness() descending, col.GetSaturation() descending
							  select col;

				dominant = ordered.First();
			}

			return dominant;
		}
	}
}
