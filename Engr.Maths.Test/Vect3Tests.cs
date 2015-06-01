using System;
using Engr.Maths.Vectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Engr.Maths.Test
{
    [TestClass]
    public class Vect3Tests
    {

        [TestMethod]
        public void CreationFromDoubles()
        {
            var x = 2.0;
            var y = 3.0;
            var z = 5.0;

            var v3 = new Vect3(x, y, z);
            Assert.AreEqual(x, v3.X, Constants.Delta);
            Assert.AreEqual(y, v3.Y, Constants.Delta);
            Assert.AreEqual(z, v3.Z, Constants.Delta);
        }

        [TestMethod]
        public void CreationFromListTooLong()
        {
            try
            {
                var v = new Vect3(new[] { 2.0, 3.0, 5.0, 7.0 });
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
            var z = 5.0;
            var v3 = new Vect3(new[] { x, y, z });
            Assert.AreEqual(x, v3.X, Constants.Delta);
            Assert.AreEqual(y, v3.Y, Constants.Delta);
            Assert.AreEqual(z, v3.Z, Constants.Delta);
        }

        [TestMethod]
        public void LengthResult()
        {
            var v3 = new Vect3(2.0, 3.0, 5.0);
            Assert.AreEqual(38, v3.LengthSquared, Constants.Delta);
            Assert.AreEqual(6.16441400297, v3.Length, Constants.Delta);
        }

        [TestMethod]
        public void NormalisedResult()
        {
            Assert.AreEqual(new Vect3(0.324443, 0.486664, 0.811107), new Vect3(2.0, 3.0, 5.0).Normalize());
        }

        [TestMethod]
        public void StaticDefaults()
        {
            Assert.AreEqual(new Vect3(0.0, 0.0, 0.0), Vect3.Zero);
            Assert.AreEqual(new Vect3(1.0, 0.0, 0.0), Vect3.UnitX);
            Assert.AreEqual(new Vect3(0.0, 1.0, 0.0), Vect3.UnitY);
            Assert.AreEqual(new Vect3(0.0, 0.0, 1.0), Vect3.UnitZ);
        }

        [TestMethod]
        public void DotProduct()
        {
            Assert.AreEqual(32, new Vect3(1.0, 2.0, 3.0).DotProduct(new Vect3(4.0, 5.0, 6.0)), Constants.Delta);

            Assert.AreEqual(0, Vect3.UnitX.DotProduct(Vect3.UnitY));

        }

        [TestMethod]
        public void CrossProduct()
        {
            Assert.AreEqual(new Vect3(-15.0, -2.0, 39.0), new Vect3(3.0, -3.0, 1.0).CrossProduct(new Vect3(4.0, 9.0, 2.0)));
            //same vector should equal zero
            Assert.AreEqual(new Vect3(0, 0, 0), new Vect3(3.0, -3.0, 1.0).CrossProduct(new Vect3(3.0, -3.0, 1.0)));
            //parallel shuold also equal zero
            Assert.AreEqual(new Vect3(0, 0, 0), new Vect3(0, 0, 10.0).CrossProduct(new Vect3(0, 0, -10.0)));
        }



        [TestMethod]
        public void Addition()
        {

            Assert.AreEqual(new Vect3(7.0, 15.0, 11.0), new Vect3(3.0, 6.0, 9.0) + new Vect3(4.0, 9.0, 2.0));
            Assert.AreEqual(new Vect3(1.0, 15.0, 0.0), new Vect3(-3.0, 6.0, 2.0) + new Vect3(4.0, 9.0, -2.0));


        }
        [TestMethod]
        public void Subtract()
        {

            Assert.AreEqual(new Vect3(-1.0, -3.0, 7.0), new Vect3(3.0, 6.0, 9.0) - new Vect3(4.0, 9.0, 2.0));
            Assert.AreEqual(new Vect3(-7.0, -3.0, 4.0), new Vect3(-3.0, 6.0, 2.0) - new Vect3(4.0, 9.0, -2.0));


            Assert.AreEqual(new Vect3(-4.0, -9.0, 2.0), -new Vect3(4.0, 9.0, -2.0));
        }

        [TestMethod]
        public void Multiply()
        {

            Assert.AreEqual(new Vect3(16.0, 36.0, 8.0), 4.0 * new Vect3(4.0, 9.0, 2.0));
            Assert.AreEqual(new Vect3(-8.0, -18.0, 4.0), -2.0 * new Vect3(4.0, 9.0, -2.0));
            Assert.AreEqual(new Vect3(16.0, 36.0, 8.0), new Vect3(4.0, 9.0, 2.0) * 4.0);
            Assert.AreEqual(new Vect3(-8.0, -18.0, 4.0), new Vect3(4.0, 9.0, -2.0) * -2.0);

        }

        [TestMethod]
        public void Divide()
        {

            Assert.AreEqual(new Vect3(2.0, 4.5, 1.0), new Vect3(4.0, 9.0, 2.0) / 2);
        }


        [TestMethod]
        public void Equality()
        {
            var a = new Vect3(2.0, 3.0, 5.0);
            var b = new Vect3(2.0, 3.0, 5.0);
            var c = new Vect3(3.0, 3.0, 6.0);
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
            Assert.AreEqual(new Vect3(2.0, 4.5, 1.0), new Vect3(2.0, 4.5, 1.0).Lerp(new Vect3(4.0, 9.0, 2.0), 0.0));
            Assert.AreEqual(new Vect3(4.0, 9.0, 2.0), new Vect3(2.0, 4.5, 1.0).Lerp(new Vect3(4.0, 9.0, 2.0), 1.0));
            Assert.AreEqual(new Vect3(0.0, 5.0, 0.0), new Vect3(0.0, 0.0, 0.0).Lerp(new Vect3(0.0, 10.0, 0.0), 0.5));
            Assert.AreEqual(new Vect3(0.0, 0.0, 0.0), new Vect3(0.0, -10.0, 0.0).Lerp(new Vect3(0.0, 10.0, 0.0), 0.5));
        }

    }
}