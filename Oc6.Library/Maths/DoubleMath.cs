using Oc6.Library.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Maths
{
    public static class DoubleMath
    {
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
