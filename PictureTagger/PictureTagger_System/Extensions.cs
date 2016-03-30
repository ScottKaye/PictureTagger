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
	}
}
