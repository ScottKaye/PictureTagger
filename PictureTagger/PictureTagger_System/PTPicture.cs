using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.IO;

namespace PictureTagger_System
{
    public class PTPicture
    {
        private bool keywordsChanged = false;

        private List<string> _Keywords { get; set; }
        private Color? _PrimaryColour { get; set; }

		public int? ID { get; set; }
		public string Path { get; set; }

		public Color PrimaryColour
		{
			get
			{
				if (!_PrimaryColour.HasValue)
				{
					_PrimaryColour = PictureAnalyzer.GetDominantColour(this.Path);
				}
				return _PrimaryColour.Value;
			}
			set { _PrimaryColour = value; }
		}

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

		private bool Create()
		{
			int? id = null;

			using (var cmd = new SqlCommand("INSERT INTO [Pictures] (Path, PrimaryColour) VALUES (@Path, @Colour); SELECT SCOPE_IDENTITY()", PTData.conn))
			{
				cmd.Parameters.Add(new SqlParameter("Path", this.Path));
				cmd.Parameters.Add(new SqlParameter("Colour", ColorTranslator.ToHtml(this.PrimaryColour)));

				using (var reader = cmd.ExecuteReader())
				{
					reader.Read();
					id = (int)reader.GetDecimal(0);
				}
			}

			if (id == null) return false;

			this.ID = id;
			return true;
		}

		public bool Update()
		{
			if (this.ID == null)
			{
				Create();
			}

			// Update this object's fields
			using (SqlCommand cmd = new SqlCommand("UPDATE [Pictures] SET Path = @Path, PrimaryColour = @Colour WHERE PictureID = @ID", PTData.conn))
			{
				// TODO validate params for length/other
				cmd.Parameters.Add(new SqlParameter("ID", this.ID));
				cmd.Parameters.Add(new SqlParameter("Path", this.Path));
				cmd.Parameters.Add(new SqlParameter("Colour", ColorTranslator.ToHtml(this.PrimaryColour)));

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

				keywordsChanged = false;
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
