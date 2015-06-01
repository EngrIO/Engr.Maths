using System;
using Engr.Maths.Vectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Engr.Maths.Test
{
    [TestClass]
    public class Vect3fTests
    {

        [TestMethod]
        public void CreationFromDoubles()
        {
            var x = 2.0f;
            var y = 3.0f;
            var z = 5.0f;

            var v3 = new Vect3f(x, y, z);
            Assert.AreEqual(x, v3.X, Constants.Delta);
            Assert.AreEqual(y, v3.Y, Constants.Delta);
            Assert.AreEqual(z, v3.Z, Constants.Delta);
        }

        [TestMethod]
        public void CreationFromListTooLong()
        {
            try
            {
                var v = new Vect3f(new[] { 2.0f, 3.0f, 5.0f, 7.0f });
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
            var v3 = new Vect3f(new[] { x, y, z });
            Assert.AreEqual(x, v3.X, Constants.Delta);
            Assert.AreEqual(y, v3.Y, Constants.Delta);
            Assert.AreEqual(z, v3.Z, Constants.Delta);
        }

        [TestMethod]
        public void LengthResult()
        {
            var v3 = new Vect3f(2.0f, 3.0f, 5.0f);
            Assert.AreEqual(38, v3.LengthSquared, Constants.Delta);
            Assert.AreEqual(6.1644139289856, v3.Length, Constants.Delta);
        }

        [TestMethod]
        public void NormalisedResult()
        {
            Assert.AreEqual(new Vect3f(0.324443f, 0.486664f, 0.811107f), new Vect3f(2.0f, 3.0f, 5.0f).Normalize());
        }

        [TestMethod]
        public void StaticDefaults()
        {
            Assert.AreEqual(new Vect3f(0.0f, 0.0f, 0.0f), Vect3f.Zero);
            Assert.AreEqual(new Vect3f(1.0f, 0.0f, 0.0f), Vect3f.UnitX);
            Assert.AreEqual(new Vect3f(0.0f, 1.0f, 0.0f), Vect3f.UnitY);
            Assert.AreEqual(new Vect3f(0.0f, 0.0f, 1.0f), Vect3f.UnitZ);
        }

        [TestMethod]
        public void DotProduct()
        {
            Assert.AreEqual(32, new Vect3f(1.0f, 2.0f, 3.0f).DotProduct(new Vect3f(4.0f, 5.0f, 6.0f)), Constants.Delta);

            Assert.AreEqual(0, Vect3f.UnitX.DotProduct(Vect3f.UnitY));

        }

        [TestMethod]
        public void CrossProduct()
        {
            Assert.AreEqual(new Vect3f(-15.0f, -2.0f, 39.0f), new Vect3f(3.0f, -3.0f, 1.0f).CrossProduct(new Vect3f(4.0f, 9.0f, 2.0f)));
            //same vector should equal zero
            Assert.AreEqual(new Vect3f(0, 0, 0), new Vect3f(3.0f, -3.0f, 1.0f).CrossProduct(new Vect3f(3.0f, -3.0f, 1.0f)));
            //parallel shuold also equal zero
            Assert.AreEqual(new Vect3f(0, 0, 0), new Vect3f(0, 0, 10.0f).CrossProduct(new Vect3f(0, 0, -10.0f)));
        }



        [TestMethod]
        public void Addition()
        {

            Assert.AreEqual(new Vect3f(7.0f, 15.0f, 11.0f), new Vect3f(3.0f, 6.0f, 9.0f) + new Vect3f(4.0f, 9.0f, 2.0f));
            Assert.AreEqual(new Vect3f(1.0f, 15.0f, 0.0f), new Vect3f(-3.0f, 6.0f, 2.0f) + new Vect3f(4.0f, 9.0f, -2.0f));

        }

        [TestMethod]
        public void Subtract()
        {

            Assert.AreEqual(new Vect3f(-1.0f, -3.0f, 7.0f), new Vect3f(3.0f, 6.0f, 9.0f) - new Vect3f(4.0f, 9.0f, 2.0f));
            Assert.AreEqual(new Vect3f(-7.0f, -3.0f, 4.0f), new Vect3f(-3.0f, 6.0f, 2.0f) - new Vect3f(4.0f, 9.0f, -2.0f));


            Assert.AreEqual(new Vect3f(-4.0f, -9.0f, 2.0f), -new Vect3f(4.0f, 9.0f, -2.0f));
        }

        [TestMethod]
        public void Multiply()
        {

            Assert.AreEqual(new Vect3f(16.0f, 36.0f, 8.0f), 4.0f * new Vect3f(4.0f, 9.0f, 2.0f));
            Assert.AreEqual(new Vect3f(-8.0f, -18.0f, 4.0f), -2.0f * new Vect3f(4.0f, 9.0f, -2.0f));
            Assert.AreEqual(new Vect3f(16.0f, 36.0f, 8.0f), new Vect3f(4.0f, 9.0f, 2.0f) * 4.0f);
            Assert.AreEqual(new Vect3f(-8.0f, -18.0f, 4.0f), new Vect3f(4.0f, 9.0f, -2.0f) * -2.0f);

        }

        [TestMethod]
        public void Divide()
        {

            Assert.AreEqual(new Vect3f(2.0f, 4.5f, 1.0f), new Vect3f(4.0f, 9.0f, 2.0f) / 2f);
        }


        [TestMethod]
        public void Equality()
        {
            var a = new Vect3f(2.0f, 3.0f, 5.0f);
            var b = new Vect3f(2.0f, 3.0f, 5.0f);
            var c = new Vect3f(3.0f, 3.0f, 6.0f);
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


        [TestMethod]
        public void Lerp()
        {
            Assert.AreEqual(new Vect3f(2.0f, 4.5f, 1.0f), new Vect3f(2.0f, 4.5f, 1.0f).Lerp(new Vect3f(4.0f, 9.0f, 2.0f), 0.0f));
            Assert.AreEqual(new Vect3f(4.0f, 9.0f, 2.0f), new Vect3f(2.0f, 4.5f, 1.0f).Lerp(new Vect3f(4.0f, 9.0f, 2.0f), 1.0f));
            Assert.AreEqual(new Vect3f(0.0f, 5.0f, 0.0f), new Vect3f(0.0f, 0.0f, 0.0f).Lerp(new Vect3f(0.0f, 10.0f, 0.0f), 0.5f));
            Assert.AreEqual(new Vect3f(0.0f, 0.0f, 0.0f), new Vect3f(0.0f, -10.0f, 0.0f).Lerp(new Vect3f(0.0f, 10.0f, 0.0f), 0.5f));
        }

    }
}