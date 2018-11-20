using System;
using System.Collections.Generic;


namespace Curves
{
    /// <summary>
    /// A clothoid curve. See https://en.wikipedia.org/wiki/Euler_spiral for details.
    /// </summary>
    [Serializable]
    public class Clothoid : Curve
    {
        /// <summary>
        /// CLothoid parameter A.
        /// </summary>
        private double _a;

        private int _numIterations = 12;
        private bool _generatePointList = false;

        /// <summary>
        /// Getting and setting the number of iterations during integration of a point.
        /// </summary>
        public int NumIterations
        {
            get { return _numIterations; }
            set { _numIterations = value; }
        }


        /// <summary>
        /// Constructor of the clothoid curve.
        /// </summary>
        /// <param name="startX">X coordinate the clothoid starts at.</param>
        /// <param name="startY">X coordinate the clothoid starts at.</param>
        /// <param name="startDirection">Angle the clothoid starts at in radians.</param>
        /// <param name="startCurvature">Curvature the clothoid starts with.</param>
        /// <param name="a">Clothoid parameter A.</param>
        /// <param name="length">Length of the clothoid.</param>
        public Clothoid(double startX, double startY, double startDirection, double startCurvature, double a, double length)
        {
            _start_x = startX;
            _start_y = startY;
            _start_direction = startDirection;
            _start_curvature = startCurvature;
            _a = a;
            _length = length;

            Posture2D endPosture = InterpolatePosture2D(1.0);

            _end_x = endPosture.X;
            _end_y = endPosture.Y;
            _end_direction = endPosture.Direction;
            _end_curvature = endPosture.Curvature;
        }

        /// <summary>
        /// Gets the curvature on the clothoid.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Curvature at point t * length.</returns>
        public override double InterpolateCurvature(double t)
        {
            double curvature = (t * _length) / (_a * _a) + _start_curvature;
            return curvature;
        }

        /// <summary>
        /// Gets the direction on the clothoid.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Direction at point t * length.</returns>
        public override double InterpolateDirection(double t)
        {
            double L = t * _length;
            double aa = _a * _a;
            if (_a < 0)
                aa *= -1.0;

            return _start_direction + L * _start_curvature + ((L * L) / (2 * aa));
        }

        /// <summary>
        /// Returns a point (x, y) on the curve, parameterized by t.
        /// Using simpson rule for integration.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns></returns>
        public override Point2D InterpolatePoint2D(double t)
        {
            double s = t * _length;
            return CalculatePoint2D(s);
        }

        /// <summary>
        /// Returns a pose (x, y, theta) on the clothoid, parameterized by t.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Pose at point t * length.</returns>
        public override Pose2D InterpolatePose2D(double t)
        {
            double s = t * _length;
            return CalculatePose2D(s);
        }

        /// <summary>
        /// Returns a posture (x, y, direction, curvature) on the clothoid, parameterized by t.
        /// </summary>
        /// <param name="t">t should be greater than 0 and smaller than 1.</param>
        /// <returns>Posture at point t * length.</returns>
        public override Posture2D InterpolatePosture2D(double t)
        {
            double s = t * _length;
            return CalculatePosture2D(s);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns></returns>
        public override Point2D CalculatePoint2D(double s)
        {
            double x = 0, y = 0;

            // length of this clothoid
            double L = s;
            // stepSize
            double h = L / (double)_numIterations;

            double IntCos = 0;
            double IntSin = 0;

            double aa = _a * _a;

            if (_a < 0) aa *= -1;

            double left = 0, mid = 0, right = 0;
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
        /// Calculates a number of points on the clothoid.
        /// </summary>
        /// <param name="numPoints"></param>
        /// <returns></returns>
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
        /// Calculates the pose at arclength s of the clothoid.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Pose2D.</returns>
        public override Pose2D CalculatePose2D(double s)
        {
            Point2D p = CalculatePoint2D(s);
            double direction = CalculateDirection(s);

            return new Pose2D(p.X, p.Y, direction);
        }

        /// <summary>
        /// Calculates the posture at arclength s of the clothoid.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Posture2D.</returns>
        public override Posture2D CalculatePosture2D(double s)
        {
            Pose2D p = CalculatePose2D(s);
            double curvature = CalculateCurvature(s);
            return new Posture2D(p.X, p.Y, p.Direction, curvature);
        }

        /// <summary>
        /// Calculates the direction at arclength s of the clothoid.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Direction in radians.</returns>
        public override double CalculateDirection(double s)
        {
            double aa = _a * _a;
            if (_a < 0)
                aa *= -1.0;

            return _start_direction + (s * _start_curvature) + ((s * s) / (2 * aa));
        }

        /// <summary>
        /// Calculates the curvature at arclength s of the clothoid.
        /// </summary>
        /// <param name="s">Arclength s.</param>
        /// <returns>Curvature.</returns>
        public override double CalculateCurvature(double s)
        {
            double curvature = (s) / (_a * _a) + _start_curvature;
            return curvature;
        }
    }
}
