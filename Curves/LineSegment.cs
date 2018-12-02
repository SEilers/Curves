using System;

namespace Curves
{
    /// <summary>
    /// Class representing a line segment.
    /// </summary>
    [Serializable]
    public class LineSegment : Curve
    {
        private readonly double t_x;
        private readonly double t_y;
        private readonly double v_x;
        private readonly double v_y;

        /// <summary>
        /// Constructor of the line segment curve. 
        /// </summary>
        /// <param name="x0">X coordinate the line segment starts at.</param>
        /// <param name="y0">Y coordinate the line segment starts at.</param>
        /// <param name="startDirection">Angle the line segment starts at in radians.</param>
        /// <param name="length">Length of the line segment.</param>
        public LineSegment(double x0, double y0, double startDirection, double length)
        {
            // start variables
            _length = length;

            _start_x = x0;
            _start_y = y0;
            _start_direction = startDirection;
            _start_curvature = 0;

            t_x = Math.Cos(startDirection);
            t_y = Math.Sin(startDirection);

            v_x = t_x * _length;
            v_y = t_y * _length;

            _end_x = _start_x + v_x;
            _end_y = _start_y + v_y;
            _end_direction = _start_direction;
            _end_curvature = 0;
        }

        /// <summary>
        /// Calculates the curvature on the curve at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Curvature at arclenth s. Always 0 because it is line segment.</returns>
        public override double CalculateCurvature(double s)
        {
            return 0;
        }

        /// <summary>
        /// Calculates the direction in radians on the curve at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Direction in radians at arclength s.</returns>
        public override double CalculateDirection(double s)
        {
            return _start_direction;
        }

        /// <summary>
        /// Calculates the point on the curve at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>A Point2D (x,y) at arclength s.</returns>
        public override Point2D CalculatePoint2D(double s)
        {
            double x = _start_x + s * t_x;
            double y = _start_y + s * t_y;
            return new Point2D(x, y);
        }

        /// <summary>
        /// Calculates the pose on the curve at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Pose2D (x, y, direction) at arclength s.</returns>
        public override Pose2D CalculatePose2D(double s)
        {
            Point2D p = CalculatePoint2D(s);
            return new Pose2D(p.X, p.Y, _start_direction);
        }

        /// <summary>
        /// Calculates the posture on the curve at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Posture2D (x, y, direction, curvature) at arclength s.</returns>
        public override Posture2D CalculatePosture2D(double s)
        {
            Point2D p = CalculatePoint2D(s);
            return new Posture2D(p.X, p.Y, _start_direction, 0);
        }

        /// <summary>
        /// Gets the curvature on the curve.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Curvature at point t * length.</returns>
        public override double InterpolateCurvature(double t)
        {
            return 0;
        }

        /// <summary>
        /// Gets the direction on the curve.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Direction at point t * length.</returns>
        public override double InterpolateDirection(double t)
        {
            return _start_direction;
        }

        /// <summary>
        /// Returns a point (x, y) on the line segment, parameterized by t.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Point at point t * length.</returns>
        public override Point2D InterpolatePoint2D(double t)
        {
            double x = _start_x + t * v_x;
            double y = _start_y + t * v_y;
            return new Point2D(x, y);
        }

        /// <summary>
        /// Returns a pose (x, y, theta) on the line segment, parameterized by t.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Pose at point t * length.</returns>
        public override Pose2D InterpolatePose2D(double t)
        {
            Point2D p = InterpolatePoint2D(t);
            return new Pose2D(p.X, p.Y, _start_direction);
        }

        /// <summary>
        /// Returns a posture (x, y, direction, curvature) on the line segment, parameterized by t.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Posture at point t * length.</returns>
        public override Posture2D InterpolatePosture2D(double t)
        {
            Point2D p = InterpolatePoint2D(t);
            return new Posture2D(p.X, p.Y, _start_direction, 0);
        }
    }
}
