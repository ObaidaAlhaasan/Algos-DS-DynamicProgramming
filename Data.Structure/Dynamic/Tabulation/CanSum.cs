using System;

namespace Data.Structure.Dynamic.Tabulation
{
    public static class CanSum
    {
        public static bool G(int[] nums, int targetSum)
        {
            var table = new bool[targetSum + 1];

            table[0] = true;

            for (var i = 0; i < table.Length; i++)
            {
                if (table[i])
                {
                    foreach (var num in nums)
                    {
                        if (i + num <= targetSum)
                        {
                            table[i + num] = true;
                        }
                    }
                }
            }

            return table[targetSum];
        }
    }
}