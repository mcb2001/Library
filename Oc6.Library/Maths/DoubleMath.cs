using Oc6.Library.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Maths
{
    /// <summary>
    /// Adds additional functionality to <see cref="System.Math"/>
    /// </summary>
    public static class DoubleMath
    {
        /// <summary>
        /// <para>Defines root as a function</para>
        /// <para>i.e. Root(100, 2) = 10 and Root(8, 3) == 2</para>
        /// </summary>
        /// <param name="value">The value to take the root of</param>
        /// <param name="root">The root to apply</param>
        /// <returns>The root of the value</returns>
        public static double Root(double value, int root)
        {
            if (IntegerMath.IsPowerOfTwo(root) && value < 0.0)
            {
                throw new ArgumentOutOfRangeException(nameof(value), ErrorMessages.MustBePositive);
            }
            else if (value == 0.0)
            {
                return 0.0;
            }

            try
            {
                return NewtonRaphson.Iterate(x => Math.Pow(x, root) - value, x => root * Math.Pow(x, root - 1), rounding: null);
            }
            catch (IterationsExceededException<double> exc)
            {
                return exc.LastValue;
            }
        }
    }
}
