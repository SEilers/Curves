using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Curves;

namespace UnitTests
{
    [TestClass]
    public class ArcTests
    {
        [TestMethod]
        public void TranslationTest0()
        {
            Arc arc = new Arc(1, 1, 0, 1, Math.PI);
            var p = arc.InterpolatePoint2D(1);

            Assert.IsTrue(Helper.DoubleCompare(p.X, 1));
            Assert.IsTrue(Helper.DoubleCompare(p.Y, 3));
        }

        [TestMethod]
        public void TranslationTest1()
        {
            Arc arc = new Arc(1, 1, 0, -1, Math.PI);
            var p = arc.InterpolatePoint2D(1);

            Assert.IsTrue(Helper.DoubleCompare(p.X, 1));
            Assert.IsTrue(Helper.DoubleCompare(p.Y, -1));
        }

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

        [TestMethod]
        public void FromPoseAndPointTest0()
        {
            Arc arc = Arc.FromPoseAndPoint(0, 0, 0, 1, 1);
            var curvature = arc.EndCurvature;
            var length = arc.Length;
            var endPoint = arc.InterpolatePoint2D(1);
            Assert.IsTrue(Helper.DoubleCompare(curvature, 1));
            Assert.IsTrue(Helper.DoubleCompare(length, Math.PI/2 ));
            Assert.IsTrue(Helper.DoubleCompare(endPoint.X, 1));
            Assert.IsTrue(Helper.DoubleCompare(endPoint.Y, 1));
        }

        [TestMethod]
        public void FromPoseAndPointTest1()
        {
            Arc arc = Arc.FromPoseAndPoint(0, 0, 0, 0, 2);
            var curvature = arc.EndCurvature;
            var length = arc.Length;
            var endPoint = arc.InterpolatePoint2D(1);
            Assert.IsTrue(Helper.DoubleCompare(curvature, 1));
            Assert.IsTrue(Helper.DoubleCompare(length, Math.PI));
            Assert.IsTrue(Helper.DoubleCompare(endPoint.X, 0));
            Assert.IsTrue(Helper.DoubleCompare(endPoint.Y, 2));
        }

        [TestMethod]
        public void FromPoseAndPointTest2()
        {
            Arc arc = Arc.FromPoseAndPoint(0, 0, 0, 1, -1);
            var curvature = arc.EndCurvature;
            var length = arc.Length;
            var endPoint = arc.InterpolatePoint2D(1);
            Assert.IsTrue(Helper.DoubleCompare(curvature, -1));
            Assert.IsTrue(Helper.DoubleCompare(length, Math.PI / 2));
            Assert.IsTrue(Helper.DoubleCompare(endPoint.X, 1));
            Assert.IsTrue(Helper.DoubleCompare(endPoint.Y, -1));
        }

        [TestMethod]
        public void FromPoseAndPointTest3()
        {
            Arc arc = Arc.FromPoseAndPoint(0, 0, 0, 0, -2);
            var curvature = arc.EndCurvature;
            var length = arc.Length;
            var endPoint = arc.InterpolatePoint2D(1);
            Assert.IsTrue(Helper.DoubleCompare(curvature, -1));
            Assert.IsTrue(Helper.DoubleCompare(length, Math.PI));
            Assert.IsTrue(Helper.DoubleCompare(endPoint.X, 0));
            Assert.IsTrue(Helper.DoubleCompare(endPoint.Y, -2));
        }

        [TestMethod]
        public void FromPoseAndPointTest4()
        {
            Arc arc = Arc.FromPoseAndPoint(1, 1, 0, 2, 2);
            var curvature = arc.EndCurvature;
            var length = arc.Length;
            var endPoint = arc.InterpolatePoint2D(1);
            Assert.IsTrue(Helper.DoubleCompare(curvature, 1));
            Assert.IsTrue(Helper.DoubleCompare(length, Math.PI / 2));
            Assert.IsTrue(Helper.DoubleCompare(endPoint.X, 2));
            Assert.IsTrue(Helper.DoubleCompare(endPoint.Y, 2));
        }

        [TestMethod]
        public void FromPoseAndPointTest5()
        {
            Arc arc = Arc.FromPoseAndPoint(1, 1, 0, 1, 3);
            var curvature = arc.EndCurvature;
            var length = arc.Length;
            var endPoint = arc.InterpolatePoint2D(1);
            Assert.IsTrue(Helper.DoubleCompare(curvature, 1));
            Assert.IsTrue(Helper.DoubleCompare(length, Math.PI));
            Assert.IsTrue(Helper.DoubleCompare(endPoint.X, 1));
            Assert.IsTrue(Helper.DoubleCompare(endPoint.Y, 3));
        }


    }
}
