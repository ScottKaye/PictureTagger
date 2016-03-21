using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureTagger_System
{
	internal static class Extensions
	{
		internal static string NormalizeKeyword(this string keyword)
		{
			return keyword.ToLowerInvariant().Trim();
		}

		internal static IEnumerable<string> NormalizeKeywords(this string[] keywords)
		{
			return keywords.Select(str => str.NormalizeKeyword());
		}

		internal static PTPicture ToPTPicture(this SqlDataReader reader)
		{
			return new PTPicture()
			{
				ID = reader.GetInt32(0),
				Path = reader.GetString(1),
				PrimaryColour = reader.GetInt32(2)  // TODO this might overflow
			};
		}
	}
}
