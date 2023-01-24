using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Maths
{
    public static class NewtonRaphson
    {
        public const int DefaultIterations = 10000;

        public const int DefaultGuess = 1;

        public const int DefaultRounding = 14;

        public static NewtonRaphsonResult<Complex> Iterate(Func<Complex, Complex> fx, Func<Complex, Complex> dydx, Complex? guess = null, int? iterations = DefaultIterations, int? rounding = DefaultRounding)
        {
            Complex x1 = guess ?? DefaultGuess, x0;

            for (int i = 1; i <= (iterations ?? i); ++i)
            {
                x0 = x1;
                x1 = x0 - (fx(x0) / dydx(x0));

                if (rounding.HasValue)
                {
                    x1 = new Complex(Math.Round(x1.Real, rounding.Value), Math.Round(x1.Imaginary, rounding.Value));
                }

                if (x0 == x1)
                {
                    return new(x0, false);
                }
            }

            return new(x1, true);
        }

        public static NewtonRaphsonResult<decimal> Iterate(Func<decimal, decimal> fx, Func<decimal, decimal> dydx, decimal guess = DefaultGuess, int? iterations = DefaultIterations, int? rounding = DefaultRounding)
        {
            decimal x1 = guess, x0;

            for (int i = 1; i <= (iterations ?? i); ++i)
            {
                x0 = x1;
                x1 = x0 - (fx(x0) / dydx(x0));

                if (rounding.HasValue)
                {
                    x1 = Math.Round(x1, rounding.Value);
                }

                if (x0 == x1)
                {
                    return new(x0, false);
                }
            }

            return new(x1, true);
        }

        public static NewtonRaphsonResult<double> Iterate(Func<double, double> fx, Func<double, double> dydx, double guess = DefaultGuess, int? iterations = DefaultIterations, int? rounding = DefaultRounding)
        {
            double x1 = guess, x0;

            for (int i = 1; i <= (iterations ?? i); ++i)
            {
                x0 = x1;
                x1 = x0 - (fx(x0) / dydx(x0));

                if (rounding.HasValue)
                {
                    x1 = Math.Round(x1, rounding.Value);
                }

                if (x0 == x1)
                {
                    return new(x0, false);
                }
            }

            return new(x1, true);
        }

        public static NewtonRaphsonResult<BigInteger> Iterate(Func<BigInteger, BigInteger> fx, Func<BigInteger, BigInteger> dydx, BigInteger? guess = null, int? iterations = DefaultIterations)
        {
            BigInteger x1 = guess ?? 1, x0;

            for (int i = 1; i <= (iterations ?? i); ++i)
            {
                x0 = x1;
                x1 = x0 - (fx(x0) / dydx(x0));

                if (x0 == x1)
                {
                    return new(x0, false);
                }
            }

            return new(x1, true);
        }

        public static NewtonRaphsonResult<float> Iterate(Func<float, float> fx, Func<float, float> dydx, float guess = DefaultGuess, int? iterations = DefaultIterations, int? rounding = DefaultRounding)
        {
            float x1 = guess, x0;

            for (int i = 1; i <= (iterations ?? i); ++i)
            {
                x0 = x1;
                x1 = x0 - (fx(x0) / dydx(x0));

                if (rounding.HasValue)
                {
                    x1 = (float)Math.Round(x1, rounding.Value);
                }

                if (x0 == x1)
                {
                    return new(x0, false);
                }
            }

            return new(x1, true);
        }

        public static NewtonRaphsonResult<int> Iterate(Func<int, int> fx, Func<int, int> dydx, int guess = DefaultGuess, int? iterations = DefaultIterations)
        {
            int x1 = guess, x0;

            for (int i = 1; i <= (iterations ?? i); ++i)
            {
                x0 = x1;
                x1 = x0 - (fx(x0) / dydx(x0));

                if (x0 == x1)
                {
                    return new(x0, false);
                }
            }

            return new(x1, true);
        }

        public static NewtonRaphsonResult<long> Iterate(Func<long, long> fx, Func<long, long> dydx, long guess = DefaultGuess, int? iterations = DefaultIterations)
        {
            long x1 = guess, x0;

            for (int i = 1; i <= (iterations ?? i); ++i)
            {
                x0 = x1;
                x1 = x0 - (fx(x0) / dydx(x0));

                if (x0 == x1)
                {
                    return new(x0, false);
                }
            }

            return new(x1, true);
        }
    }
}
