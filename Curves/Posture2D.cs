using System;

namespace Curves
{
    /// <summary>
    /// A class representing a posture. Consists of position coordinates x, y a direction in radians and a curvature.
    /// </summary>
    [Serializable]
    public class Posture2D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Direction { get; set; }
        public double Curvature { get; set; }

        public Posture2D(double x, double y, double direction, double curvature)
        {
            X = x;
            Y = y;
            Direction = direction;
            Curvature = curvature;
        }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y + " Direction: " + Direction + " Curvature: " + Curvature;
        }
    }
}
