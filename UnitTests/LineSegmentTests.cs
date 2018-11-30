using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Curves;

namespace UnitTests
{
    [TestClass]
    public class LineSegmentUnitTests
    {
        [TestMethod]
        public void InterpolationTest0()
        {
            LineSegment lineSegment = new LineSegment(0, 0, 0, 2);

            var p = lineSegment.InterpolatePoint2D(1);

            Assert.IsTrue(Helper.DoubleCompare(p.X, 2.0));
        }

        [TestMethod]
        public void InterpolationTest1()
        {
            LineSegment lineSegment = new LineSegment(2, 2, 0, 2);

            var p = lineSegment.InterpolatePoint2D(1);

            Assert.IsTrue(Helper.DoubleCompare(p.X, 4.0));
            Assert.IsTrue(Helper.DoubleCompare(p.Y, 2.0));
        }

        [TestMethod]
        public void InterpolationTest3()
        {
            double direction = Angle.DegreeToRadians(90);
            LineSegment lineSegment = new LineSegment(2, 2, direction, 2);
            var p = lineSegment.InterpolatePoint2D(1);

            Assert.IsTrue(Helper.DoubleCompare(p.X, 2.0));
            Assert.IsTrue(Helper.DoubleCompare(p.Y, 4.0));
        }

        [TestMethod]
        public void CurvatureTest0()
        {
            double direction = Angle.DegreeToRadians(90);
            LineSegment lineSegment = new LineSegment(2, 2, direction, 2);

            var p = lineSegment.InterpolatePoint2D(1);
            double curvature = lineSegment.InterpolateCurvature(1);

            Assert.IsTrue(Helper.DoubleCompare(curvature, 0));
        }

        [TestMethod]
        public void CurvatureTest1()
        {
            LineSegment lineSegment = new LineSegment(0, 0, 0, 2);
            double curvature = lineSegment.InterpolateCurvature(1);
            Assert.IsTrue(Helper.DoubleCompare(curvature, 0));
        }

        [TestMethod]
        public void CurvatureTest2()
        {
            LineSegment lineSegment = new LineSegment(0, 0, 0, 2);
            double curvature = lineSegment.InterpolateCurvature(0.5);
            Assert.IsTrue(Helper.DoubleCompare(curvature, 0));
        }

        [TestMethod]
        public void CurvatureTest3()
        {
            LineSegment lineSegment = new LineSegment(0, 0, 0, 2);
            double curvature = lineSegment.CalculateCurvature(2);
            Assert.IsTrue(Helper.DoubleCompare(curvature, 0));
        }

        [TestMethod]
        public void CurvatureTest4()
        {
            LineSegment lineSegment = new LineSegment(0, 0, 0, 2);
            double curvature = lineSegment.CalculateCurvature(1);
            Assert.IsTrue(Helper.DoubleCompare(curvature, 0));
        }

        [TestMethod]
        public void CurvatureTest5()
        {
            LineSegment lineSegment = new LineSegment(0, 0, 0, 2);
            double curvature = lineSegment.EndCurvature;
            Assert.IsTrue(Helper.DoubleCompare(curvature, 0));
        }

        [TestMethod]
        public void DirectionTest0()
        {
            double startDirection = Angle.DegreeToRadians(90);
            LineSegment lineSegment = new LineSegment(2, 2, startDirection, 2);

            var p = lineSegment.InterpolatePoint2D(1);
            double endDirection = lineSegment.InterpolateDirection(1);


            Assert.IsTrue(Helper.DoubleCompare(endDirection, startDirection));
        }

        [TestMethod]
        public void GetPointsTest0()
        {
            LineSegment lineSegment = new LineSegment(0, 0, 0, 5);
            var pl = lineSegment.GetPoints(2);
            Assert.IsTrue(Helper.DoubleCompare(pl[1].X, 5));
        }

        [TestMethod]
        public void GetPointsTest1()
        {
            LineSegment lineSegment = new LineSegment(0, 0, 0, 5);
            var pl = lineSegment.GetPoints(11);
            Assert.IsTrue(pl.Count == 11);
        }

        [TestMethod]
        public void GetPointsTest2()
        {
            LineSegment lineSegment = new LineSegment(0, 0, 0, 5);
            var pl = lineSegment.GetPoints(21);
            Assert.IsTrue(pl.Count == 21);
        }
    }
}
