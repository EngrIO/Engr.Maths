using System;
using Engr.Maths.Vectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Engr.Maths.Test
{
    [TestClass]
    public class Vect2fTests
    {
        [TestMethod]
        public void CreationFromDoubles()
        {
            var x = 2.0f;
            var y = 3.0f;
            var v2 = new Vect2f(x, y);
            Assert.AreEqual(x, v2.X, Constants.Delta);
            Assert.AreEqual(y, v2.Y, Constants.Delta);
        }

        [TestMethod]
        public void CreationFromListTooLong()
        {
            try
            {
                var v = new Vect2f(new[] { 2.0f, 3.0f, 5.0f });
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
            var x = 2.0f;
            var y = 3.0f;
            var v2 = new Vect2f(new[] { x, y });
            Assert.AreEqual(x, v2.X, Constants.Delta);
            Assert.AreEqual(y, v2.Y, Constants.Delta);
        }

        [TestMethod]
        public void LengthResult()
        {
            var v2 = new Vect2f(2.0f, 3.0f);
            Assert.AreEqual(13.0, v2.LengthSquared, Constants.Delta);
            Assert.AreEqual(3.60555124282837, v2.Length, Constants.Delta);
        }

        [TestMethod]
        public void NormalisedResult()
        {
            Assert.AreEqual(new Vect2f(0.5547f, 0.83205f), new Vect2f(2.0f, 3.0f).Normalize());
        }

        [TestMethod]
        public void StaticDefaults()
        {
            Assert.AreEqual(new Vect2f(0.0f, 0.0f), Vect2f.Zero);
            Assert.AreEqual(new Vect2f(1.0f, 0.0f), Vect2f.UnitX);
            Assert.AreEqual(new Vect2f(0.0f, 1.0f), Vect2f.UnitY);
        }

        [TestMethod]
        public void DotProduct()
        {
            Assert.AreEqual(14, new Vect2f(1.0f, 2.0f).DotProduct(new Vect2f(4.0f, 5.0f)), Constants.Delta);
            Assert.AreEqual(0, Vect2f.UnitX.DotProduct(Vect2f.UnitY));
        }

        [TestMethod]
        public void Addition()
        {
            Assert.AreEqual(new Vect2f(7.0f, 15.0f), new Vect2f(3.0f, 6.0f) + new Vect2f(4.0f, 9.0f));
            Assert.AreEqual(new Vect2f(1.0f, 15.0f), new Vect2f(-3.0f, 6.0f) + new Vect2f(4.0f, 9.0f));
        }

        [TestMethod]
        public void Subtract()
        {
            Assert.AreEqual(new Vect2f(-1.0f, -3.0f), new Vect2f(3.0f, 6.0f) - new Vect2f(4.0f, 9.0f));
            Assert.AreEqual(new Vect2f(-7.0f, -3.0f), new Vect2f(-3.0f, 6.0f) - new Vect2f(4.0f, 9.0f));
        }

        [TestMethod]
        public void Multiply()
        {
            Assert.AreEqual(new Vect2f(16.0f, 36.0f), 4.0f * new Vect2f(4.0f, 9.0f));
            Assert.AreEqual(new Vect2f(-8.0f, -18.0f), -2.0f * new Vect2f(4.0f, 9.0f));
            Assert.AreEqual(new Vect2f(16.0f, 36.0f), new Vect2f(4.0f, 9.0f) * 4.0f);
            Assert.AreEqual(new Vect2f(-8.0f, -18.0f), new Vect2f(4.0f, 9.0f) * -2.0f);
        }

        [TestMethod]
        public void Divide()
        {
            Assert.AreEqual(new Vect2f(2.0f, 4.5f), new Vect2f(4.0f, 9.0f) / 2);
        }

        [TestMethod]
        public void Equality()
        {
            var a = new Vect2f(2.0f, 3.0f);
            var b = new Vect2f(2.0f, 3.0f);
            var c = new Vect2f(3.0f, 4.0f);
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
