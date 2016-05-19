using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Model;

namespace YH_AdminTest
{
    [TestClass]
    public class TestStudent
    {
        [TestMethod]
        public void TestToString()
        {

            Student s = new Student(1, "Al", "Baak", 2);
            string expected = $"1 Al Baak 2";

            var actual = s.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
