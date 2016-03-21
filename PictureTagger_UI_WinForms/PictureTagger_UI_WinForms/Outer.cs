using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureTagger_UI_WinForms
{
	public partial class Outer : Form
	{
		private const int BORDER_SIZE = 2;
		private Rectangle innerRect;

		public Outer()
		{
			InitializeComponent();
			MakeLayout();

			this.Paint += Outer_Paint;
		}

		private void Outer_Paint(object sender, PaintEventArgs e)
		{
			// Border
			using (var b = AppColor.BG.ToBrush())
			{
				e.Graphics.FillRectangle(b, ClientRectangle);
			}
		}

		private void MakeLayout()
		{
			// Size + Positioning
			FormBorderStyle = FormBorderStyle.None;
			Size = new Size(1000, 600);
			StartPosition = FormStartPosition.CenterScreen;

			innerRect = ClientRectangle;
			innerRect.Inflate(new Size(-BORDER_SIZE, -BORDER_SIZE));

			MainPanel main = new MainPanel(innerRect);
			Controls.Add(main);
		}




		public const int WM_NCLBUTTONDOWN = 0xA1;
		public const int HT_CAPTION = 0x2;

		[DllImportAttribute("user32.dll")]
		public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
		[DllImportAttribute("user32.dll")]
		public static extern bool ReleaseCapture();

		private void Outer_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				ReleaseCapture();
				SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
			}
		}
	}
}
