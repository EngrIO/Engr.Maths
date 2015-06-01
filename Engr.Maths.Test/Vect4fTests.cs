using System;
using Engr.Maths.Vectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Engr.Maths.Test
{
    [TestClass]
    public class Vect4fTests
    {
        [TestMethod]
        public void CreationFromDoubles()
        {
            var x = 2.0f;
            var y = 3.0f;
            var z = 5.0f;
            var w = 7.0f;

            var v4 = new Vect4f(x, y, z, w);
            Assert.AreEqual(x, v4.X, Constants.Delta);
            Assert.AreEqual(y, v4.Y, Constants.Delta);
            Assert.AreEqual(z, v4.Z, Constants.Delta);
            Assert.AreEqual(w, v4.W, Constants.Delta);
        }

        [TestMethod]
        public void CreationFromListTooLong()
        {

            try
            {
                var v = new Vect4f(new[] { 2.0f, 3.0f, 5.0f, 7.0f, 7.0f});
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
            var z = 5.0f;
            var w = 7.0f;


            var v4 = new Vect4f(new[] { x, y, z, w });
            Assert.AreEqual(x, v4.X, Constants.Delta);
            Assert.AreEqual(y, v4.Y, Constants.Delta);
            Assert.AreEqual(z, v4.Z, Constants.Delta);
            Assert.AreEqual(w, v4.W, Constants.Delta);
        }

        [TestMethod]
        public void LengthResult()
        {

            var v4 = new Vect4f(2.0f, 3.0f, 5.0f, 7.0f);
            Assert.AreEqual(87, v4.LengthSquared, Constants.Delta);
            Assert.AreEqual(9.32737922668457, v4.Length, Constants.Delta);
        }

        [TestMethod]
        public void NormalisedResult()
        {

            Assert.AreEqual(new Vect4f(0.214423f, 0.321634f, 0.536056f, 0.750479f), new Vect4f(2.0f, 3.0f, 5.0f, 7.0f).Normalize());
        }

        [TestMethod]
        public void StaticDefaults()
        {

            Assert.AreEqual(new Vect4f(0.0f, 0.0f, 0.0f, 0.0f), Vect4f.Zero);
            Assert.AreEqual(new Vect4f(1.0f, 0.0f, 0.0f, 0.0f), Vect4f.UnitX);
            Assert.AreEqual(new Vect4f(0.0f, 1.0f, 0.0f, 0.0f), Vect4f.UnitY);
            Assert.AreEqual(new Vect4f(0.0f, 0.0f, 1.0f, 0.0f), Vect4f.UnitZ);
            Assert.AreEqual(new Vect4f(0.0f, 0.0f, 0.0f, 1.0f), Vect4f.UnitW);
        }

        [TestMethod]
        public void DotProduct()
        {

            Assert.AreEqual(60, new Vect4f(1.0f, 2.0f, 3.0f, 4.0f).DotProduct(new Vect4f(4.0f, 5.0f, 6.0f, 7.0f)), Constants.Delta);

            Assert.AreEqual(0, Vect4f.UnitX.DotProduct(Vect4f.UnitY));
        }


        [TestMethod]
        public void Addition()
        {

            Assert.AreEqual(new Vect4f(7.0f, 15.0f, 11.0f, 10.0f), new Vect4f(3.0f, 6.0f, 9.0f, 7.0f) + new Vect4f(4.0f, 9.0f, 2.0f, 3.0f));
            Assert.AreEqual(new Vect4f(1.0f, 15.0f, 0.0f, 7.0f), new Vect4f(-3.0f, 6.0f, 2.0f, 5.0f) + new Vect4f(4.0f, 9.0f, -2.0f, 2.0f));

        }
        [TestMethod]
        public void Subtract()
        {

            Assert.AreEqual(new Vect4f(-1.0f, -3.0f, 7.0f, 6.0f), new Vect4f(3.0f, 6.0f, 9.0f, 12.0f) - new Vect4f(4.0f, 9.0f, 2.0f, 6.0f));
            Assert.AreEqual(new Vect4f(-7.0f, -3.0f, 4.0f, 7.0f), new Vect4f(-3.0f, 6.0f, 2.0f, 0f) - new Vect4f(4.0f, 9.0f, -2.0f, -7.0f));
            Assert.AreEqual(new Vect4f(-4.0f, -9.0f, 2.0f, 6.0f), -new Vect4f(4.0f, 9.0f, -2.0f, -6.0f));
        }

        [TestMethod]
        public void Multiply()
        {


            Assert.AreEqual(new Vect4f(16.0f, 36.0f, 8.0f, 8.0f), 4.0f * new Vect4f(4.0f, 9.0f, 2.0f, 2.0f));
            Assert.AreEqual(new Vect4f(-8.0f, -18.0f, 4.0f, 8.0f), -2.0f * new Vect4f(4.0f, 9.0f, -2.0f, -4.0f));
            Assert.AreEqual(new Vect4f(16.0f, 36.0f, 8.0f, 8.0f), new Vect4f(4.0f, 9.0f, 2.0f, 2.0f) * 4.0f);
            Assert.AreEqual(new Vect4f(-8.0f, -18.0f, 4.0f, 8.0f), new Vect4f(4.0f, 9.0f, -2.0f, -4.0f) * -2.0f);
        }

        [TestMethod]
        public void Divide()
        {

            Assert.AreEqual(new Vect4f(2.0f, 4.5f, 1.0f, 32.0f), new Vect4f(4.0f, 9.0f, 2.0f, 64.0f) / 2f);
        }



        [TestMethod]
        public void Vect4fEquality()
        {
            var a = new Vect4f(2.0f, 3.0f, 5.0f, 6.0f);
            var b = new Vect4f(2.0f, 3.0f, 5.0f, 6.0f);
            var c = new Vect4f(3.0f, 3.0f, 6.0f, 7.0f);
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