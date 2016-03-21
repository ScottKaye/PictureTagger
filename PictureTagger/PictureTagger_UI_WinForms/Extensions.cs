using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace PictureTagger_UI_WinForms
{
	public partial class Extensions
	{
		public static void Labelify(this Button b)
		{
			b.FlatStyle = FlatStyle.Flat;
			b.BackColor = Color.Transparent;
			b.FlatAppearance.BorderSize = 0;

			// All this to make sure the button does not CHANGE COLOUR when you hover over it
			b.FlatAppearance.MouseOverBackColor = Color.Transparent;
			b.FlatAppearance.MouseDownBackColor = Color.Transparent;
			b.FlatAppearance.BorderColor = Color.FromArgb(0, 0, 0, 0);
			b.BackColorChanged += (s, e) => {
				b.FlatAppearance.MouseOverBackColor = b.BackColor;
			};
		}
	}
}
