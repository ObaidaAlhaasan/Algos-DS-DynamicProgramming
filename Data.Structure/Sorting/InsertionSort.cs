using System;

namespace Data.Structure.Sorting
{
    public class InsertionSort
    {
        public void Sort(int[] arr)
        {
            // var arr = new[] {1, 5, 3, 7, 4, 2, 3, 3, -1};

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
    }
}

// 1, 3, 5, 2
//    , 5 ,5
//    , 2 current  