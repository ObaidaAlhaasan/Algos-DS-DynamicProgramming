using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Structure.Sorting
{
    public class SortsAlgo
    {
        // to optimize we assume it's sorted and since we bubble each larger item in each iteration we didn't include them in iterations
        public void BubbleSort(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                var isSorted = true;
                for (var j = 1; j < arr.Length - i; j++)
                {
                    if (arr[j] < arr[j - 1])
                    {
                        Utils.Swap(arr, j, j - 1);
                        isSorted = false;
                    }
                }

                if (isSorted)
                    return;
            }
        }

        public void SelectionSort(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                var minIndex = GetMinIndex(arr, i);
                Utils.Swap(arr, i, minIndex);
            }
        }

        private int GetMinIndex(int[] arr, int i)
        {
            var min = i;
            for (var j = i; j < arr.Length; j++)
            {
                if (arr[j] < arr[min])
                {
                    min = j;
                }
            }

            return min;
        }

        public void InsertionSort(int[] arr)
        {
            for (var i = 1; i < arr.Length; i++)
            {
                var current = arr[i];

                var j = i - 1;

                while (j >= 0 && arr[j] > current)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = current;
            }
        }

        public void MergeSort(int[] arr)
        {
            if (arr.Length < 2)
                return;

            // divide array into smaller arrays till we have array with one element
            var mid = arr.Length / 2;
            var left = arr.Take(mid).ToArray();
            var right = arr.Skip(mid).ToArray();

            // sort each half
            MergeSort(left);
            MergeSort(right);

            // merge sorted arrays 
            Merge(arr, left, right);
        }

        private void Merge(int[] arr, int[] left, int[] right)
        {
            var i = 0;
            var j = 0;
            var k = 0;

            while (i < left.Length && j < right.Length)
            {
                if (left[i] <= right[j])
                    arr[k++] = left[i++];
                else
                    arr[k++] = right[j++];
            }

            while (i < left.Length) arr[k++] = left[i++];

            while (j < right.Length) arr[k++] = right[j++];
        }


        public void QuickSort(int[] arr) => QuickSort(arr, 0, arr.Length - 1);

        private void QuickSort(int[] arr, int start, int end)
        {
            if (start >= end)
                return;

            var pivotIndex = Partition(arr, start, end);

            QuickSort(arr, start, pivotIndex - 1);
            QuickSort(arr, pivotIndex + 1, end);
        }

        private int Partition(int[] arr, int start, int end)
        {
            var pivot = arr[end];
            var boundary = start - 1;
            var i = start;
            for (; i <= end; i++)
                if (arr[i] <= pivot)
                    Utils.Swap(arr, i, ++boundary);

            return boundary;
        }

        public void CountingSort(int[] arr, int maxElementInArr)
        {
            var countArray = new int[maxElementInArr + 1];

            foreach (var t in arr) countArray[t] = countArray[t] + 1;

            var k = 0;
            for (var i = 0; i < countArray.Length; i++)
            {
                var item = countArray[i];

                for (var j = 0; j < item; j++)
                    arr[k++] = i;
            }
        }

        public void BucketSort(int[] arr, int numOfBuckets)
        {
            var buckets = CreateBuckets(arr, numOfBuckets);

            var i = 0;
            foreach (var bucket in buckets)
            {
                bucket.Sort();
                foreach (var item in bucket)
                    arr[i++] = item;
            }
        }

        private List<List<int>> CreateBuckets(int[] arr, int numOfBuckets)
        {
            var buckets = new List<List<int>>();

            for (var i = 0; i <= numOfBuckets; i++) buckets.Add(new List<int>());

            foreach (var item in arr)
                buckets.ElementAt(item / numOfBuckets).Add(item);

            return buckets;
        }
    }
}