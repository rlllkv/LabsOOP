using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_laba_1
{

    public class Rational
    {
        public readonly int _numerator; public readonly int _denominator;
        public Rational(int Numerator, int Denominator)
        {
            if (Denominator == 0) throw new Exception("Denominator cannot be zero.");
            
            this._numerator = Numerator;
            this._denominator = Denominator;

            int gcd = Math.Abs(GCD(Numerator, Denominator));
            _numerator = Numerator / gcd; _denominator = Denominator / gcd;

            if (_numerator < 0 && _denominator < 0)
            {
                _numerator = -_numerator;
                _denominator = -_denominator;
            }
            if (_denominator < 0 && _numerator > 0)
            {
                _denominator = -_denominator;
                _numerator = -_numerator;
            }

        }

        public override string ToString()
        {
            if (_denominator == 1) return $"{_numerator}";
            return $"{_numerator}/{_denominator}";
        }

        public static Rational operator +(Rational a, Rational b)
        {
            int newNumerator = a._numerator * b._denominator + b._numerator * a._denominator;
            int newDenominator = a._denominator * b._denominator;
            return new Rational(newNumerator, newDenominator);
        }

        public static Rational operator -(Rational a, Rational b)
        {
            int newNumerator = a._numerator * b._denominator - b._numerator * a._denominator;
            int newDenominator = a._denominator * b._denominator;
            return new Rational(newNumerator, newDenominator);
        }

        public static Rational operator -(Rational a)
        {
            return new Rational(-a._numerator, a._denominator);
        }

        public static bool operator ==(Rational a, Rational b)
        {
            return a._numerator == b._numerator && a._denominator == b._denominator;
        }

        public static bool operator !=(Rational a, Rational b)
        {
            return !(a == b);
        }

        public static bool operator <(Rational a, Rational b)
        {
            return a._numerator * b._denominator < b._numerator * a._denominator;
        }

        public static bool operator >(Rational a, Rational b)
        {
            return a._numerator * b._denominator > b._numerator * a._denominator;
        }

        private static int GCD(int a, int b)
        {
            return b == 0 ? a : GCD(b, a % b);
        }
    }



}
