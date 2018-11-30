using System;

namespace Curves
{
    /// <summary>
    /// An arc with constant radius.
    /// </summary>
    [Serializable]
    public class Arc : Curve
    {

        /// <summary>
        /// Arc Constructor.
        /// </summary>
        /// <param name="startX">X coordinate the arc starts at.</param>
        /// <param name="startY">Y coordinate the arc starts at.</param>
        /// <param name="startDirection">Angle the arc starts at in radians.</param>
        /// <param name="startCurvature">Curvature of the arc.</param>
        /// <param name="length">Length of the arc.</param>
        public Arc(double startX, double startY, double startDirection, double startCurvature, double length)
        {
            _length = length;

            _start_x = startX;
            _start_y = startY;
            _start_direction = startDirection;
            _start_curvature = startCurvature;

            Posture2D endPosture = InterpolatePosture2D(1.0);

            _end_x = endPosture.X;
            _end_y = endPosture.Y;
            _end_direction = endPosture.Direction;
            _end_curvature = endPosture.Curvature;
        }

        public static Arc FromPoseAndPoint( double startX, double startY, double startDirection, double endX, double endY )
        {
            double dx; double dy;

            Point2D p = CoordinateSystemConverter.ToPoseCoordinateSystem(startX, startY, startDirection, endX, endY);

            dx = p.X;
            dy = p.Y;

            double r = ((dx * dx) + (dy * dy)) / (2.0f * dy);
            double l = Math.Sqrt((dx * dx) + (dy * dy));
            double alpha = 2.0f * Math.Asin(l / (2.0f * r));

            if (dx < 0 && dy > 0) alpha = (2.0f * Math.PI) - alpha;
            if (dx < 0 && dy < 0) alpha = (2.0f * -Math.PI) - alpha;

            double curvature = 1.0f / r;
            double length = r * alpha;

            return new Arc(startX, startY, startDirection, curvature, length);
        }


        /// <summary>
        /// Calculates the curvature of the arc at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns></returns>
        public override double CalculateCurvature(double s)
        {
            return _start_curvature;
        }

        /// <summary>
        /// Calculates the direction of the curve at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns></returns>
        public override double CalculateDirection(double s)
        {
            return _start_direction + (s * _start_curvature);
        }


        /// <summary>
        /// Calculates the point at arclength s.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public override Point2D CalculatePoint2D(double s)
        {
            double x;
            double y;

            double absRadius;
            if (_start_curvature != 0)
            {
                absRadius = Math.Abs(1.0f / _start_curvature);
            }
            else
            {
                absRadius = double.MaxValue;
            }


            double epsilon = 0.000001f;
            double halfPI = (Math.PI / 2.0);
         
            double curvatureSign = Math.Sign(_start_curvature);

            // if radius is not too big, calculate an arc point
            if (_start_curvature > epsilon || _start_curvature < -epsilon)
            {
                x = _start_x + absRadius * Math.Cos(_start_direction + (curvatureSign * halfPI)) + absRadius * Math.Cos((_start_direction + (-curvatureSign * halfPI)) + s * _start_curvature);
                y = _start_y + absRadius * Math.Sin(_start_direction + (curvatureSign * halfPI)) + absRadius * Math.Sin((_start_direction + (-curvatureSign * halfPI)) + s * _start_curvature);
            }
            else // else if radius is very large (curvature nearly 0), calculate a line point 
            {
                x = _start_x + s * Math.Cos(_start_direction);
                y = _start_y + s * Math.Sin(_start_direction);
            }

            return new Point2D(x, y);
        }

        /// <summary>
        /// Calculates the pose at arclength s.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public override Pose2D CalculatePose2D(double s)
        {
            Point2D p = CalculatePoint2D(s);
            double direction = CalculateDirection(s);
            return new Pose2D(p.X, p.Y, direction);
        }

        /// <summary>
        /// Calculates the posture at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns></returns>
        public override Posture2D CalculatePosture2D(double s)
        {
            Point2D p = InterpolatePoint2D(s);
            double direction = CalculateDirection(s);
            return new Posture2D(p.X, p.Y, direction, _start_curvature);
        }



        /// <summary>
        /// Gets the curvature on the arc.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Curvature at point t * length.</returns>
        public override double InterpolateCurvature(double t)
        {
            return _start_curvature;
        }

        /// <summary>
        /// Gets the direction on the arc.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Direction at point t * length.</returns>
        public override double InterpolateDirection(double t)
        {
            return _start_direction + t * (_length * _start_curvature);
        }

        /// <summary>
        /// Returns a point (x, y) on the line segment, parameterized by t.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Point at point t * length.</returns>
        public override Point2D InterpolatePoint2D(double t)
        {
            double s = t * _length;
            return CalculatePoint2D(s);
        }

        /// <summary>
        /// Returns a pose (x, y, theta) on the arc, parameterized by t.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Pose at point t * length.</returns>
        public override Pose2D InterpolatePose2D(double t)
        {
            double s = t * _length;
            return CalculatePose2D(s);
        }

        /// <summary>
        /// Returns a posture (x, y, direction, curvature) on the arc, parameterized by t.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Posture at point t * length.</returns>
        public override Posture2D InterpolatePosture2D(double t)
        {
            double s = t * _length;
            return CalculatePosture2D(s);
        }
    }
}
