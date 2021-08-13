using System.Linq;

namespace Data.Structure.Dynamic.Tabulation
{
    public static class Fib
    {
        public static long G(int num)
        {
            var nums = new long[num + 1];
            nums[1] = 1;

            for (var i = 0; i <= num; i++)
            {
                if (i + 1 < nums.Length)
                    nums[i + 1] += nums[i];

                if (i + 2 < nums.Length)
                    nums[i + 2] += nums[i];
            }

            return nums[num];
        }
    }
}