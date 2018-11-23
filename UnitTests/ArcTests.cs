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
        public void GetPointsTest0()
        {
            double startCurvature = 0;
            Arc arc = new Arc(0, 0, 0, startCurvature, 5);
            var pl = arc.GetPoints(11);
            Assert.IsTrue(pl.Count == 11);
        }

        [TestMethod]
        public void GetPointsTest1()
        {
            double startCurvature = 0;
            Arc arc = new Arc(0, 0, 0, startCurvature, 5);
            var pl = arc.GetPoints(11);
            Assert.IsTrue(Helper.DoubleCompare(pl[10].X, 5));
        }

        [TestMethod]
        public void GetPointsTest2()
        {
            double startCurvature = 0;
            Arc arc = new Arc(0, 0, 0, startCurvature, 5);
            var pl = arc.GetPoints(2);
            Assert.IsTrue(pl.Count == 2);
        }

        [TestMethod]
        public void GetPointsTest3()
        {
            double startCurvature = 0;
            Arc arc = new Arc(0, 0, 0, startCurvature, 5);
            var pl = arc.GetPoints(2);
            Assert.IsTrue(Helper.DoubleCompare(pl[1].X, 5));
        }

        [TestMethod]
        public void GetPointsTest4()
        {
            double startCurvature = 1;
            Arc arc = new Arc(0, 0, 0, startCurvature, Math.PI);
            var pl = arc.GetPoints(11);
            Assert.IsTrue(pl.Count == 11);
            Assert.IsTrue(Helper.DoubleCompare(pl[10].X, 0));
            Assert.IsTrue(Helper.DoubleCompare(pl[10].Y, 2));
        }

        [TestMethod]
        public void CurvatureTest0()
        {
            double startCurvature = 1;
            Arc arc = new Arc(0, 0, 0, startCurvature, Math.PI);
            double endCurvature = arc.EndCurvature;
            Assert.IsTrue(Helper.DoubleCompare(startCurvature, endCurvature));
        }

        [TestMethod]
        public void CurvatureTest1()
        {
            double startCurvature = 1;
            Arc arc = new Arc(0, 0, 0, startCurvature, Math.PI);
            var endCurvature = arc.InterpolateCurvature(1);
            Assert.IsTrue(Helper.DoubleCompare(endCurvature, startCurvature));
        }

        [TestMethod]
        public void CurvatureTest2()
        {
            double startCurvature = -1;
            Arc arc = new Arc(0, 0, 0, startCurvature, Math.PI);
            var endCurvature = arc.InterpolateCurvature(1);
            Assert.IsTrue(Helper.DoubleCompare(endCurvature, startCurvature));
        }

        [TestMethod]
        public void CurvatureTest3()
        {
            double startCurvature = 1;
            Arc arc = new Arc(0, 0, 0, startCurvature, Math.PI);
            var endCurvature = arc.CalculateCurvature(Math.PI);
            Assert.IsTrue(Helper.DoubleCompare(endCurvature, startCurvature));
        }

        [TestMethod]
        public void CurvatureTest4()
        {
            double startCurvature = -1;
            Arc arc = new Arc(0, 0, 0, startCurvature, Math.PI);
            var endCurvature = arc.CalculateCurvature(Math.PI);
            Assert.IsTrue(Helper.DoubleCompare(endCurvature, startCurvature));
        }


    }
}
