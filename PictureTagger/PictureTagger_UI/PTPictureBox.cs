using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using PictureTagger_System;

namespace PictureTagger_UI
{
    public class PTPictureBox : PictureBox
    {
        private readonly Rectangle imageSize = new Rectangle(0, 0, 75, 75);

        public PTPicture Picture { get; private set; }

        public PTPictureBox(PTPicture Picture)
        {
            this.Picture = Picture;
			this.ImageLocation = this.Picture.Path;
			this.Image = Image.FromFile(this.ImageLocation);
			this.Tag = String.Join(",", this.Picture.Keywords);
            this.Bounds = imageSize;
            this.SizeMode = PictureBoxSizeMode.Zoom;
        }

    }
}