using System;
using Engr.Maths.Vectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Engr.Maths.Test
{
    [TestClass]
    public class SwizzleTests
    {
        [TestMethod]
        public void Vect2SwizzleTest()
        {
            var v = new Vect2(5, 6);
            Assert.AreEqual(new Vect2(6, 6), v.Swizzle().YY);
            Assert.AreEqual(new Vect2(5, 5), v.Swizzle().XX);
        }

        [TestMethod]
        public void Vect2fSwizzleTest()
        {
            var v = new Vect2f(5, 6);
            Assert.AreEqual(new Vect2f(6, 6), v.Swizzle().YY);
            Assert.AreEqual(new Vect2f(5, 5), v.Swizzle().XX);
        }

        [TestMethod]
        public void Vect3SwizzleTest()
        {
            var v = new Vect3(5, 6, 7);
            Assert.AreEqual(new Vect3(5, 5, 5), v.Swizzle().XXX);
            Assert.AreEqual(new Vect3(6, 6, 6), v.Swizzle().YYY);
            Assert.AreEqual(new Vect3(7, 7, 7), v.Swizzle().ZZZ);
            Assert.AreEqual(new Vect3(7, 6, 5), v.Swizzle().ZYX);
        }

        [TestMethod]
        public void InvalidChar()
        {
            try
            {
                var v = new Vect3(5, 6, 7);
                var s = v.Swizzle().XXH;
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (Exception)
            {

            }
        }


        [TestMethod]
        public void SwizzleTypes()
        {
            var vd = new Vect4(5, 6, 7, 8);
            var vf = new Vect4f(5, 6, 7, 8);

            Assert.AreEqual(typeof(double), vd.Swizzle().X.GetType());
            Assert.AreEqual(typeof(Vect2), vd.Swizzle().XX.GetType());
            Assert.AreEqual(typeof(Vect3), vd.Swizzle().XXX.GetType());
            Assert.AreEqual(typeof(Vect4), vd.Swizzle().XXXX.GetType());
            Assert.AreEqual(typeof(Vect), vd.Swizzle().XXXXX.GetType());

            Assert.AreEqual(typeof(float), vf.Swizzle().X.GetType());
            Assert.AreEqual(typeof(Vect2f), vf.Swizzle().XX.GetType());
            Assert.AreEqual(typeof(Vect3f), vf.Swizzle().XXX.GetType());
            Assert.AreEqual(typeof(Vect4f), vf.Swizzle().XXXX.GetType());
            Assert.AreEqual(typeof(Vectf), vf.Swizzle().XXXXX.GetType());
        }
    }
}
