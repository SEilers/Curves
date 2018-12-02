using System;
using System.Collections.Generic;
using System.Text;

namespace Curves
{
    public static class Geometry
    {
        /// <summary>
        /// Line from Vector a and b. Calculates, if a point p is left or right 
        /// of this line.
        ///  0: p is on the line
        /// -1: p is right 
        ///  1: p is left
        /// </summary>
        /// <param name="a">Point a of line</param>
        /// <param name="b">Point b of line</param>
        /// <param name="p">Point to ceck</param>
        /// <returns> 0 if p is on the line
        ///          -1 if point is on the right side 
        ///           1 if p is on the left side</returns>
        public static int PointOnSideOfLine(Point2D a, Point2D b, Point2D p)
        {
            double det = (b.X - a.X) * (p.Y - a.Y) - (b.Y - a.Y) * (p.X - a.X);
            return Math.Sign(det);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lP0"></param>
        /// <param name="lP1"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static double DistancePointToLine(Point2D lP0, Point2D lP1, Point2D p)
        {
            Point2D v = lP1 - lP0;
            Point2D w = p - lP0;

            double c1 = Point2D.Dot(w, v);
            double c2 = Point2D.Dot(v, v);
            double b = c1 / c2;

            Point2D Pb = lP0 + b * v;
            return Point2D.Distance(p, Pb);
        }
    }
}
