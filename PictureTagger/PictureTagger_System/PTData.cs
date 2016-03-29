﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PictureTagger_System
{
	public class PTData : IDisposable
	{
		internal static SqlConnection conn { get; set; }

		public PTData()
		{
			AppDomain.CurrentDomain.SetData("DataDirectory", Environment.CurrentDirectory);
			conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\PictureTagger_DB.mdf;Integrated Security=True");
			conn.Open();
		}

		~PTData()
		{
			conn.Close();
			conn.Dispose();
		}

		public void Dispose()
		{
			conn.Close();
			conn.Dispose();
		}

		/// <summary>
		/// Get all pictures in the database (maximum 100)
		/// </summary>
		/// <returns>A list of pictures</returns>
		public List<PTPicture> Select()
		{
			var results = new List<PTPicture>();

			using (var cmd = new SqlCommand("SELECT * FROM [Pictures]", conn))
			{
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						results.Add(reader.ToPTPicture());
					}
				}
			}

			return results;
		}

		/// <summary>
		/// Search the database for pictures matching keywords separated by commas
		/// </summary>
		/// <param name="searchStr">Comma-separated list of keywords</param>
		/// <returns>List of matched pictures</returns>
		public List<PTPicture> Select(string searchStr)
		{
			return Select(searchStr.Split(','));
		}

		/// <summary>
		/// Searches the database for pictures matching an array of keywords
		/// </summary>
		/// <param name="keywords">Array of keywords to search for</param>
		/// <returns>List of matched pictures</returns>
		public List<PTPicture> Select(string[] keywords)
		{
			var results = new List<PTPicture>();

			foreach (string keyword in keywords.NormalizeKeywords())
			{
				using (var cmd = new SqlCommand(@"
					SELECT * FROM [Pictures] p
					JOIN [Tags] t ON p.PictureID = t.PictureID
					WHERE t.Tag = @Tag;
				", conn))
				{
					cmd.Parameters.Add(new SqlParameter("Tag", keyword));
					using (var reader = cmd.ExecuteReader())
					{
						while (reader.Read())
						{
							results.Add(reader.ToPTPicture());
						}
					}
				}
			}

			return results;
		}

		/// <summary>
		/// Finds a picture by ID
		/// </summary>
		/// <param name="ID">Picture ID to select</param>
		/// <returns>Matching PTPicture</returns>
		public PTPicture Select(int ID)
		{
			PTPicture picture = null;

			using (var cmd = new SqlCommand("SELECT * FROM [Pictures] WHERE ID = @ID LIMIT 1", conn))
			{
				cmd.Parameters.Add(new SqlParameter("ID", ID));
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						picture = reader.ToPTPicture();
					}
				}
			}

			return picture;
		}

		/// <summary>
		/// Insert a picture into the database
		/// </summary>
		/// <param name="path">Physical file path of the picture</param>
		/// <param name="keywords">Keywords to associate with the picture</param>
		/// <returns>If the insert was successful</returns>
		public bool Insert(string path, string keywords, ref PTPicture picture)
		{
			// Construct PTPicture
			picture = new PTPicture()
			{
				Path = path,
				Keywords = keywords.Split(',').NormalizeKeywords().ToList()
			};

			picture.Update();

			return true;
		}

	}
}
