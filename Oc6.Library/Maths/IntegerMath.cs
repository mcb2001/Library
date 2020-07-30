using Oc6.Library.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Maths
{
    public static class IntegerMath
    {
        public static BigInteger GreatestCommonDivisor(params BigInteger[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            else if (values.Length == 0)
            {
                throw new ArgumentException(ErrorMessages.NoArguments, nameof(values));
            }
            else if (values.Length == 1)
            {
                return values[0];
            }
            else if (values.Length == 2)
            {
                return BigInteger.GreatestCommonDivisor(values[0], values[1]);
            }
            else
            {
                BigInteger gcd = GreatestCommonDivisor(values[0], values[1]);

                for (int i = 2; i < values.Length; ++i)
                {
                    if (gcd == BigInteger.One)
                    {
                        return BigInteger.One;
                    }
                    else
                    {
                        gcd = GreatestCommonDivisor(gcd, values[i]);
                    }
                }

                return gcd;
            }
        }

        public static int GreatestCommonDivisor(params int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            else if (values.Length == 0)
            {
                throw new ArgumentException(ErrorMessages.NoArguments, nameof(values));
            }
            else if (values.Length == 1)
            {
                return values[0];
            }
            else if (values.Length == 2)
            {
                return GreatestCommonDivisor(values[0], values[1]);
            }
            else
            {
                int gcd = GreatestCommonDivisor(values[0], values[1]);

                for (int i = 2; i < values.Length; ++i)
                {
                    if (gcd == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        gcd = GreatestCommonDivisor(gcd, values[i]);
                    }
                }

                return gcd;
            }
        }

        public static int GreatestCommonDivisor(int a, int b)
        {
            if (a < 0)
            {
                return GreatestCommonDivisor(-a, b);
            }
            else if (b < 0)
            {
                return GreatestCommonDivisor(a, -b);
            }
            else if (a == 0 && b == 0)
            {
                throw new ArgumentException(ErrorMessages.NeedsOneNonZeroValue);
            }
            else if (a == 0 || b == 0)
            {
                return 1;
            }
            else if (a < b)
            {
                return GreatestCommonDivisor(b, a);
            }
            else
            {
                int c = a % b;

                return c == 0 ? b : GreatestCommonDivisor(b, c);
            }
        }

        public static long GreatestCommonDivisor(params long[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            else if (values.Length == 0)
            {
                throw new ArgumentException(ErrorMessages.NoArguments, nameof(values));
            }
            else if (values.Length == 1)
            {
                return values[0];
            }
            else if (values.Length == 2)
            {
                return GreatestCommonDivisor(values[0], values[1]);
            }
            else
            {
                long gcd = GreatestCommonDivisor(values[0], values[1]);

                for (int i = 2; i < values.Length; ++i)
                {
                    if (gcd == 1)
                    {
                        return 1;
                    }
                    else
                    {
                        gcd = GreatestCommonDivisor(gcd, values[i]);
                    }
                }

                return gcd;
            }
        }

        public static long GreatestCommonDivisor(long a, long b)
        {
            if (a < 0)
            {
                return GreatestCommonDivisor(-a, b);
            }
            else if (b < 0)
            {
                return GreatestCommonDivisor(a, -b);
            }
            else if (a == 0 && b == 0)
            {
                throw new ArgumentException(ErrorMessages.NeedsOneNonZeroValue);
            }
            else if (a == 0 || b == 0)
            {
                return 1;
            }
            else if (a < b)
            {
                return GreatestCommonDivisor(b, a);
            }
            else
            {
                long c = a % b;

                return c == 0 ? b : GreatestCommonDivisor(b, c);
            }
        }

        public static int LeastCommonMultiple(int a, int b)
        {
            return a * b / GreatestCommonDivisor(a, b);
        }

        public static long LeastCommonMultiple(long a, long b)
        {
            return a * b / GreatestCommonDivisor(a, b);
        }

        public static BigInteger LeastCommonMultiple(BigInteger a, BigInteger b)
        {
            return a * b / GreatestCommonDivisor(a, b);
        }

        public static int LeastCommonMultiple(params int[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            else if (values.Length == 0)
            {
                throw new ArgumentException(ErrorMessages.NoArguments, nameof(values));
            }
            else if (values.Length == 1)
            {
                return values[0];
            }
            else if (values.Length == 2)
            {
                return LeastCommonMultiple(values[0], values[1]);
            }
            else
            {
                int lcm = LeastCommonMultiple(values[0], values[1]);

                for (int i = 2; i < values.Length; ++i)
                {
                    lcm = LeastCommonMultiple(lcm, values[i]);
                }

                return lcm;
            }
        }

        public static long LeastCommonMultiple(params long[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            else if (values.Length == 0)
            {
                throw new ArgumentException(ErrorMessages.NoArguments, nameof(values));
            }
            else if (values.Length == 1)
            {
                return values[0];
            }
            else if (values.Length == 2)
            {
                return LeastCommonMultiple(values[0], values[1]);
            }
            else
            {
                long lcm = LeastCommonMultiple(values[0], values[1]);

                for (int i = 2; i < values.Length; ++i)
                {
                    lcm = LeastCommonMultiple(lcm, values[i]);
                }

                return lcm;
            }
        }

        public static BigInteger LeastCommonMultiple(params BigInteger[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }
            else if (values.Length == 0)
            {
                throw new ArgumentException(ErrorMessages.NoArguments, nameof(values));
            }
            else if (values.Length == 1)
            {
                return values[0];
            }
            else if (values.Length == 2)
            {
                return LeastCommonMultiple(values[0], values[1]);
            }
            else
            {
                BigInteger lcm = LeastCommonMultiple(values[0], values[1]);

                for (int i = 2; i < values.Length; ++i)
                {
                    lcm = LeastCommonMultiple(lcm, values[i]);
                }

                return lcm;
            }
        }

        public static sbyte Sqrt(sbyte input)
        {
            return (sbyte)SignedSqrtInternal(input);
        }

        public static byte Sqrt(byte input)
        {
            if (input < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(input), ErrorMessages.MustBePositive);
            }

            return (byte)SqrtInternal(input);
        }

        public static short Sqrt(short input)
        {
            return (short)SignedSqrtInternal(input);
        }

        public static ushort Sqrt(ushort input)
        {
            return (ushort)SqrtInternal(input);
        }

        public static int Sqrt(int input)
        {
            return (int)SignedSqrtInternal(input);
        }

        public static uint Sqrt(uint input)
        {
            return (uint)SqrtInternal(input);
        }

        public static long Sqrt(long input)
        {
            return (long)SignedSqrtInternal(input);
        }

        public static ulong Sqrt(ulong input)
        {
            return SqrtInternal(input);
        }

        public static BigInteger Sqrt(BigInteger input)
        {
            if (input < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(input), ErrorMessages.MustBePositive);
            }

            if (input == 0)
            {
                return 0;
            }

            BigInteger t;

            try
            {
                t = NewtonRaphson.Iterate(x => (x * x) - input, x => 2 * x, 2147483648);
            }
            catch (IterationsExceededException<BigInteger> exc)
            {
                t = exc.LastValue;
            }

            if (t * t == input)
            {
                return t;
            }

            --t;

            BigInteger prev = t * t;

            while (true)
            {
                ++t;

                BigInteger cur = t * t;

                if (cur < prev || cur > input)
                {
                    break;
                }
            }

            return t - 1;
        }

        public static bool IsPowerOfTwo(sbyte x)
        {
            return x > 0 && IsPowerOfTwoInternal((ulong)x);
        }

        public static bool IsPowerOfTwo(byte x)
        {
            return x > 0 && IsPowerOfTwoInternal(x);
        }

        public static bool IsPowerOfTwo(short x)
        {
            return x > 0 && IsPowerOfTwoInternal((ulong)x);
        }

        public static bool IsPowerOfTwo(ushort x)
        {
            return IsPowerOfTwoInternal(x);
        }

        public static bool IsPowerOfTwo(int x)
        {
            return x > 0 && IsPowerOfTwoInternal((ulong)x);
        }

        public static bool IsPowerOfTwo(uint x)
        {
            return IsPowerOfTwoInternal(x);
        }

        public static bool IsPowerOfTwo(long x)
        {
            return x > 0 && IsPowerOfTwoInternal((ulong)x);
        }

        public static bool IsPowerOfTwo(ulong x)
        {
            return IsPowerOfTwoInternal(x);
        }

        private static ulong SignedSqrtInternal(long input)
        {
            if (input < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(input), ErrorMessages.MustBePositive);
            }

            return SqrtInternal((ulong)input);
        }

        private static ulong SqrtInternal(ulong input)
        {
            if (input == 0)
            {
                return 0;
            }

            double i = input;
            double value;

            try
            {
                value = NewtonRaphson.Iterate(x => (x * x) - i, x => 2.0 * x, 2147483648);
            }
            catch (IterationsExceededException<double> exc)
            {
                value = exc.LastValue;
            }

            ulong t = (ulong)value;

            while (t * t < t)
            {
                --t;
            }

            ulong prev = t * t;

            while (true)
            {
                ++t;

                ulong cur = t * t;

                if (cur < prev || cur > input)
                {
                    break;
                }
            }

            return t - 1;
        }

        private static bool IsPowerOfTwoInternal(ulong x)
        {
            switch (x)
            {
                case 0b0000000000000000000000000000000000000000000000000000000000000001:
                case 0b0000000000000000000000000000000000000000000000000000000000000010:
                case 0b0000000000000000000000000000000000000000000000000000000000000100:
                case 0b0000000000000000000000000000000000000000000000000000000000001000:
                case 0b0000000000000000000000000000000000000000000000000000000000010000:
                case 0b0000000000000000000000000000000000000000000000000000000000100000:
                case 0b0000000000000000000000000000000000000000000000000000000001000000:
                case 0b0000000000000000000000000000000000000000000000000000000010000000:
                case 0b0000000000000000000000000000000000000000000000000000000100000000:
                case 0b0000000000000000000000000000000000000000000000000000001000000000:
                case 0b0000000000000000000000000000000000000000000000000000010000000000:
                case 0b0000000000000000000000000000000000000000000000000000100000000000:
                case 0b0000000000000000000000000000000000000000000000000001000000000000:
                case 0b0000000000000000000000000000000000000000000000000010000000000000:
                case 0b0000000000000000000000000000000000000000000000000100000000000000:
                case 0b0000000000000000000000000000000000000000000000001000000000000000:
                case 0b0000000000000000000000000000000000000000000000010000000000000000:
                case 0b0000000000000000000000000000000000000000000000100000000000000000:
                case 0b0000000000000000000000000000000000000000000001000000000000000000:
                case 0b0000000000000000000000000000000000000000000010000000000000000000:
                case 0b0000000000000000000000000000000000000000000100000000000000000000:
                case 0b0000000000000000000000000000000000000000001000000000000000000000:
                case 0b0000000000000000000000000000000000000000010000000000000000000000:
                case 0b0000000000000000000000000000000000000000100000000000000000000000:
                case 0b0000000000000000000000000000000000000001000000000000000000000000:
                case 0b0000000000000000000000000000000000000010000000000000000000000000:
                case 0b0000000000000000000000000000000000000100000000000000000000000000:
                case 0b0000000000000000000000000000000000001000000000000000000000000000:
                case 0b0000000000000000000000000000000000010000000000000000000000000000:
                case 0b0000000000000000000000000000000000100000000000000000000000000000:
                case 0b0000000000000000000000000000000001000000000000000000000000000000:
                case 0b0000000000000000000000000000000010000000000000000000000000000000:
                case 0b0000000000000000000000000000000100000000000000000000000000000000:
                case 0b0000000000000000000000000000001000000000000000000000000000000000:
                case 0b0000000000000000000000000000010000000000000000000000000000000000:
                case 0b0000000000000000000000000000100000000000000000000000000000000000:
                case 0b0000000000000000000000000001000000000000000000000000000000000000:
                case 0b0000000000000000000000000010000000000000000000000000000000000000:
                case 0b0000000000000000000000000100000000000000000000000000000000000000:
                case 0b0000000000000000000000001000000000000000000000000000000000000000:
                case 0b0000000000000000000000010000000000000000000000000000000000000000:
                case 0b0000000000000000000000100000000000000000000000000000000000000000:
                case 0b0000000000000000000001000000000000000000000000000000000000000000:
                case 0b0000000000000000000010000000000000000000000000000000000000000000:
                case 0b0000000000000000000100000000000000000000000000000000000000000000:
                case 0b0000000000000000001000000000000000000000000000000000000000000000:
                case 0b0000000000000000010000000000000000000000000000000000000000000000:
                case 0b0000000000000000100000000000000000000000000000000000000000000000:
                case 0b0000000000000001000000000000000000000000000000000000000000000000:
                case 0b0000000000000010000000000000000000000000000000000000000000000000:
                case 0b0000000000000100000000000000000000000000000000000000000000000000:
                case 0b0000000000001000000000000000000000000000000000000000000000000000:
                case 0b0000000000010000000000000000000000000000000000000000000000000000:
                case 0b0000000000100000000000000000000000000000000000000000000000000000:
                case 0b0000000001000000000000000000000000000000000000000000000000000000:
                case 0b0000000010000000000000000000000000000000000000000000000000000000:
                case 0b0000000100000000000000000000000000000000000000000000000000000000:
                case 0b0000001000000000000000000000000000000000000000000000000000000000:
                case 0b0000010000000000000000000000000000000000000000000000000000000000:
                case 0b0000100000000000000000000000000000000000000000000000000000000000:
                case 0b0001000000000000000000000000000000000000000000000000000000000000:
                case 0b0010000000000000000000000000000000000000000000000000000000000000:
                case 0b0100000000000000000000000000000000000000000000000000000000000000:
                case 0b1000000000000000000000000000000000000000000000000000000000000000:
                    return true;
                default:
                    return false;
            }
        }
    }
}
