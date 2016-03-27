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

        public PTPictureBox (PTPicture Picture)
        {
            this.Picture = Picture;
            this.Bounds = imageSize;
            this.SizeMode = PictureBoxSizeMode.Zoom;
        }

        public new Image Image
        {
            get
            {
                if (this.Image == null)
                {
                    this.Image = this.Picture.Image;
                }
                return this.Image;
            }
            private set
            {
                this.Image = value;
            }
        }

        public new string ImageLocation
        {
            get
            {
                if (this.ImageLocation == null)
                {
                    this.ImageLocation = this.Picture.Path;
                }
                return this.ImageLocation;
            }
            private set
            {
                this.ImageLocation = value;
            }
        }

        public new string Tag
        {
            get
            {
                if(this.Tag == null)
                {
                    this.Tag = String.Join<String>(",", this.Picture.Keywords);
                }
                return this.Tag;
            }
            private set
            {
                this.Tag = value;
            }
        }

    }
}
