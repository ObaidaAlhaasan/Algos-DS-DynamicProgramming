namespace Data.Structure.Search
{
    public class TernarySearch
    {
        public static int FindRec(int[] arr, int target)
        {
            return FindRec(arr, target, 0, arr.Length - 1);
        }

        private static int FindRec(int[] arr, int target, int left, int right)
        {
            if (left > right)
                return -1;

            var partitionSize = (right - left) / 3;
            var midd1 = left + partitionSize;
            var midd2 = right - partitionSize;

            if (arr[midd1] == target)
                return midd1;

            if (arr[midd2] == target)
                return midd2;

            if (target < arr[midd1])
                return FindRec(arr, target, left, midd1 - 1);

            if (target > arr[midd2])
                return FindRec(arr, target, midd2 + 1, right);


            return FindRec(arr, target, midd1 + 1, midd2 - 1);
        }
    }
}