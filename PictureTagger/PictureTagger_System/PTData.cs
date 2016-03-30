using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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


	}
}
