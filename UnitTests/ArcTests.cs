using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Curves;

namespace UnitTests
{
    [TestClass]
    public class ArcTests
    {
        [TestMethod]
        public void InterpolationTest0()
        {
            Arc arc = new Arc(0, 0, 0, 1, Math.PI);
            var p = arc.InterpolatePoint2D(1);

            Assert.IsTrue(Helper.DoubleCompare(p.X, 0));
            Assert.IsTrue(Helper.DoubleCompare(p.Y, 2));
        }

        [TestMethod]
        public void InterpolationTest1()
        {
            Arc arc = new Arc(0, 0, 0, -1, Math.PI);
            var p = arc.InterpolatePoint2D(1);

            Assert.IsTrue(Helper.DoubleCompare(p.X, 0));
            Assert.IsTrue(Helper.DoubleCompare(p.Y, -2));
        }

        [TestMethod]
        public void InterpolationTest2()
        {
            Arc arc = new Arc(0, 0, 0, 1, 2 * Math.PI);
            var p = arc.InterpolatePoint2D(1);

            Assert.IsTrue(Helper.DoubleCompare(p.X, 0));
            Assert.IsTrue(Helper.DoubleCompare(p.Y, 0));
        }

        [TestMethod]
        public void DirectionTest0()
        {
            double startDirection = 0;

            Arc arc = new Arc(0, 0, startDirection, 1, Math.PI);
            var endDirection = arc.InterpolateDirection(1);

            Assert.IsTrue(Helper.DoubleCompare(endDirection, Math.PI));
        }

        [TestMethod]
        public void CurvatureTest0()
        {
            double startCurvature = 1;
            Arc arc = new Arc(0, 0, 0, startCurvature, Math.PI);

            var endCurvature = arc.InterpolateCurvature(1);

            Assert.IsTrue(Helper.DoubleCompare(endCurvature, startCurvature));
        }


    }
}
