using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lingo.Test
{
    [TestClass]
    public class WordFilterTest
    {
        [TestMethod]
        public void TestWordLowercase5Characters()
        {
            Assert.IsTrue(WordFilter.FilterWord("hallo"));
        }

        [TestMethod]
        public void TestWordUppercase()
        {
            Assert.IsFalse(WordFilter.FilterWord("HALLO"));
        }

        [TestMethod]
        public void TestWordWithPunctuation()
        {
            Assert.IsFalse(WordFilter.FilterWord("hallö"));
        }

        [TestMethod]
        public void TestWord4Characters()
        {
            Assert.IsFalse(WordFilter.FilterWord("hall"));
        }

        [TestMethod]
        public void TestWord8Characters()
        {
            Assert.IsFalse(WordFilter.FilterWord("hallohal"));
        }
    }
}
