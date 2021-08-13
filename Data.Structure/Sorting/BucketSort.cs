using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Structure.Sorting
{
    public class BucketSort
    {
        public void Sort(int[] arr, int numOfBuckets)
        {
            var i = 0;
            foreach (var bucket in CreateBuckets(arr, numOfBuckets))
            {
                bucket.Sort();
                foreach (var item in bucket)
                    arr[i++] = item;
            }
        }

        private static List<List<int>> CreateBuckets(int[] arr, int numOfBuckets)
        {
            var buckets = new List<List<int>>();

            for (var index = 0; index <= numOfBuckets; index++)
                buckets.Add(new List<int>());

            foreach (var item in arr)
                buckets.ElementAt(item / buckets.Count).Add(item);

            return buckets;
        }
    }
}