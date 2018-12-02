using System;

namespace Curves
{
    /// <summary>
    /// A class representing a posture. Consists of position coordinates x, y a direction in radians and a curvature.
    /// </summary>
    [Serializable]
    public class Posture2D
    {
        private double curvature;
        private double x;
        private double y;
        private double direction;

        public double X { get => x; set => x = value; }
        public double Y { get => y; set => y = value; }
        public double Direction { get => direction; set => direction = value; }
        public double Curvature { get => curvature; set => curvature = value; }

        public Posture2D(double x, double y, double direction, double curvature)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
            this.Curvature = curvature;
        }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y + " Direction: " + Direction + " Curvature: " + Curvature;
        }
    }
}
