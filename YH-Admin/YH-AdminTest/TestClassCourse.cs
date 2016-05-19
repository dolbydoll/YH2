using System;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Model;

namespace YH_AdminTest
{
    [TestClass]
    public class TestClassCourse
    {
        [TestMethod]
        public void TestGetEndDate()
        {
            ClassCourse cc = new ClassCourse(0, 0, 0, new DateTime(2012, 3, 11), new DateTime(2013, 4, 12));
            string expected = "20130412";

            string actual = cc.GetEndDate();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestGetStartDate()
        {
            //Arrange
            ClassCourse gsd = new ClassCourse(1, 2, 3, new DateTime(2016, 04, 26), new DateTime(2016, 02, 02));
            string expected = "20160426";

            //Act
            var actual = gsd.GetStartDate();

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestToString()
        {
            ClassCourse cc = new ClassCourse(1, 2, 3, new DateTime(2016, 01, 01), new DateTime(2016, 02, 02));
            string expected = $"1 2 3; 20160101->20160202";

            var actual = cc.ToString();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void IsFinished()
        {
            var cc = new ClassCourse(1, 2, 3, new DateTime(2016, 01, 01), new DateTime(2016, 02, 02));
            string expected = cc.GetEndDate();

            var actual = cc.GetEndDate();

            Assert.AreEqual(expected, actual);
        }





    }
    


}
