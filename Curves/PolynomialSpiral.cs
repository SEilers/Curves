using System;
using System.Collections.Generic;

namespace Curves
{
    /// <summary>
    /// Class representing a polynomial spiral, also called generalized cornu spiral or curvature polynomial.
    /// The curvature of the curve is given by a curvature polynomial: k(s) = a + b*s + c*s^2 + d*s^3 ...
    /// The polynomial spiral is defined by its arclength s and its coefficients of the polynomial.
    /// The number of coefficients is not fixed and given by a double array. 
    /// Arbitrary polynomial spirals like cubic (4 coefficients) and quintic (5 coefficients) can be expressed with it.
    /// </summary>
    [Serializable]
    public class PolynomialSpiral : Curve
    {
        protected double[] _coefficents;
        protected int _numIterations = 12;
        private bool _generatePointList = false;

        /// <summary>
        /// Constructor of the polynomial spiral.
        /// </summary>
        /// <param name="startX">X coordinate the polynomial spiral starts at.</param>
        /// <param name="startY">Y coordinate the polynomial spiral starts at.</param>
        /// <param name="startDirection">Angle the polynomial spiral starts at in radians.</param>
        /// <param name="coefficients">Coefficients of the polynomial spiral.</param>
        /// <param name="length">Length of the polynomial spiral.</param>
        public PolynomialSpiral(double startX, double startY, double startDirection, double[] coefficients, double length)
        {
            _start_x = startX;
            _start_y = startY;
            _start_direction = startDirection;
            _start_curvature = coefficients[0];
            _length = length;
            _coefficents = coefficients;
        }

        /// <summary>
        /// Gets the curvature on the polynomial spiral.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Curvature at point t * length.</returns>
        public override double InterpolateCurvature(double t)
        {
            double s = t * _length;
            return CalculateCurvature(s);
        }

        /// <summary>
        /// Gets the direction on the polynomial spiral.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Direction at point t * length.</returns>
        public override double InterpolateDirection(double t)
        {
            double s = t * _length;
            return CalculateDirection(s);
        }

        /// <summary>
        /// Returns a point (x, y) on the polynomial spiral, parameterized by t.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Point at point t * length.</returns>
        public override Point2D InterpolatePoint2D(double t)
        {
            double s = t * _length;
            return CalculatePoint2D(s);
        }

        /// <summary>
        /// Returns a pose (x, y, theta) on the polynomial spiral, parameterized by t.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Pose at point t * length.</returns>
        public override Pose2D InterpolatePose2D(double t)
        {
            double s = t * _length;
            return CalculatePose2D(s);
        }

        /// <summary>
        /// Returns a posture (x, y, direction, curvature) on the polynomial spiral, parameterized by t.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Posture at point t * length.</returns>
        public override Posture2D InterpolatePosture2D(double t)
        {
            double s = t * _length;
            return CalculatePosture2D(s);
        }

        /// <summary>
        /// Calculates the point on the polynomial spiral at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>A Point2D (x,y) at arclength s.</returns>
        public override Point2D CalculatePoint2D(double s)
        {
            double x = 0, y = 0;

            double h = s / (double)_numIterations;
            double IntCos = 0, IntSin = 0;
            double left = 0, right = 0, mid = 0;
            double pl = 0, pm = 0, pr = 0;

            for (int i = 0; i < _numIterations; i++)
            {
                left = i * h;
                right = (i + 1) * h;
                mid = (left + right) / 2.0;

                pl = CalculateDirection(left);
                pm = CalculateDirection(mid);
                pr = CalculateDirection(right);

                IntCos += (h / 6.0) * (Math.Cos(pl) + 4 * Math.Cos(pm) + Math.Cos(pr));
                IntSin += (h / 6.0) * (Math.Sin(pl) + 4 * Math.Sin(pm) + Math.Sin(pr));

                if (_generatePointList)
                {
                    _pointList.Add(new Point2D(_start_x + IntCos, _start_y + IntSin));
                }
            }

            x = _start_x + IntCos;
            y = _start_y + IntSin;

            return new Point2D(x, y);
        }

        /// <summary>
        /// Calculates a number of points on the curve. Suited for rendering the curve.
        /// </summary>
        /// <param name="numPoints">Number of points.</param>
        /// <returns>List of Point2D objects.</returns>
        public override List<Point2D> GetPoints(int numPoints)
        {
            _pointList = new List<Point2D>();

            _generatePointList = true;
            int oldNumIterations = _numIterations;
            _numIterations = numPoints;
            CalculatePoint2D(_length);
            _numIterations = oldNumIterations;
            _generatePointList = false;

            return _pointList;
        }

        /// <summary>
        /// Calculates the pose on the polynomial spiral at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Pose2D (x, y, direction) at arclength s.</returns>
        public override Pose2D CalculatePose2D(double s)
        {
            Point2D p = CalculatePoint2D(s);
            double direction = CalculateDirection(s);
            return new Pose2D(p.X, p.Y, direction);
        }

        /// <summary>
        /// Calculates the posture on the polynomial spiral at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Posture2D (x, y, direction, curvature) at arclength s.</returns>
        public override Posture2D CalculatePosture2D(double s)
        {
            Pose2D pose = CalculatePose2D(s);
            double curvature = CalculateCurvature(s);
            return new Posture2D(pose.X, pose.Y, pose.Direction, curvature);
        }

        /// <summary>
        /// Calculates the direction in radians on the polynomial spiral at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Direction in radians at arclength s.</returns>
        public override double CalculateDirection(double s)
        {
            double result = 0;
            int numTerms = _coefficents.Length;

            for (int i = 0; i < numTerms; i++)
            {
                if (_coefficents[i] != 0)
                    result += (_coefficents[i] * Math.Pow(s, i + 1)) / (i + 1);
            }

            result += _start_direction;

            return result;
        }

        /// <summary>
        /// Calculates the curvature on the polynomial spiral at arclength s.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Curvature at arclenth s.</returns>
        public override double CalculateCurvature(double s)
        {
            double result = 0;
            int numTerms = _coefficents.Length;

            for (int i = 0; i < numTerms; i++)
            {
                if (_coefficents[i] != 0)
                    result += _coefficents[i] * Math.Pow(s, i);
            }

            return result;
        }
    }
}
