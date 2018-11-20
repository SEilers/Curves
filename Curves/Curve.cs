using System;
using System.Collections.Generic;

namespace Curves
{
    /// <summary>
    /// Abstract class from which the curves are derived from.
    /// </summary>
    [Serializable]
    public abstract class Curve
    {
        protected double _length;
        protected double _start_x, _start_y, _start_direction, _start_curvature;
        protected double _end_x, _end_y, _end_direction, _end_curvature;

        protected List<Point2D> _pointList;

        /// <summary>
        /// Gets the length of the curve.
        /// </summary>
        public double Length { get { return _length; } }

        /// <summary>
        /// The X coordinate of the start point.
        /// </summary>
        public double StartX { get { return _start_x; } }
        /// <summary>
        /// The Y coordinate of the start point.
        /// </summary>
        public double StartY { get { return _start_x; } }
        /// <summary>
        /// Start direction in radians.
        /// </summary>
        public double StartDirection { get { return _start_x; } }
        /// <summary>
        /// The start curvature
        /// </summary>
        public double StartCurvature { get { return _start_curvature; } }

        /// <summary>
        /// The X coordinate of the last curve point.
        /// </summary>
        public double EndX { get { return _end_x; } }
        /// <summary>
        /// The Y coordinate of the last curve point.
        /// </summary>
        public double EndY { get { return _end_y; } }
        /// <summary>
        /// The direction in radians at the end of the curve.
        /// </summary>
        public double EndDirection { get { return _end_direction; } }
        /// <summary>
        /// The curvature at the end of the curve.
        /// </summary>
        public double EndCurvature { get { return _end_curvature; } }


        /// <summary>
        /// Calculates a number of points on the curve. Suited for rendering the curve.
        /// </summary>
        /// <param name="numPoints">Number of points.</param>
        /// <returns>List of Point2D objects.</returns>
        public virtual List<Point2D> GetPoints(int numPoints)
        {
            _pointList = new List<Point2D>();
            double h = _length / (double)numPoints;

            for (int i = 0; i < numPoints; i++)
            {
                double s = i * h;
                Point2D p = CalculatePoint2D(s);
                _pointList.Add(p);
            }

            return _pointList;
        }

        /// <summary>
        /// Calculates the point on the curve at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>A Point2D (x,y) at arclength s.</returns>
        public abstract Point2D CalculatePoint2D(double s);

        /// <summary>
        /// Calculates the pose on the curve at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Pose2D (x, y, direction) at arclength s.</returns>
        public abstract Pose2D CalculatePose2D(double s);

        /// <summary>
        /// Calculates the posture on the curve at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Posture2D (x, y, direction, curvature) at arclength s.</returns>
        public abstract Posture2D CalculatePosture2D(double s);

        /// <summary>
        /// Calculates the direction in radians on the curve at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Direction in radians at arclength s.</returns>
        public abstract double CalculateDirection(double s);

        /// <summary>
        /// Calculates the curvature on the curve at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Curvature at arclenth s.</returns>
        public abstract double CalculateCurvature(double s);

        /// <summary>
        /// Returns a point (x, y) on the curve, parameterized by t.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Point at point t * length.</returns>
        public abstract Point2D InterpolatePoint2D(double t);

        /// <summary>
        /// Returns a pose (x, y, theta) on the curve, parameterized by t.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Pose at point t * length.</returns>
        public abstract Pose2D InterpolatePose2D(double t);

        /// <summary>
        /// Returns a posture (x, y, direction, curvature) on the curve, parameterized by t.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Posture at point t * length.</returns>
        public abstract Posture2D InterpolatePosture2D(double t);

        /// <summary>
        /// Gets the direction on the curve.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Direction at point t * length.</returns>
        public abstract double InterpolateDirection(double t);

        /// <summary>
        /// Gets the curvature on the curve.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Curvature at point t * length.</returns>
        public abstract double InterpolateCurvature(double t);
    }
}
