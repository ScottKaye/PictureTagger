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
	internal static class Extensions
	{
		internal static bool IsAlphaNum(this string str)
		{
			return new Regex("^[a-zA-Z0-9]+$").IsMatch(str);
		}

		internal static string NormalizeKeyword(this string keyword)
		{
			return new Regex("[^a-z0-9]").Replace(keyword.ToLowerInvariant().Trim(), "");
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
				PrimaryColour = ColorTranslator.FromHtml(reader.GetString(2))
			};
		}
	}
}
