using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace PictureTagger_System
{
	[Table(Name = "Tags")]
	public class PTTag
	{
		[Column(IsPrimaryKey = true)]
		public int PictureID { get; set; }

		[Column(IsPrimaryKey = true)]
		public string Tag { get; set; }

		// Relationships

		private EntityRef<PTPicture> _Picture;
		[Association(Storage = "_Picture", ThisKey = "PictureID")]
		public PTPicture Picture
		{
			get { return this._Picture.Entity; }
			set { this._Picture.Entity = value; }
		}
	}
}
