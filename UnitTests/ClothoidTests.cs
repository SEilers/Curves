using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Curves;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace UnitTests
{
    [TestClass]
    public class ClothoidUnitTests
    {
        [TestMethod]
        public void InterpolationTest0()
        {
            Clothoid clothoid = new Clothoid(0, 0, 0, 0, 1, 2);
            var p = clothoid.InterpolatePoint2D(1);
            Console.WriteLine(p.ToString());
        }

        [TestMethod]
        public void InterpolationTest1()
        {
            Clothoid cl = new Clothoid(0, 0, 0, 0, 1, 1);
            Pose2D endPose = cl.InterpolatePose2D(1);
            double direction = endPose.Direction;
            double curvature = cl.InterpolateCurvature(1);

            Assert.IsTrue(Helper.DoubleCompare(direction, 0.5));
            Assert.IsTrue(Helper.DoubleCompare(curvature, 1));
        }


        [TestMethod]
        public void DirectionTest0()
        {
            Clothoid clothoid = new Clothoid(0, 0, 0, 0, 1, 2);
            var p = clothoid.InterpolateDirection(1);
        }

       

        [TestMethod]
        public void GetPointsTest0()
        {
            Clothoid clothoid = new Clothoid(0, 0, 0, 0, 10000, 5);
            var pl = clothoid.GetPoints(2);
            Assert.IsTrue(pl.Count == 2);
        }

        [TestMethod]
        public void GetPointsTest1()
        {
            Clothoid clothoid = new Clothoid(0, 0, 0, 0, 10000, 5);
            var pl = clothoid.GetPoints(11);
            Assert.IsTrue(pl.Count == 11);
        }

        [TestMethod]
        public void GetPointsTest2()
        {
            Clothoid clothoid = new Clothoid(0, 0, 0, 0, 10000, 5);
            var pl = clothoid.GetPoints(2);
            Assert.IsTrue(Helper.DoubleCompare(pl[1].X, 5));
        }

        [TestMethod]
        public void CurvatureTest0()
        {
            double startCurvature = 0;
            Clothoid clothoid = new Clothoid(0, 0, 0, startCurvature, 1, Math.PI);
            double endCurvature = clothoid.EndCurvature;
            Assert.IsTrue(Helper.DoubleCompare(Math.PI, endCurvature));
        }

        [TestMethod]
        public void CurvatureTest1()
        {
            double startCurvature = 0;
            Clothoid clothoid = new Clothoid(0, 0, 0, startCurvature, -1, Math.PI);
            double endCurvature = clothoid.EndCurvature;
            Assert.IsTrue(Helper.DoubleCompare(-Math.PI, endCurvature));
        }

        [TestMethod]
        public void CurvatureTest2()
        {
            double startCurvature = 0;
            Clothoid clothoid = new Clothoid(0, 0, 0, startCurvature, 1, Math.PI);
            double endCurvature = clothoid.InterpolateCurvature(0.5);
            Assert.IsTrue(Helper.DoubleCompare(Math.PI/2, endCurvature));
        }

        [TestMethod]
        public void CurvatureTest3()
        {
            double startCurvature = 0;
            Clothoid clothoid = new Clothoid(0, 0, 0, startCurvature, -1, Math.PI);
            double endCurvature = clothoid.InterpolateCurvature(0.5);
            Assert.IsTrue(Helper.DoubleCompare(-Math.PI/2, endCurvature));
        }

        [TestMethod]
        public void CurvatureTest4()
        {
            double startCurvature = 0;
            Clothoid clothoid = new Clothoid(0, 0, 0, startCurvature, 1, Math.PI);
            double endCurvature = clothoid.CalculateCurvature(Math.PI / 2);
            Assert.IsTrue(Helper.DoubleCompare(Math.PI / 2, endCurvature));
        }

        [TestMethod]
        public void CurvatureTest5()
        {
            double startCurvature = 0;
            Clothoid clothoid = new Clothoid(0, 0, 0, startCurvature, -1, Math.PI);
            double endCurvature = clothoid.CalculateCurvature(Math.PI / 2);
            Assert.IsTrue(Helper.DoubleCompare(-Math.PI / 2, endCurvature));
        }

        [TestMethod]
        public void FromPoseAndPointTest0()
        {
            Clothoid clothoid = Clothoid.FromPoseAndPoint(0, 0, 0, 2, 1);
            if( clothoid != null )
            {
                Point2D endPoint = clothoid.InterpolatePoint2D(1);
                double length = clothoid.Length;
                double A = clothoid.A;
                Assert.IsTrue(Helper.DoubleCompare(2, endPoint.X));
                Assert.IsTrue(Helper.DoubleCompare(1, endPoint.Y));
            }
        }

        [TestMethod]
        public void FromPoseAndPointTest1()
        {
            Clothoid clothoid = Clothoid.FromPoseAndPoint(1, 1, 0, 3, 2);
            if (clothoid != null)
            {
                Point2D endPoint = clothoid.InterpolatePoint2D(1);
                double length = clothoid.Length;
                double A = clothoid.A;
                Assert.IsTrue(Helper.DoubleCompare(3, endPoint.X));
                Assert.IsTrue(Helper.DoubleCompare(2, endPoint.Y));
            }
        }


        

       



    }
}
