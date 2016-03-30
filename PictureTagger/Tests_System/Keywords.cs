using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PictureTagger_System;

namespace Tests_System
{
	[TestClass]
	public class Keywords
	{
		private PTData data;

		public Keywords()
		{
			data = new PTData();
		}

		[TestMethod]
		public void Alpha()
		{
			Assert.IsTrue("hello".IsAlphaNum());
			Assert.IsTrue("abc123abc".IsAlphaNum());
			Assert.IsFalse("hello world".IsAlphaNum());
		}

		[TestMethod]
		public void Normalize()
		{
			Assert.AreEqual("foggymountain", "FOGGY--MouNTAiN".NormalizeKeyword());
			Assert.AreEqual("bluecar", "  blue cAR".NormalizeKeyword());
			CollectionAssert.AreEqual(new[] { "test1", "test2" }, new[] { "TEST 1", "   teST2!??" }.NormalizeKeywords().ToArray());
		}
	}
}
