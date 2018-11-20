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
        public void CurvatureTest0()
        {
            Clothoid clothoid = new Clothoid(0, 0, 0, 0, 1, 2);
            var p = clothoid.InterpolateCurvature(1);



        }

        [TestMethod]
        public void DirectionTest0()
        {
            Clothoid clothoid = new Clothoid(0, 0, 0, 0, 1, 2);
            var p = clothoid.InterpolateDirection(1);



        }

    }
}
