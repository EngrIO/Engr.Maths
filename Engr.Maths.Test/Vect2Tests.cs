using System;
using Engr.Maths.Vectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Engr.Maths.Test
{
    [TestClass]
    public class Vect2Tests
    {
        [TestMethod]
        public void CreationFromDoubles()
        {
            var x = 2.0;
            var y = 3.0;
            var v2 = new Vect2(x, y);
            Assert.AreEqual(x, v2.X, Constants.Delta);
            Assert.AreEqual(y, v2.Y, Constants.Delta);
        }

        [TestMethod]
        public void CreationFromListTooLong()
        {
            try
            {
                var v = new Vect2(new[] { 2.0, 3.0, 5.0 });
                Assert.Fail(); // If it gets to this line, no exception was thrown
            }
            catch (ArgumentException)
            {

            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void CreationFromList()
        {
            var x = 2.0;
            var y = 3.0;
            var v2 = new Vect2(new[] { x, y });
            Assert.AreEqual(x, v2.X, Constants.Delta);
            Assert.AreEqual(y, v2.Y, Constants.Delta);
        }

        [TestMethod]
        public void LengthResult()
        {
            var v2 = new Vect2(2.0, 3.0);
            Assert.AreEqual(13.0, v2.LengthSquared, Constants.Delta);
            Assert.AreEqual(3.60555127546, v2.Length, Constants.Delta);
        }

        [TestMethod]
        public void NormalisedResult()
        {
            Assert.AreEqual(new Vect2(0.5547, 0.83205), new Vect2(2.0, 3.0).Normalize());
        }

        [TestMethod]
        public void StaticDefaults()
        {
            Assert.AreEqual(new Vect2(0.0, 0.0), Vect2.Zero);
            Assert.AreEqual(new Vect2(1.0, 0.0), Vect2.UnitX);
            Assert.AreEqual(new Vect2(0.0, 1.0), Vect2.UnitY);
        }

        [TestMethod]
        public void DotProduct()
        {
            Assert.AreEqual(14, new Vect2(1.0, 2.0).DotProduct(new Vect2(4.0, 5.0)), Constants.Delta);
            Assert.AreEqual(0, Vect2.UnitX.DotProduct(Vect2.UnitY));
        }

        [TestMethod]
        public void Addition()
        {
            Assert.AreEqual(new Vect2(7.0, 15.0), new Vect2(3.0, 6.0) + new Vect2(4.0, 9.0));
            Assert.AreEqual(new Vect2(1.0, 15.0), new Vect2(-3.0, 6.0) + new Vect2(4.0, 9.0));
        }

        [TestMethod]
        public void Subtract()
        {
            Assert.AreEqual(new Vect2(-1.0, -3.0), new Vect2(3.0, 6.0) - new Vect2(4.0, 9.0));
            Assert.AreEqual(new Vect2(-7.0, -3.0), new Vect2(-3.0, 6.0) - new Vect2(4.0, 9.0));
        }

        [TestMethod]
        public void Multiply()
        {
            Assert.AreEqual(new Vect2(16.0, 36.0), 4.0 * new Vect2(4.0, 9.0));
            Assert.AreEqual(new Vect2(-8.0, -18.0), -2.0 * new Vect2(4.0, 9.0));
            Assert.AreEqual(new Vect2(16.0, 36.0), new Vect2(4.0, 9.0) * 4.0);
            Assert.AreEqual(new Vect2(-8.0, -18.0), new Vect2(4.0, 9.0) * -2.0);
        }

        [TestMethod]
        public void Divide()
        {
            Assert.AreEqual(new Vect2(2.0, 4.5), new Vect2(4.0, 9.0) / 2);
        }

        [TestMethod]
        public void Equality()
        {
            var a = new Vect2(2.0, 3.0);
            var b = new Vect2(2.0, 3.0);
            var c = new Vect2(3.0, 4.0);
            var d = a;
            Assert.IsTrue(a.Equals(b));
            Assert.IsFalse(a.Equals(c));
            Assert.IsTrue(a.Equals(d));
            Assert.AreEqual(a, b);
            Assert.AreNotEqual(a, c);
            Assert.AreEqual(a, d);
            Assert.IsTrue(a == b);
            Assert.IsTrue(a != c);
            Assert.IsTrue(a != null);
        }
    }
}
