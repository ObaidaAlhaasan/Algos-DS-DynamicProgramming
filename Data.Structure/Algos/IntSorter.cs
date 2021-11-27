using System.Collections.Generic;
using System.Linq;

namespace Data.Structure.Algos
{
    public class IntSorter
    {
        public IEnumerable<int> Sort(IEnumerable<int> originalNums)
        {
            var nums = originalNums.ToArray();

            for (var size = nums.Length; size >= 0; size--)
            {
                for (var index = 0; size > index + 1; index++)
                    if (OutOfOrder(nums, index))
                        Swap(nums, index);
            }

            return nums;
        }

        private static bool OutOfOrder(int[] nums, int index)
        {
            return nums.ElementAt(index) > nums.ElementAtOrDefault(index + 1);
        }

        private static void Swap(int[] nums, int index)
        {
            (nums[index], nums[index + 1]) = (nums[index + 1], nums[index]);
        }

        public IEnumerable<int> SortII(IList<int> unsortedList)
        {
            if (unsortedList.Count == 0)
                return unsortedList;

            var sorted = new List<int>();
            var l = new List<int>();
            var m = unsortedList.First();
            var h = new List<int>();

            foreach (var num in unsortedList.Skip(1))
            {
                if (num > m)
                    h.Add(num);
                else
                    l.Add(num);
            }

            sorted.AddRange(SortII(l));

            sorted.Add(m);

            sorted.AddRange(SortII(h));

            return sorted;
        }
    }
}