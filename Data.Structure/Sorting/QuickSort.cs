using System;
using System.Linq;

namespace Data.Structure.Sorting
{
    public static class QuickSort
    {
        public static void Sort(int[] arr) => Sort(arr, 0, arr.Length - 1);

        public static void Sort(int[] arr, int start, int end)
        {
            if (start >= end)
                return;

            var pivot = Partitioning(arr, start, end);

            Sort(arr, start, pivot - 1);
            Sort(arr, pivot + 1, end);
        }

        private static int Partitioning(int[] arr, int start, int end)
        {
            var pivot = arr[end];
            var boundary = start - 1;
            var i = start;
            for (; i <= end; i++)
                if (arr[i] <= pivot)
                    Utils.Swap(arr, i, ++boundary);

            return boundary;
        }
    }
}