using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lingo.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFilterLetterCount()
        {
            WordFilter filter = new WordFilter();

            Assert.IsTrue(filter.FilterLetterCount("four", 4));
        }
    }
}
