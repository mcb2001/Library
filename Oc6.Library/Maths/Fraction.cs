using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oc6.Library.Maths
{
    /// <summary>
    /// <para>Defines a Fraction as the differene between a numerator and a denominator.</para>
    /// <para>This is equivalent to a rational in mathematics: r=p/q, where p,q ε ℤ</para>
    /// </summary>
    public struct Fraction : IComparable<Fraction>, IEquatable<Fraction>
    {
        private const char DIVIDER = '/';

        /// <summary>
        /// The numerator
        /// </summary>
        public long Numerator { get; set; }

        /// <summary>
        /// The denominator
        /// </summary>
        public long Denominator { get; set; }

        /// <summary>
        /// <para>Creates a new <see cref="Fraction"/> with the given denominator and numerator.</para>
        /// <para>The <see cref="Fraction"/> is not guaranteed to be simplified.</para>
        /// </summary>
        /// <param name="num">The numerator</param>
        /// <param name="den">The denominator</param>
        public Fraction(long num, long den)
        {
            Numerator = num;
            Denominator = den;
        }

        /// <summary>
        /// <para>Creates a new <see cref="Fraction"/> with the given numerator and 1 as denominator.</para>
        /// <para>The <see cref="Fraction"/> is not guaranteed to be simplified.</para>
        /// </summary>
        /// <param name="num"></param>
        public Fraction(sbyte num)
            : this(num, 1)
        {

        }

        /// <summary>
        /// <para>Creates a new <see cref="Fraction"/> with the given numerator and 1 as denominator.</para>
        /// <para>The <see cref="Fraction"/> is not guaranteed to be simplified.</para>
        /// </summary>
        /// <param name="num"></param>
        public Fraction(byte num)
            : this(num, 1)
        {

        }

        /// <summary>
        /// <para>Creates a new <see cref="Fraction"/> with the given numerator and 1 as denominator.</para>
        /// <para>The <see cref="Fraction"/> is not guaranteed to be simplified.</para>
        /// </summary>
        /// <param name="num"></param>
        public Fraction(short num)
            : this(num, 1)
        {

        }

        /// <summary>
        /// <para>Creates a new <see cref="Fraction"/> with the given numerator and 1 as denominator.</para>
        /// <para>The <see cref="Fraction"/> is not guaranteed to be simplified.</para>
        /// </summary>
        /// <param name="num"></param>
        public Fraction(ushort num)
            : this(num, 1)
        {

        }

        /// <summary>
        /// <para>Creates a new <see cref="Fraction"/> with the given numerator and 1 as denominator.</para>
        /// <para>The <see cref="Fraction"/> is not guaranteed to be simplified.</para>
        /// </summary>
        /// <param name="num"></param>
        public Fraction(int num)
            : this(num, 1)
        {

        }

        /// <summary>
        /// <para>Creates a new <see cref="Fraction"/> with the given numerator and 1 as denominator.</para>
        /// <para>The <see cref="Fraction"/> is not guaranteed to be simplified.</para>
        /// </summary>
        /// <param name="num"></param>
        public Fraction(uint num)
            : this(num, 1)
        {

        }

        /// <summary>
        /// <para>Creates a new <see cref="Fraction"/> with the given numerator and 1 as denominator.</para>
        /// <para>The <see cref="Fraction"/> is not guaranteed to be simplified.</para>
        /// </summary>
        /// <param name="num"></param>
        public Fraction(long num)
            : this(num, 1)
        {

        }

        /// <summary>
        /// <para>Creates a new <see cref="Fraction"/> with the given numerator and 1 as denominator.</para>
        /// <para>The <see cref="Fraction"/> is not guaranteed to be simplified.</para>
        /// </summary>
        /// <param name="num"></param>
        public Fraction(ulong num)
        {
            if (num > long.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(num));
            }

            Numerator = (long)num;
            Denominator = 1;
        }

        /// <summary>
        /// Compares this <see cref="Fraction"/> to another <see cref="Fraction"/> by numeric value.
        /// </summary>
        /// <param name="other">The <see cref="Fraction"/> to compare to</param>
        /// <returns></returns>
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

        /// <summary>
        /// Generates a hashcode from <see cref="Fraction.Denominator"/> and <see cref="Fraction.Numerator"/>
        /// </summary>
        /// <returns>The hashcode for this <see cref="Fraction"/></returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.Numerator, this.Denominator);
        }

        /// <summary>
        /// Converts a <see cref="Fraction"/> to a <see cref="double"/>
        /// </summary>
        /// <param name="f">The fraction to convert</param>
        public static implicit operator double(Fraction f)
        {
            return ToDouble(f);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public static double ToDouble(Fraction f)
        {
            f = Simplify(f);
            double num = f.Numerator;
            double den = f.Denominator;
            return num / den;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Fraction(sbyte value)
        {
            return ToFraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Fraction(byte value)
        {
            return ToFraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Fraction(short value)
        {
            return ToFraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Fraction(ushort value)
        {
            return ToFraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Fraction(int value)
        {
            return ToFraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Fraction(uint value)
        {
            return ToFraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Fraction(long value)
        {
            return ToFraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator Fraction(ulong value)
        {
            return ToFraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fraction ToFraction(sbyte value)
        {
            return new Fraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fraction ToFraction(byte value)
        {
            return new Fraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fraction ToFraction(short value)
        {
            return new Fraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fraction ToFraction(ushort value)
        {
            return new Fraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fraction ToFraction(int value)
        {
            return new Fraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fraction ToFraction(uint value)
        {
            return new Fraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fraction ToFraction(long value)
        {
            return new Fraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fraction ToFraction(ulong value)
        {
            return new Fraction(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(Fraction a, Fraction b)
        {
            return a.CompareTo(b) == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <(Fraction a, Fraction b)
        {
            return a.CompareTo(b) < 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator <=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) <= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >(Fraction a, Fraction b)
        {
            return a.CompareTo(b) > 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator >=(Fraction a, Fraction b)
        {
            return a.CompareTo(b) >= 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Fraction operator -(Fraction a)
        {
            return Negate(a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Fraction Negate(Fraction a)
        {
            a = Normalize(a);

            long num = a.Numerator;
            long den = a.Denominator;

            return new Fraction(-num, den);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Fraction operator ++(Fraction a)
        {
            return Increment(a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Fraction Increment(Fraction a)
        {
            return new Fraction(a.Numerator + 1, a.Denominator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Fraction operator --(Fraction a)
        {
            return Decrement(a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Fraction Decrement(Fraction a)
        {
            return new Fraction(a.Numerator - 1, a.Denominator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Fraction operator +(Fraction a)
        {
            return Plus(a);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        public static Fraction Plus(Fraction a)
        {
            a = Normalize(a);

            long num = a.Numerator;
            long den = a.Denominator;

            return new Fraction(Math.Abs(num), den);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator +(Fraction a, Fraction b)
        {
            return Add(a, b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction Add(Fraction a, Fraction b)
        {
            return new Fraction((a.Numerator * b.Denominator) + (b.Numerator * a.Denominator), a.Denominator * b.Denominator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator -(Fraction a, Fraction b)
        {
            return Subtract(a, b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction Subtract(Fraction a, Fraction b)
        {
            return new Fraction((a.Numerator * b.Denominator) - (b.Numerator * a.Denominator), a.Denominator * b.Denominator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator *(Fraction a, Fraction b)
        {
            return Multiply(a, b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction Multiply(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction operator /(Fraction a, Fraction b)
        {
            return Divide(a, b);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static Fraction Divide(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fraction"></param>
        /// <returns></returns>
        public static bool IsSimplified(Fraction fraction)
        {
            return IntegerMath.GreatestCommonDivisor(fraction.Numerator, fraction.Denominator) == 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fraction"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fraction"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="frac"></param>
        /// <returns></returns>
        public static bool TryParse(string value, out Fraction frac)
        {
            return TryParse(value, out frac, style: default, provider: default);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="frac"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static bool TryParse(string value, out Fraction frac, NumberStyles style)
        {
            return TryParse(value, out frac, style, provider: default);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="frac"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static bool TryParse(string value, out Fraction frac, IFormatProvider provider)
        {
            return TryParse(value, out frac, style: default, provider);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="frac"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static bool TryParse(string value, out Fraction frac, NumberStyles style, IFormatProvider? provider)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Fraction Parse(string value)
        {
            return Parse(value, style: default, provider: null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        public static Fraction Parse(string value, NumberStyles style)
        {
            return Parse(value, style, provider: null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static Fraction Parse(string value, IFormatProvider? provider)
        {
            return Parse(value, style: default, provider);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="style"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Fraction Parse(string value, NumberStyles style, IFormatProvider? provider)
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

            string numString = value[..index];
            string denString = value.Substring(index + 1, value.Length - index - 1);

            num = long.Parse(numString, style, provider);
            den = long.Parse(denString, style, provider);

            return new Fraction(num, den);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString(this, format: default, provider: default);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <returns></returns>
        public string ToString(string? format)
        {
            return ToString(this, format, provider: default);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ToString(IFormatProvider? provider)
        {
            return ToString(this, format: default, provider);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="format"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public string ToString(string? format, IFormatProvider? provider)
        {
            return ToString(this, format, provider);
        }

        private static string ToString(Fraction fraction, string? format, IFormatProvider? provider)
        {
            fraction = Normalize(fraction);

            long num = fraction.Numerator;
            long den = fraction.Denominator;

            return den == 1 ? num.ToString(format, provider) : num.ToString(format, provider) + DIVIDER + den.ToString(format, provider);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            return obj is Fraction other && Equals(other);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Fraction other)
        {
            return Numerator == other.Numerator && Denominator == other.Denominator;
        }
    }
}
