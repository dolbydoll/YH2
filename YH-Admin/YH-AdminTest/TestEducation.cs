using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Model;

namespace YH_AdminTest
{
    [TestClass]
    public class TestEducation
    {
        [TestMethod]
        public void TestToString()
        {
            //Arrange
            Education edu = new Education(1, "Systemutveckling Agila Applikationsprogrammering", 2);
            string expected = $"EducationId: 1; Name: Systemutveckling Agila Applikationsprogrammering; UserId: 2";

            var actual = edu.ToString();
            Assert.AreEqual(expected, actual);
        }
    }
}
