using System;

namespace Curves
{
    /// <summary>
    /// A class representing a posture. Consists of position coordinates x, y a direction in radians and a curvature.
    /// </summary>
    [Serializable]
    public class Posture2D
    {
        private double _curvature;
        private double _x;
        private double _y;
        private double _direction;

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
        public double Direction { get => _direction; set => _direction = value; }
        public double Curvature { get => _curvature; set => _curvature = value; }

        public Posture2D(double x, double y, double direction, double curvature)
        {
            _x = x;
            _y = y;
            _direction = direction;
            _curvature = curvature;
        }

        public override string ToString()
        {
            return "X: " + _x + " Y: " + _y + " Direction: " + _direction + " Curvature: " + _curvature;
        }
    }
}
