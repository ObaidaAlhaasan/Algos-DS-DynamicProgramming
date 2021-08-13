using System;
using System.IO;

namespace Data.Structure.Search
{
    public class ExponentialSearch
    {
        public static int Find(int[] arr, int item)
        {
            var boundary = 1;
            while (boundary < arr.Length && arr[boundary] < item)
                boundary *= 2;


            var left = boundary / 2;
            var right = Math.Min(boundary, arr.Length - 1);

            return BinarySearch.FindRec(arr, item, left, right);
        }
    }
}