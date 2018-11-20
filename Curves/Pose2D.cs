using System;

namespace Curves
{
    /// <summary>
    /// A class representing a pose. Consists of position coordinates x, y and a direction in radians.
    /// </summary>
    [Serializable]
    public class Pose2D
    {
        public double X = 0, Y = 0, Direction = 0;

        public Pose2D(double x, double y, double direction)
        {
            this.X = x;
            this.Y = y;
            this.Direction = direction;
        }

        public override string ToString()
        {
            return "X: " + X + " Y: " + Y + " Direction " + Direction;
        }
    }
}
