using System.Collections.Generic;
using System.Linq;

namespace Data.Structure.Sorting
{
    public class MergeSort
    {
        public static void Sort(int[] arr)
        {
            if (arr.Length < 2)
                return;

            // divide this array into half
            var midIndex = arr.Length / 2;
            var left = arr.Take(midIndex).ToArray();
            var right = arr.Skip(midIndex).ToArray();

            // sort arrays recursively
            Sort(left);
            Sort(right);

            // merge arrays
            MergeArrays(arr, left, right);
        }

        private static void MergeArrays(IList<int> arr, IList<int> left, IList<int> right)
        {
            int i, j, k;
            i = j = k = 0;

            while (i < left.Count && j < right.Count)
            {
                if (left[i] <= right[j])
                    arr[k++] = left[i++];
                else
                    arr[k++] = right[j++];
            }

            // in case one array is larger than the other we do a loop to make sure we copied all other items
            while (i < left.Count) arr[k++] = left[i++];
            while (j < right.Count) arr[k++] = right[j++];
        }
    }
}