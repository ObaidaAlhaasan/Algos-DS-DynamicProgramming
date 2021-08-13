using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace Data.Structure.Dynamic.Tabulation
{
    public class BestSum
    {
        public static List<int> G(int[] arr, int target)
        {
            var table = new List<List<int>?>();

            table.Capacity = target + 1;

            for (var i = 0; i <= target + 1; i++)
                table.Insert(i, null);

            table.Insert(0, new List<int>());

            for (var i = 0; i <= target; i++)
            {
                if (table[i] == null)
                    continue;

                foreach (var num in arr)
                {
                    if (i + num <= target)
                    {
                        var combined = new List<int>();
                        combined.AddRange(table[i]);
                        combined.Add(num);

                        if (table[i + num] == null || table[i + num]?.Count > combined.Count)
                            table[i + num] = combined;
                    }
                }
            }

            return table[target];
        }
    }
}