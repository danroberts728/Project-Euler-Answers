using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectEulerAnswers.Utility
{
    public class Rational
    {
        public long Numerator { get; set; }

        public long Denominator { get; set; }

        public Rational(long numerator, long denominator)
        {
            if(denominator == 0)
            {
                throw new ArgumentOutOfRangeException("denominator", "Cannot have 0 denominator");
            }
            long gcd = GCD(numerator, denominator);
            Numerator = numerator / gcd;
            Denominator = denominator / gcd;
        }

        public bool IsProper { get { return Numerator < Denominator; } }

        public static bool operator <(Rational a, Rational b)
        {
            return (decimal) a.Numerator / (decimal)a.Denominator < (decimal) b.Numerator / (decimal)b.Denominator;
        }

        public static bool operator >(Rational a, Rational b)
        {
            return (decimal) a.Numerator / (decimal)a.Denominator > (decimal) b.Numerator / (decimal) b.Denominator;
        }

        private static long GCD(long a, long b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }

    }
}