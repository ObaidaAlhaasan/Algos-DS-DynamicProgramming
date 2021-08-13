using System;
using System.Collections.Generic;

namespace Data.Structure.Dynamic.Memoization
{
    public static class HowSum
    {
        public static IList<int>? G(int[] arr, int num) => G(arr, num, new Dictionary<int, IList<int>?>());

        private static IList<int>? G(int[] arr, int num, Dictionary<int, IList<int>?> memo)
        {
            if (memo.TryGetValue(num, out var value))
                return value;

            if (num == 0)
                return new List<int>();

            if (num < 0)
                return null;

            foreach (var n in arr)
            {
                var list = G(arr, num - n, memo);
                if (list != null)
                {
                    list.Add(n);
                    memo.TryAdd(num, list);
                    return list;
                }
            }

            memo.TryAdd(num, null);
            return null;
        }
    }
}