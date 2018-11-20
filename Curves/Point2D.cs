using System;

namespace Curves
{
    /// <summary>
    /// A point class. Consists of two position coordinates x and y.
    /// </summary>
    [Serializable]
    public class Point2D
    {
        public double X = 0;
        public double Y = 0;

        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        public static Point2D operator +(Point2D a, Point2D b)
        {
            return new Point2D(a.X + b.X, a.Y + b.Y);
        }

        public static Point2D operator -(Point2D a, Point2D b)
        {
            return new Point2D(a.X - b.X, a.Y - b.Y);
        }

        public static double Distance(Point2D a, Point2D b)
        {
            double dx = b.X - a.X;
            double dy = b.Y - a.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public override string ToString()
        {
            return "X: " + X.ToString("F20") + " Y: " + Y.ToString("F20");
        }
    }
}
