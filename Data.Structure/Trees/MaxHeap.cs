using System;
using System.Collections.Generic;

namespace Data.Structure.Trees
{
    public class MaxHeap
    {
        public void Heapify(int[] arr)
        {
            for (int i = arr.Length - 1 / 2; i >= 0; i--)
                Heapify(arr, i);
        }

        private void Heapify(int[] arr, int index)
        {
            var largerIndex = index;
            var leftIndex = index * 2 + 1;
            var rightIndex = index * 2 + 2;
            if (leftIndex < arr.Length && arr[leftIndex] > arr[largerIndex]) largerIndex = leftIndex;
            if (rightIndex < arr.Length && arr[rightIndex] > arr[largerIndex]) largerIndex = rightIndex;

            if (index == largerIndex)
                return;

            Swap(arr, index, largerIndex);

            Heapify(arr, largerIndex);
        }

        private void Swap(int[] arr, int first, int second)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }

        public int GetAtK(int[] arr, int index)
        {
            if (index < 0 || index > arr.Length)
                throw new Exception();

            var heap = new Heap();

            foreach (var item in arr)
                heap.Insert(item);

            for (var i = 0; i < index - 1; i++)
                heap.Remove();

            return heap.Max();
        }

        public static bool IsMax(int[] arr)
        {
            return IsMax(arr, 0);
        }

        private static bool IsMax(int[] arr, int index)
        {
            var lastParentIndex = (arr.Length - 2) / 2;

            if (index > lastParentIndex)
                return true;

            var leftInd = index * 2 + 1;
            var rightInd = index * 2 + 2;


            if (leftInd > arr.Length || rightInd > arr.Length)
                return true;

            var isValidParent = arr[index] >= arr[leftInd] && arr[index] >= arr[rightInd];


            return isValidParent && IsMax(arr, leftInd) && IsMax(arr, rightInd);
        }
    }
}