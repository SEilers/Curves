using System;

namespace Curves
{
    /// <summary>
    /// A point class. Consists of two position coordinates x and y.
    /// </summary>
    [Serializable]
    public class Point2D
    {
        private double _x;
        private double _y;

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }

        public Point2D(double x, double y)
        {
            _x = x;
            _y = y;
        }

        public static Point2D operator +(Point2D a, Point2D b)
        {
            return new Point2D(a.X + b.X, a.Y + b.Y);
        }

        public static Point2D operator -(Point2D a, Point2D b)
        {
            return new Point2D(a.X - b.X, a.Y - b.Y);
        }

        public static Point2D operator *(double a, Point2D b)
        {
            return new Point2D(a * b.X, a * b.Y);
        }

        public static Point2D operator *(Point2D a, double b)
        {
            return b * a;
        }

        public static double Distance(Point2D a, Point2D b)
        {
            double dx = b.X - a.X;
            double dy = b.Y - a.Y;
            return Math.Sqrt(dx * dx + dy * dy);
        }

        public static double DistanceToOrigin( Point2D p )
        {
            return Math.Sqrt(p.X * p.X + p.Y * p.Y);
        }

        public double DistanceToOrigin()
        {
            return Math.Sqrt(_x * _x + _y * _y);
        }

        public static double Dot( Point2D a, Point2D b)
        {
            return a.X * b.X + a.Y * b.Y;
        }

        public override string ToString()
        {
            return "X: " + X.ToString("F20") + " Y: " + Y.ToString("F20");
        }
    }
}
