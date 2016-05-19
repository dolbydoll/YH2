using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YH_Admin.Model;

namespace YH_AdminTest
{
    [TestClass]
    public class TestTeacher
    {

        [TestMethod]
        public void TestToString()
        {
            Staffing s = new Staffing(0, "Niklas", "Persson");
            string expected = $"Id: 0; Name: Niklas Persson";

            var actual = s.GetStaffString();

            Assert.AreEqual(expected, actual);
        }
    }

    
}
