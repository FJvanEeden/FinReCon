using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FinReCon
{
    [TestClass]
    class TestFileBrowse
    {
        [TestMethod]
        public static void TryBrowseFile()
        {
            String pathExample = "C:\\Users\\Person\\Desktop\\file.csv";

            String TBTextExample = FileBrowser.BrowseFile();

            Assert.IsTrue(TBTextExample == pathExample);
        }
    }
}
