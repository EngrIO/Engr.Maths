using System;
using Engr.Maths.Vectors;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Engr.Maths.Test
{
    [TestClass]
    public class Vect4Tests
    {
        [TestMethod]
        public void CreationFromDoubles()
        {
            var x = 2.0;
            var y = 3.0;
            var z = 5.0;
            var w = 7.0;

            var v4 = new Vect4(x, y, z, w);
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
                var v = new Vect4(new[] { 2.0, 3.0, 5.0, 7.0, 7.0 });
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
            var w = 7.0;


            var v4 = new Vect4(new[] { x, y, z, w });
            Assert.AreEqual(x, v4.X, Constants.Delta);
            Assert.AreEqual(y, v4.Y, Constants.Delta);
            Assert.AreEqual(z, v4.Z, Constants.Delta);
            Assert.AreEqual(w, v4.W, Constants.Delta);
        }

        [TestMethod]
        public void LengthResult()
        {

            var v4 = new Vect4(2.0, 3.0, 5.0, 7.0);
            Assert.AreEqual(87, v4.LengthSquared, Constants.Delta);
            Assert.AreEqual(9.32737905308, v4.Length, Constants.Delta);
        }

        [TestMethod]
        public void NormalisedResult()
        {

            Assert.AreEqual(new Vect4(0.214423, 0.321634, 0.536056, 0.750479), new Vect4(2.0, 3.0, 5.0, 7.0).Normalize());
        }

        [TestMethod]
        public void StaticDefaults()
        {

            Assert.AreEqual(new Vect4(0.0, 0.0, 0.0, 0.0), Vect4.Zero);
            Assert.AreEqual(new Vect4(1.0, 0.0, 0.0, 0.0), Vect4.UnitX);
            Assert.AreEqual(new Vect4(0.0, 1.0, 0.0, 0.0), Vect4.UnitY);
            Assert.AreEqual(new Vect4(0.0, 0.0, 1.0, 0.0), Vect4.UnitZ);
            Assert.AreEqual(new Vect4(0.0, 0.0, 0.0, 1.0), Vect4.UnitW);
        }

        [TestMethod]
        public void DotProduct()
        {

            Assert.AreEqual(60, new Vect4(1.0, 2.0, 3.0, 4.0).DotProduct(new Vect4(4.0, 5.0, 6.0, 7.0)), Constants.Delta);

            Assert.AreEqual(0, Vect4.UnitX.DotProduct(Vect4.UnitY));
        }


        [TestMethod]
        public void Addition()
        {

            Assert.AreEqual(new Vect4(7.0, 15.0, 11.0, 10.0), new Vect4(3.0, 6.0, 9.0, 7.0) + new Vect4(4.0, 9.0, 2.0, 3.0));
            Assert.AreEqual(new Vect4(1.0, 15.0, 0.0, 7.0), new Vect4(-3.0, 6.0, 2.0, 5.0) + new Vect4(4.0, 9.0, -2.0, 2.0));

        }
        [TestMethod]
        public void Subtract()
        {

            Assert.AreEqual(new Vect4(-1.0, -3.0, 7.0, 6.0), new Vect4(3.0, 6.0, 9.0, 12.0) - new Vect4(4.0, 9.0, 2.0, 6.0));
            Assert.AreEqual(new Vect4(-7.0, -3.0, 4.0, 7.0), new Vect4(-3.0, 6.0, 2.0, 0) - new Vect4(4.0, 9.0, -2.0, -7.0));
            Assert.AreEqual(new Vect4(-4.0, -9.0, 2.0, 6.0), -new Vect4(4.0, 9.0, -2.0, -6.0));
        }

        [TestMethod]
        public void Multiply()
        {


            Assert.AreEqual(new Vect4(16.0, 36.0, 8.0, 8.0), 4.0 * new Vect4(4.0, 9.0, 2.0, 2.0));
            Assert.AreEqual(new Vect4(-8.0, -18.0, 4.0, 8.0), -2.0 * new Vect4(4.0, 9.0, -2.0, -4.0));
            Assert.AreEqual(new Vect4(16.0, 36.0, 8.0, 8.0), new Vect4(4.0, 9.0, 2.0, 2.0) * 4.0);
            Assert.AreEqual(new Vect4(-8.0, -18.0, 4.0, 8.0), new Vect4(4.0, 9.0, -2.0, -4.0) * -2.0);
        }

        [TestMethod]
        public void Divide()
        {

            Assert.AreEqual(new Vect4(2.0, 4.5, 1.0, 32.0), new Vect4(4.0, 9.0, 2.0, 64.0) / 2);
        }



        [TestMethod]
        public void Vect4Equality()
        {
            var a = new Vect4(2.0, 3.0, 5.0, 6.0);
            var b = new Vect4(2.0, 3.0, 5.0, 6.0);
            var c = new Vect4(3.0, 3.0, 6.0, 7.0);
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