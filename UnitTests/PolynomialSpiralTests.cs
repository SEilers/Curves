using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Curves;

namespace UnitTests
{
    [TestClass]
    public class PolynomialSpiralUnitTests
    {
        [TestMethod]
        public void InterpolationTest0()
        {
            PolynomialSpiral polynomialSpiral = new PolynomialSpiral(0, 0, 0, new double[] { 0, 0, 0 }, 2);
            var p = polynomialSpiral.InterpolatePoint2D(1);
            Assert.IsTrue(Helper.DoubleCompare(p.X, 2.0));
        }

        [TestMethod]
        public void InterpolationTest1()
        {
            PolynomialSpiral polynomialSpiral = new PolynomialSpiral(0, 0, 0, new double[] { 1, 0, 0 }, Math.PI);
            var p = polynomialSpiral.InterpolatePoint2D(1);
            Assert.IsTrue(Helper.DoubleCompare(p.Y, 2.0));
        }

        [TestMethod]
        public void GetPointsTest0()
        {
            PolynomialSpiral polynomialSpiral = new PolynomialSpiral(0, 0, 0, new double[] { 0, 0, 0 }, 5);
            var pl = polynomialSpiral.GetPoints(11);
            Assert.IsTrue(pl.Count == 11);
        }

        [TestMethod]
        public void GetPointsTest1()
        {
            PolynomialSpiral polynomialSpiral = new PolynomialSpiral(0, 0, 0, new double[] { 0, 0, 0 }, 5);
            var pl = polynomialSpiral.GetPoints(2);
            Assert.IsTrue(pl.Count == 2);
        }
    }
}
