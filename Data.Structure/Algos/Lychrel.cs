using System;
using System.Linq;

namespace Data.Structure.Algos
{
    public static class Lychrel
    {
        public static int ConversionAtIteration(ulong n, int limit) => Conversion(n, 0, limit);

        private static int Conversion(ulong n, int iteration, int limit)
        {
            if (!IsPalindrome(n) && iteration < limit)
                return Conversion(n + Reverse(n), iteration + 1, limit);

            return iteration;
        }

        public static ulong Reverse(ulong n)
        {
            var rev = n.ToString().Reverse().Join();

            return Convert.ToUInt64(rev);
        }

        public static bool IsPalindrome(ulong n) => n.ToString().Reverse().SequenceEqual(n.ToString());
    }
}