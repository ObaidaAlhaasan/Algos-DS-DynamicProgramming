using System;
using System.Collections.Generic;

namespace Data.Structure.Search
{
    public class SearchAlgo
    {
        public static int LinearSearch(int[] arr, int target)
        {
            for (int i = 0; i < arr.Length; i++)
                if (arr[i] == target)
                    return 1;

            return -1;
        }

        public static int BinarySearch(int[] arr, int target) => BinarySearch(arr, target, 0, arr.Length - 1);

        private static int BinarySearch(int[] arr, int target, int start, int end)
        {
            return -1;
        }

        public static int BinarySearchLoop(int[] arr, int target)
        {
            return -1;
        }

        public static int TernarySearch(int[] arr, int target) => 0;


        public static int JumpSearch(int[] arr, int target) => 0;

        public static int ExponentialSearch(int[] arr, int target) => 0;
    }
}