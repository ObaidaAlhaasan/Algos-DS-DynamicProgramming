using System;
using System.Collections.Generic;

namespace Data.Structure.Search
{
    public class SearchAlgo
    {
        public static int LinearSearch(int[] arr, int target)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                if (arr[i] == target)
                    return i;
            }

            return -1;
        }

        public static int BinarySearch(int[] arr, int target) => 0;


        public static int TernarySearch(int[] arr, int target) => 0;


        public static int JumpSearch(int[] arr, int target) => 0;

        public static int ExponentialSearch(int[] arr, int target) => 0;
    }
}