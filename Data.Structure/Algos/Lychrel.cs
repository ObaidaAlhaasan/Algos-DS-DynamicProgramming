using System;
using System.Linq;
using System.Numerics;

namespace Data.Structure.Algos
{
    public static class Lychrel
    {
        public static int ConversionAtIteration(ulong n, int limit) => Conversion(n, 0);

        private static int Conversion(ulong n, int iteration)
        {
            if (IsPalindrome(n))
                return iteration;

            return Conversion(n + Reverse(n), iteration + 1);
        }

        public static ulong Reverse(ulong n)
        {
            var rev = n.ToString().Reverse().Join();

            return Convert.ToUInt64(rev);
        }

        public static bool IsPalindrome(ulong n) => n.ToString().Reverse().SequenceEqual(n.ToString());
    }
}