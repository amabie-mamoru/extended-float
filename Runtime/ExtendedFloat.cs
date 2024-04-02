using System;
using System.Numerics;
using UnityEngine;

namespace com.amabie.ExtendedFloat
{
    public class ExtendedFloat
    {
        public BigInteger _value = 0;
        public string _originalString = "";
        // 下から何桁目に小数点が打たれるか(指数)
        public int _exponent = 0;
        public int _originalStringLength => _originalString.Replace(".", "").Length;

        public ExtendedFloat(sbyte value) { _value = value; _originalString = value.ToString(); }
        public ExtendedFloat(byte value) { _value = value; _originalString = value.ToString(); }
        public ExtendedFloat(short value) { _value = value; _originalString = value.ToString(); }
        public ExtendedFloat(ushort value) { _value = value; _originalString = value.ToString(); }
        public ExtendedFloat(int value) { _value = value; _originalString = value.ToString(); }
        public ExtendedFloat(uint value) { _value = value; _originalString = value.ToString(); }
        public ExtendedFloat(long value) { _value = value; _originalString = value.ToString(); }
        public ExtendedFloat(ulong value) { _value = value; _originalString = value.ToString(); }
        public ExtendedFloat(nint value) { _value = value; _originalString = value.ToString(); }
        public ExtendedFloat(nuint value) { _value = value; _originalString = value.ToString(); }
        public ExtendedFloat(BigInteger value) { _value = value; _originalString = value.ToString(); }
        public ExtendedFloat(float value) {
            _originalString = value.ToString();
            _exponent = GetDecimalLength((decimal)value);
            _value = BigInteger.Parse(value.ToString().TrimEnd('0').Replace(".",""));
        }
        public ExtendedFloat(double value) {
            _originalString = value.ToString();
            _exponent = GetDecimalLength((decimal)value);
            _value = BigInteger.Parse(value.ToString().TrimEnd('0').Replace(".",""));
        }
        public ExtendedFloat(decimal value) {
            _originalString = value.ToString();
            _exponent = GetDecimalLength(value);
            _value = BigInteger.Parse(value.ToString().TrimEnd('0').Replace(".",""));
        }
        private static int GetDecimalLength(decimal val)
        {
            int result = 0;
            string valStr = val.ToString().TrimEnd('0');
            int idx = valStr.IndexOf('.');
            if (idx != -1) result = valStr.Substring(idx + 1).Length;
            return result;
        }
        public ExtendedFloat(sbyte value, int exponent) { _value = value; _exponent = exponent; _originalString = value.ToString(); }
        public ExtendedFloat(byte value, int exponent) { _value = value; _exponent = exponent; _originalString = value.ToString(); }
        public ExtendedFloat(short value, int exponent) { _value = value; _exponent = exponent; _originalString = value.ToString(); }
        public ExtendedFloat(ushort value, int exponent) { _value = value; _exponent = exponent; _originalString = value.ToString(); }
        public ExtendedFloat(int value, int exponent) { _value = value; _exponent = exponent; _originalString = value.ToString(); }
        public ExtendedFloat(uint value, int exponent) { _value = value; _exponent = exponent; _originalString = value.ToString(); }
        public ExtendedFloat(long value, int exponent) { _value = value; _exponent = exponent; _originalString = value.ToString(); }
        public ExtendedFloat(ulong value, int exponent) { _value = value; _exponent = exponent; _originalString = value.ToString(); }
        public ExtendedFloat(nint value, int exponent) { _value = value; _exponent = exponent; _originalString = value.ToString(); }
        public ExtendedFloat(nuint value, int exponent) { _value = value; _exponent = exponent; _originalString = value.ToString(); }
        public ExtendedFloat(BigInteger value, int exponent) { _value = value; _exponent = exponent; _originalString = value.ToString(); }
        public ExtendedFloat(string value, int exponent) { _exponent = exponent; _originalString = value; }

        public static ExtendedFloat Zero => new ExtendedFloat(0);

        public static ExtendedFloat operator +(ExtendedFloat a, ExtendedFloat b)
        {
            var exponent = a._exponent > b._exponent ? a._exponent : b._exponent;
            var result = a._value * BigInteger.Parse($"1{new string('0', exponent - a._exponent)}") + 
                         b._value * BigInteger.Parse($"1{new string('0', exponent - b._exponent)}");
            if (exponent == 0 || result.ToString().Length - exponent == 0) {
                return new ExtendedFloat(result, exponent);
            }
            return new ExtendedFloat(result.ToString().Insert(result.ToString().Length - exponent, ".").TrimEnd('0'), exponent);
            
        }
        // TODO: 一旦後回し
        // public static ExtendedFloat operator +(ExtendedFloat a, float b) => new ExtendedFloat(a + b);
        // public static ExtendedFloat operator +(float a, ExtendedFloat b) => new ExtendedFloat(a + b);
        // public static ExtendedFloat operator -(ExtendedFloat a, ExtendedFloat b) => new ExtendedFloat(a - b);
        // public static ExtendedFloat operator *(ExtendedFloat a, ExtendedFloat b) => new ExtendedFloat(a * b);
        // public static ExtendedFloat operator /(ExtendedFloat a, ExtendedFloat b) => new ExtendedFloat(a / b);
        // public static bool operator ==(ExtendedFloat a, ExtendedFloat b) => a._value == b._value && a._exponent == b._exponent;
        // public static bool operator !=(ExtendedFloat a, ExtendedFloat b) => a._value != b._value || a._exponent != b._exponent;
        // public static bool operator >(ExtendedFloat a, ExtendedFloat b) => a._exponent > b._exponent && a._value > b._value;
        // public static bool operator >=(ExtendedFloat a, ExtendedFloat b) => a._exponent >= b._exponent && a._value >= b._value;
        // public static bool operator <(ExtendedFloat a, ExtendedFloat b) => a._exponent < b._exponent && a._value < b._value;
        // public static bool operator <=(ExtendedFloat a, ExtendedFloat b) => a._exponent <= b._exponent && a._value <= b._value;

        public override string ToString()
        {
            return _originalString;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (GetType() != obj.GetType()) return false;
            return this == (ExtendedFloat)obj;
        }

        public override int GetHashCode()
        {
            return _originalString.GetHashCode() ^ _originalStringLength;
        }
    }
}