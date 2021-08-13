using System;
using System.Collections.Generic;

namespace Data.Structure.Dynamic.Memoization
{
    public class GridTraveler
    {
        private static Dictionary<string, long> Memoize = new();

        public static long G(int m, int n)
        {
            var key = $"{m.ToString()},{n.ToString()}";
            if (Memoize.TryGetValue(key, out var val))
                return val;

            if (m == 0 || n == 0)
                return 0;

            if (m == 1 && n == 1)
                return 1;

            var down = G(m - 1, n);
            var right = G(m, n - 1);

            Memoize.TryAdd(key, down + right);

            return Memoize.GetValueOrDefault(key);
        }
    }
}