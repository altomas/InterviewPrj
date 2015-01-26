using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountOncesTests
{
    [TestClass]
    public class CountOfOncesUnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Int32 undertest = 0;

            Assert.AreEqual(0, CountOncesLogic.GetOnces(undertest));

            undertest = 1;

            Assert.AreEqual(1, CountOncesLogic.GetOnces(undertest));

            undertest = 2;

            Assert.AreEqual(1, CountOncesLogic.GetOnces(undertest));

            undertest = 3;

            Assert.AreEqual(2, CountOncesLogic.GetOnces(undertest));

            undertest = 8;

            Assert.AreEqual(1, CountOncesLogic.GetOnces(undertest));

            undertest = 9;

            Assert.AreEqual(2, CountOncesLogic.GetOnces(undertest));

            undertest = -1;

            Assert.AreEqual(32, CountOncesLogic.GetOnces(undertest));

        }
    }
}
