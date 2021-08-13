using System;
using System.Xml;
using Data.Structure.Sorting;
using Microsoft.Win32.SafeHandles;
using Xunit;
using Xunit.Abstractions;

namespace Data.Structure.Tests.Sorting
{
    public class InsertionSortTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly InsertionSort _insertionSort;

        public InsertionSortTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _insertionSort = new InsertionSort();
        }


        [Fact]
        public void Sort_ASC()
        {
            var arr = new[] {1, 5, 3, 7, 4, 2, 3, 3, -1};
            _insertionSort.Sort(arr);
            _testOutputHelper.WriteLine(string.Join(",", arr));
        }

        [Fact]
        public void ShiftToRight()
        {
            var arr = new int[] {0, 1, 2, 3, 4, 5, 0};

            var i = arr.Length - 1;
            while (i >= 0 && arr[i - 1] > arr[i])
            {
                arr[i] = arr[i - 1];
                i--;
            }

            _testOutputHelper.WriteLine(Structure.Utils.LogArr(arr));
        }
    }
}