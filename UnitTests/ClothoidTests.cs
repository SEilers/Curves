using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Curves;

namespace UnitTests
{
    [TestClass]
    public class ClothoidUnitTests
    {
        [TestMethod]
        public void InterpolationTest()
        {
            Clothoid clothoid = new Clothoid(0, 0, 0, 0, 1, 2);
            var p = clothoid.InterpolatePoint2D(1);
            Console.WriteLine(p.ToString());
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

    }
}
