using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Maths
{
    public struct Fraction : IComparable<Fraction>, IEquatable<Fraction>
    {
        private const char DIVIDER = '/';

        public long Numerator { get; set; }

        public long Denominator { get; set; }

        public Fraction(long num, long den)
        {
            Numerator = num;
            Denominator = den;
        }

        public Fraction(sbyte num)
            : this(num, 1)
        {

        }

        public Fraction(byte num)
            : this(num, 1)
        {

        }

        public Fraction(short num)
            : this(num, 1)
        {

        }

        public Fraction(ushort num)
            : this(num, 1)
        {

        }

        public Fraction(int num)
            : this(num, 1)
        {

        }

        public Fraction(uint num)
            : this(num, 1)
        {

        }

        public Fraction(long num)
            : this(num, 1)
        {

        }

        public Fraction(ulong num)
        {
            if (num > long.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(num));
            }

            Numerator = (long)num;
            Denominator = 1;
        }

        public int CompareTo(Fraction other)
        {
            Fraction a = Simplify(this);
            Fraction b = Simplify(other);

            if (a.Numerator == b.Numerator)
            {
                return b.Denominator.CompareTo(a.Numerator);
            }
            else
            {
                long x = a.Numerator * b.Denominator;
                long y = a.Denominator * b.Numerator;

                return x.CompareTo(y);
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Numerator, this.Denominator);
        }

        public static implicit operator double(Fraction f)
        {
            return ToDouble(f);
        }

        public static double ToDouble(Fraction f)
        {
            double num = f.Numerator;
            double den = f.Denominator;
            return num / den;
        }

        public static implicit operator Fraction(sbyte value)
        {
            return ToFraction(value);
        }

        public static implicit operator Fraction(byte value)
        {
            return ToFraction(value);
        }

        public static implicit operator Fraction(short value)
        {
            return ToFraction(value);
        }

        public static implicit operator Fraction(ushort value)
        {
            return ToFraction(value);
        }

        public static implicit operator Fraction(int value)
        {
            return ToFraction(value);
        }

        public static implicit operator Fraction(uint value)
        {
            return ToFraction(value);
        }

        public static implicit operator Fraction(long value)
        {
            return ToFraction(value);
        }

        public static implicit operator Fraction(ulong value)
        {
            return ToFraction(value);
        }

        public static Fraction ToFraction(sbyte value)
        {
            return new Fraction(value);
        }

        public static Fraction ToFraction(byte value)
        {
            return new Fraction(value);
        }

        public static Fraction ToFraction(short value)
        {
            return new Fraction(value);
        }

        public static Fraction ToFraction(ushort value)
        {
            return new Fraction(value);
        }

        public static Fraction ToFraction(int value)
        {
            return new Fraction(value);
        }

        public static Fraction ToFraction(uint value)
        {
            return new Fraction(value);
        }

        public static Fraction ToFraction(long value)
        {
            return new Fraction(value);
        }

        public static Fraction ToFraction(ulong value)
        {
            return new Fraction(value);
        }

        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.CompareTo(b) == 0;
        }

        public static bool operator !=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) != 0;
        }

        public static bool operator <(Fraction a, Fraction b)
        {
            return a.CompareTo(b) < 0;
        }

        public static bool operator <=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) <= 0;
        }

        public static bool operator >(Fraction a, Fraction b)
        {
            return a.CompareTo(b) > 0;
        }

        public static bool operator >=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) >= 0;
        }

        public static Fraction operator -(Fraction a)
        {
            return Negate(a);
        }

        public static Fraction Negate(Fraction a)
        {
            a = Normalize(a);

            long num = a.Numerator;
            long den = a.Denominator;

            return new Fraction(-num, den);
        }

        public static Fraction operator ++(Fraction a)
        {
            return Increment(a);
        }

        public static Fraction Increment(Fraction a)
        {
            return new Fraction(a.Numerator + 1, a.Denominator);
        }

        public static Fraction operator --(Fraction a)
        {
            return Decrement(a);
        }

        public static Fraction Decrement(Fraction a)
        {
            return new Fraction(a.Numerator - 1, a.Denominator);
        }

        public static Fraction operator +(Fraction a)
        {
            return Plus(a);
        }

        public static Fraction Plus(Fraction a)
        {
            a = Normalize(a);

            long num = a.Numerator;
            long den = a.Denominator;

            return new Fraction(Math.Abs(num), den);
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            return Add(a, b);
        }

        public static Fraction Add(Fraction a, Fraction b)
        {
            return new Fraction((a.Numerator * b.Denominator) + (b.Numerator * a.Denominator), a.Denominator * b.Denominator);
        }

        public static Fraction operator -(Fraction a, Fraction b)
        {
            return Subtract(a, b);
        }

        public static Fraction Subtract(Fraction a, Fraction b)
        {
            return new Fraction((a.Numerator * b.Denominator) - (b.Numerator * a.Denominator), a.Denominator * b.Denominator);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return Multiply(a, b);
        }

        public static Fraction Multiply(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        public static Fraction operator /(Fraction a, Fraction b)
        {
            return Divide(a, b);
        }

        public static Fraction Divide(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        public static bool IsSimplified(Fraction fraction)
        {
            return IntegerMath.GreatestCommonDivisor(fraction.Numerator, fraction.Denominator) == 1;
        }

        public static Fraction Simplify(Fraction fraction)
        {
            fraction = Normalize(fraction);

            long num = fraction.Numerator;
            long den = fraction.Denominator;

            long g = IntegerMath.GreatestCommonDivisor(num, den);

            num /= g;
            den /= g;

            return new Fraction(num, den);
        }

        public static Fraction Normalize(Fraction fraction)
        {
            long num = fraction.Numerator;
            long den = fraction.Denominator;

            if (den < 0)
            {
                /*
                 * -a / -b => a / b
                 * a / -b => -a / b
                 */
                den = -den;
                num = -num;
            }

            return new Fraction(num, den);
        }

        public static bool TryParse(string value, out Fraction frac)
        {
            return TryParse(value, out frac, style: default, provider: default);
        }

        public static bool TryParse(string value, out Fraction frac, NumberStyles style)
        {
            return TryParse(value, out frac, style, provider: default);
        }

        public static bool TryParse(string value, out Fraction frac, IFormatProvider provider)
        {
            return TryParse(value, out frac, style: default, provider);
        }

        [SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "Try/Catch used to actually be a TryParse pattern")]
        public static bool TryParse(string value, out Fraction frac, NumberStyles style, IFormatProvider provider)
        {
            if (value != null)
            {
                try
                {
                    frac = Parse(value, style, provider);
                    return true;
                }
                catch (ArgumentNullException)
                {
                }
                catch (FormatException)
                {
                }
                catch (OverflowException)
                {
                }
                catch (ArgumentException)
                {
                }
            }

            frac = default;
            return false;
        }

        public static Fraction Parse(string value)
        {
            return Parse(value, style: default, provider: null);
        }

        public static Fraction Parse(string value, NumberStyles style)
        {
            return Parse(value, style, provider: null);
        }

        public static Fraction Parse(string value, IFormatProvider provider)
        {
            return Parse(value, style: default, provider);
        }

        public static Fraction Parse(string value, NumberStyles style, IFormatProvider provider)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            int index = value.IndexOf(DIVIDER, StringComparison.InvariantCultureIgnoreCase);

            long num, den;

            if (index < 0)
            {
                num = long.Parse(value, style, provider);

                return new Fraction(num);
            }

            string numString = value.Substring(0, index);
            string denString = value.Substring(index + 1, value.Length - index - 1);

            num = long.Parse(numString, style, provider);
            den = long.Parse(denString, style, provider);

            return new Fraction(num, den);
        }

        public override string ToString()
        {
            return ToString(this, format: default, provider: default);
        }

        public string ToString(string format)
        {
            return ToString(this, format, provider: default);
        }

        public string ToString(IFormatProvider provider)
        {
            return ToString(this, format: default, provider);
        }

        public string ToString(string format, IFormatProvider provider)
        {
            return ToString(this, format, provider);
        }

        private static string ToString(Fraction fraction, string format, IFormatProvider provider)
        {
            fraction = Normalize(fraction);

            long num = fraction.Numerator;
            long den = fraction.Denominator;

            return den == 1 ? num.ToString(format, provider) : num.ToString(format, provider) + DIVIDER + den.ToString(format, provider);
        }

        public override bool Equals(object obj)
        {
            return obj is Fraction other && Equals(other);
        }

        public bool Equals(Fraction other)
        {
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }
    }
}
