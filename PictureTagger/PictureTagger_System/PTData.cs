using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.Linq;

namespace PictureTagger_System
{
	public class PTData
	{
		private DB db;

		public PTData()
		{
			AppDomain.CurrentDomain.SetData("DataDirectory", Environment.CurrentDirectory);
			db = new DB();
		}

		public IQueryable<PTPicture> Pictures()
		{
			return from pic in db.Pictures
				   select pic;
		}

		public IQueryable<PTTag> Tags()
		{
			return from tag in db.Tags
				   select tag;
		}

		public void Insert(PTPicture pic)
		{
			db.Pictures.InsertOnSubmit(pic);
		}

		public void Insert(PTTag tag)
		{
			db.Tags.InsertOnSubmit(tag);
		}

		public void Delete(PTPicture pic)
		{
			// Delete associated tags
			foreach(var tag in pic.Tags)
			{
				Delete(tag);
			}

			db.Pictures.DeleteOnSubmit(pic);
		}

		public void Delete(PTTag tag)
		{
			db.Tags.DeleteOnSubmit(tag);
		}

		public void Save()
		{
			db.SubmitChanges();
		}
	}
}
