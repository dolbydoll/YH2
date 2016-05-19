using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Model;

namespace YH_AdminTest
{
    [TestClass]
    public class TestCourse
    {
        [TestMethod]
        public void TestToString()
        {
            Course c = new Course(1, "Kurs");
            string expected = $"CourseId: 1, Name: Kurs";

            var actual = c.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}