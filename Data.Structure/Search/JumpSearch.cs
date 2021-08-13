using System;

namespace Data.Structure.Search
{
    public class JumpSearch
    {
        public static int Find(int[] arr, int item)
        {
            var blockSize = (int) Math.Sqrt(arr.Length);
            var start = 0;
            var next = blockSize;

            while (start < arr.Length && arr[next - 1] < item)
            {
                start = next;
                next += blockSize;
                if (next > arr.Length)
                    next = arr.Length;
            }

            for (int i = start; i < next; i++)
            {
                if (arr[i] == item)
                    return i;
            }

            return -1;
        }
    }
}