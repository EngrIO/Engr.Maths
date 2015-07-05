using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Engr.Maths.Test
{
    [TestClass]
    public class MapTest
    {
        [TestMethod]
        public void TestDouble()
        {
            Assert.AreEqual((5.0).Map(0, 10, 0, 2), 1.0);
        }
    }
}
