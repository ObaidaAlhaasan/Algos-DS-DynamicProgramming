using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Structure.Dynamic.Memoization
{
    public static class BestSum
    {
        public static IList<int>? G(int[] arr, int targetSum) => G(arr, targetSum, new Dictionary<int, IList<int>>());

        public static IList<int>? G(int[] arr, int targetSum, Dictionary<int, IList<int>?> memo)
        {
            if (memo.TryGetValue(targetSum, out var value))
                return value;

            if (targetSum == 0)
                return new List<int>();

            if (targetSum < 0)
                return null;

            IList<int>? shortest = null;

            foreach (var num in arr)
            {
                var combined = G(arr, targetSum - num, memo);
                if (combined != null)
                {
                    combined.Add(num);
                    if (shortest == null || combined.Count < shortest.Count)
                        shortest = combined;
                }
            }

            // memo.TryAdd(targetSum, shortest);
            return shortest;
        }
    }
}