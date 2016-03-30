using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;
using System.Data.Linq;

namespace PictureTagger_System
{
	[Database]
	public class DB : DataContext
	{
		public DB() : base(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PictureTagger_DB.mdf;Integrated Security=True") { }

		public Table<PTPicture> Pictures;
		public Table<PTTag> Tags;
	}
}
