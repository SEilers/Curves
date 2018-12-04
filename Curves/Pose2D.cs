using System;

namespace Curves
{
    /// <summary>
    /// A class representing a pose. Consists of position coordinates x, y and a direction in radians.
    /// </summary>
    [Serializable]
    public class Pose2D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Direction { get; set; }

        public Pose2D(double x, double y, double direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y + " Direction " + Direction;
        }
    }
}
