using System.Collections.Generic;

namespace Data.Structure.Dynamic.Memoization
{
    public class Fib
    {
        public static readonly Dictionary<int, long> Memoize = new();

        public static long G(int num)
        {
            if (num <= 2)
                return 1;

            if (Memoize.TryGetValue(num, out var value))
                return value;

            Memoize.TryAdd(num, G(num - 1) + G(num - 2));

            return Memoize[num];
        }
    }
}