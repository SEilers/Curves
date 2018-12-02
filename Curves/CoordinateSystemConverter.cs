using System;
using System.Collections.Generic;
using System.Text;

namespace Curves
{
    public static class CoordinateSystemConverter
    {
        public static Point2D ToPoseCoordinateSystem(double poseX, double poseY, double poseDirection, double px, double py)
        {
            Point2D result;

            double dirX = Math.Cos(poseDirection);
            double dirY = Math.Sin(poseDirection);

            double dx = px - poseX;
            double dy = py - poseY;

            double numerator = dx * dirX + dy * dirY;
            double denominator = dirX * dirX + dirY * dirY;

            double u = numerator / denominator;

            double xpx = dirX * u;
            double xpy = dirY * u;

            double x = Math.Sqrt(xpx * xpx + xpy * xpy);
            if (u < 0)
            {
                x *= -1;
            }

            double LDirX = -dirY;
            double LDirY = dirX;

            double num = dx * LDirX + dy * LDirY;
            double denom = LDirX * LDirX + LDirY * LDirY;

            double v = num / denom;
            double ypx = LDirX * v;
            double ypy = LDirY * v;

            double y = Math.Sqrt(ypx * ypx + ypy * ypy);
            if (v < 0)
            {
                y *= -1;
            }

            result = new Point2D(x, y);

            return result;

        }
    }
}
