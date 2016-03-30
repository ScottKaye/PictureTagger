using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace PictureTagger_System
{
	[Table(Name = "Pictures")]
	public class PTPicture
	{
		[Column(IsPrimaryKey = true, IsDbGenerated = true)]
		public int PictureID { get; set; }

		[Column]
		public string Path { get; set; }

		[Column]
		public string PrimaryColour { get; set; }

		// Relationships

		private EntitySet<PTTag> _Tags;
		[Association(Storage = "_Tags", OtherKey = "PictureID")]
		public EntitySet<PTTag> Tags
		{
			get { return this._Tags; }
			set { this._Tags.Assign(value); }
		}
	}
}
