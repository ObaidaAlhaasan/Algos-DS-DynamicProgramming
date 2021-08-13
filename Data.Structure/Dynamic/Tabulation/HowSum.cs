using System.Collections.Generic;
using System.Linq;

namespace Data.Structure.Dynamic.Tabulation
{
    public static class HowSum
    {
        public static List<int>? G(int[] nums, int target)
        {
            var table = new List<List<int>?>();

            table.Capacity = target + 1;

            for (var i = 0; i <= target + 1; i++)
                table.Insert(i, null);

            table.Insert(0, new List<int>());

            for (var i = 0; i <= target; i++)
            {
                if (table[i] == null) continue;

                foreach (var num in nums)
                {
                    if (i + num <= target)
                    {
                        table[i + num] = new List<int>();
                        table[i + num]?.AddRange(table[i]);
                        table[i + num]?.Add(num);
                    }
                }
            }

            return table[target];
        }
    }
}