using System;
using System.Reflection.Metadata.Ecma335;

namespace Data.Structure.Recursion
{
    public static class RecursionAlgo
    {
        public static string ReverseString(string source)
        {
            if (source == string.Empty)
                return string.Empty;

            return ReverseString(source[1..]) + source[0];
        }

        public static bool IsPalindrome(string source)
        {
            if (source.Length is 0 or 1)
                return true;

            if (source[0] == source[^1])
            {
                return IsPalindrome(source.Slice(1, source.Length - 1));
            }

            return false;
        }

        public static string DecimalToBinary(int source, string result = "")
        {
            if (source == 0)
                return result;

            return DecimalToBinary(source / 2, source % 2 + result);
        }
    }
}