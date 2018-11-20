using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    class Helper
    {
        static double epsilon = 0.00001;

        /// <summary>
        /// To prevent comparing two doubles via the equal sign.
        /// ((a < b + epsilon) && (a > b - epsilon))
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool DoubleCompare(double a, double b)
        {
            return ((a < b + epsilon) && (a > b - epsilon));
        }
    }
}
