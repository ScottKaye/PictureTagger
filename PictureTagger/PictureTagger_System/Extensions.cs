using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PictureTagger_System
{
	public static class Extensions
	{
		public static bool IsAlphaNum(this string str)
		{
			return new Regex("^[a-zA-Z0-9]+$").IsMatch(str);
		}

		public static string NormalizeKeyword(this string keyword)
		{
			return new Regex("[^a-z0-9]").Replace(keyword.ToLowerInvariant().Trim(), "");
		}

		public static IEnumerable<string> NormalizeKeywords(this string[] keywords)
		{
			return keywords.Select(str => str.NormalizeKeyword());
		}

		internal static PTPicture ToPTPicture(this SqlDataReader reader)
		{
			return new PTPicture()
			{
				ID = reader.GetInt32(0),
				Path = reader.GetString(1),
				Keywords = new List<string>(),
				PrimaryColour = ColorTranslator.FromHtml(reader.GetString(2))
			};
		}

		internal static bool LoadKeywords(this PTPicture p)
		{
			using (var cmd = new SqlCommand("SELECT t.Tag FROM [Pictures] p JOIN [Tags] t ON p.PictureID = t.PictureID WHERE p.PictureID=@PictureID;", PTData.conn))
			{
				cmd.Parameters.Add(new SqlParameter("PictureID", p.ID));
				using (var reader = cmd.ExecuteReader())
				{
					while (reader.Read())
					{
						p.Keywords.Add(reader.GetString(0));
					}
				}
			}
			return true;
		}
	}
}
