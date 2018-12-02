using System;

namespace Curves
{
    /// <summary>
    /// Helper class for angle conversion.
    /// </summary>
    [Serializable]
    static class Angle
    {
        /// <summary>
        /// Converts an angle in radians to an angle in degree.
        /// </summary>
        /// <param name="radians">Angle in radians.</param>
        /// <returns></returns>
        public static double RadiansToDegree(double radians)
        {
            return radians * (180.0 / Math.PI);
        }

        /// <summary>
        /// Converts an angle in degree to radian.
        /// </summary>
        /// <param name="degrees">Angle in degree.</param>
        /// <returns></returns>
        public static double DegreeToRadians(double degrees)
        {
            return degrees * (Math.PI / 180.0);
        }
    }
}
