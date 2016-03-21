using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace PictureTagger_System
{
	public class PTPicture
	{
		private bool keywordsChanged = false;
		private List<string> _Keywords { get; set; }

		public int ID { get; set; }
		public string Path { get; set; }
		public int PrimaryColour { get; set; }

		public List<string> Keywords
		{
			get
			{
				return _Keywords;
			}
			set
			{
				keywordsChanged = true;
				_Keywords = value;
			}
		}

		public bool Update()
		{
			// Update this object's fields
			using (SqlCommand cmd = new SqlCommand("UPDATE [Pictures] SET Path = @Path WHERE PictureID = @ID", PTData.conn))
			{
				// TODO validate params for length/other
				cmd.Parameters.Add(new SqlParameter("ID", this.ID));
				cmd.Parameters.Add(new SqlParameter("Path", this.Path));

				cmd.ExecuteNonQuery();
			}

			// Update keywords
			if (keywordsChanged)
			{
				// Delete all existing keywords for this picture
				using (var cmd = new SqlCommand("DELETE FROM [Tags] WHERE PictureID = @ID", PTData.conn))
				{
					cmd.Parameters.Add(new SqlParameter("ID", this.ID));
					cmd.ExecuteNonQuery();
				}

				// Add all new keywords for this picture
				foreach (string keyword in Keywords)
				{
					// TODO may fail to primary keys
					using (var cmd = new SqlCommand("INSERT INTO [Tags] (PictureID, Tag) VALUES (@ID, @Tag)", PTData.conn))
					{
						// TODO validate params for length/other
						cmd.Parameters.Add(new SqlParameter("ID", this.ID));
						cmd.Parameters.Add(new SqlParameter("Tag", keyword));
						cmd.ExecuteNonQuery();
					}
				}
			}

			return true;
		}

		public bool Delete()
		{
			// Delete picture
			using (var cmd = new SqlCommand("DELETE FROM [Pictures] WHERE PictureID = @ID", PTData.conn))
			{
				cmd.Parameters.Add(new SqlParameter("ID", this.ID));
				cmd.ExecuteNonQuery();
			}

			// Delete tags
			using (var cmd = new SqlCommand("DELETE FROM [Tags] WHERE PictureID = @ID", PTData.conn))
			{
				cmd.Parameters.Add(new SqlParameter("ID", this.ID));
				cmd.ExecuteNonQuery();
			}

			return true;
		}
	}
}
