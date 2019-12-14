using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace FinReCon
{
    [TestClass]
    class TestItemMatching
    {
        [TestMethod]
        public static void TryRemoveMatchingItems()
        {
            List<string> sampleList_1 = new List<string> { "A", "B", "C" };
            List<string> sampleList_2 = new List<string> { "B", "C", "D" };
            List<string> sampleList_Combined = new List<string>();

            List<string> sampleList_Expected = new List<string> { "A", "D" };

            sampleList_Combined = FinReCon.SearchFunctions.noMatchingItem(sampleList_1, sampleList_2);

            Assert.IsTrue(sampleList_Combined == sampleList_Expected);
        }
    }
}
