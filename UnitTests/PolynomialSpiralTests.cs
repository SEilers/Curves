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
            PolynomialSpiral lineSegment = new PolynomialSpiral(0, 0, 0, new double[] { 0, 0, 0 }, 2);
            var p = lineSegment.InterpolatePoint2D(1);
            Assert.IsTrue(Helper.DoubleCompare(p.X, 2.0));
        }

        [TestMethod]
        public void InterpolationTest1()
        {
            PolynomialSpiral arc = new PolynomialSpiral(0, 0, 0, new double[] { 1, 0, 0 }, Math.PI);
            var p = arc.InterpolatePoint2D(1);
            Assert.IsTrue(Helper.DoubleCompare(p.Y, 2.0));
        }
    }
}
