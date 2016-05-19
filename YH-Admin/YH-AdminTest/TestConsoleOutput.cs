using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.View;

namespace YH_AdminTest
{
    [TestClass]
    public class TestConsoleOutput
    {
        [TestMethod]
        public void TestColumnLengths()
        {
            var content = new string[2, 3];
            content[0, 0] = "title1";
            content[0, 1] = "title2";
            content[0, 2] = "title3";

            content[1, 0] = "123456";
            content[1, 1] = "12345678";
            content[1, 2] = "123456789";

            int[] expected = { 7, 9, 10 }; // längd + 1 space

            var actual = new ConsoleOutput().ColumnLengths(content);

            CollectionAssert.AreEqual(expected, actual, $"{actual[0]}, {actual[1]}");
        }
    }
}
