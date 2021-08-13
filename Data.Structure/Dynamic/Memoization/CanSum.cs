using System.Collections.Generic;
using System.Linq;

namespace Data.Structure.Dynamic.Memoization
{
    public static class CanSum
    {
        public static bool G(int[] arr, int num)
        {
            return G(arr, num, new Dictionary<int, bool>());
        }

        private static bool G(int[] arr, int num, Dictionary<int, bool> memo)
        {
            if (memo.TryGetValue(num, out var val))
                return val;

            if (num == 0)
                return true;

            if (num < 0)
                return false;

            if (arr.Any(n => G(arr, num - n, memo)))
            {
                memo.TryAdd(num, true);
                return true;
            }

            memo.TryAdd(num, false);
            return false;
        }
    }
}