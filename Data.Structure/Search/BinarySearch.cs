using System;

namespace Data.Structure.Search
{
    public class BinarySearch
    {
        public static int FindRec(int[] arr, int item) => FindRec(arr, item, 0, arr.Length - 1);

        public static int FindRec(int[] arr, int item, int start, int end)
        {
            if (end < start)
                return -1;

            var middle = (start + end) / 2;
            if (arr[middle] == item)
                return middle;

            if (item < arr[middle])
                return FindRec(arr, item, start, middle - 1);

            return FindRec(arr, item, middle + 1, end);
        }

        public static int FindIter(int[] arr, int item)
        {
            var start = 0;
            var end = arr.Length - 1;

            while (start <= end)
            {
                var middle = (start + end)/ 2;
                if (arr[middle] == item)
                    return middle;

                if (item < arr[middle])
                    end = middle - 1;
                else
                    start = middle + 1;
            }

            return -1;
        }
    }
}