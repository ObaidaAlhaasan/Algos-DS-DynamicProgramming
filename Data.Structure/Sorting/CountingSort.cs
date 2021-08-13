using System;
using System.Linq;

namespace Data.Structure.Sorting
{
    public class CountingSort
    {
        public void Sort(int[] arr, int max)
        {
            var countArr = new int[max + 1];

            foreach (var item in arr)
                countArr[item] = countArr[item] + 1;

            var k = 0;
            for (var i = 0; i < countArr.Length; i++)
            {
                var sub = countArr[i];
                for (var j = 0; j < sub; j++) arr[k++] = i;
            }
        }
    }
}