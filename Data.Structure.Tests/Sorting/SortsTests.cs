using System;
using System.Drawing;
using Data.Structure.Sorting;
using Xunit;
using Xunit.Abstractions;

namespace Data.Structure.Tests.Sorting
{
    public class SortsTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly SortsAlgo sAlgo;

        public SortsTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            sAlgo = new SortsAlgo();
        }

        [Fact]
        public void BubbleSort()
        {
            var arr = new[] {1, 3, 5, 6, 2, 1, -1};
            sAlgo.BubbleSort(arr);
            _testOutputHelper.WriteLine(Utils.LogArr(arr));
        }

        [Fact]
        public void SelectionSort()
        {
            var arr = new[] {1, 3, 5, 3, 4, 6, 2, 1, -1};
            sAlgo.SelectionSort(arr);
            _testOutputHelper.WriteLine(Utils.LogArr(arr));
        }

        [Fact]
        public void InsertionSort()
        {
            var arr = new[] {1, 3, 5, 3, 4, 6, 2, 1, -1};
            sAlgo.InsertionSort(arr);
            _testOutputHelper.WriteLine(Utils.LogArr(arr));
        }

        [Fact]
        public void MergeSort()
        {
            var arr = new[] {1, 3, 5, 3, 4, 6, 2, 1, -1};
            sAlgo.MergeSort(arr);
            _testOutputHelper.WriteLine(Utils.LogArr(arr));
        }


        [Fact]
        public void QuickSort()
        {
            var arr = new[] {1, 22, 13, 5, 10, 3, 11, 10};

            sAlgo.QuickSort(arr);
            _testOutputHelper.WriteLine(Utils.LogArr(arr));
        }


        [Fact]
        public void CountingSort()
        {
            var arr = new[] {1, 3, 5, 3, 4, 6, 2, 1, 5};
            sAlgo.CountingSort(arr, 6);
            _testOutputHelper.WriteLine(Utils.LogArr(arr));
        }


        [Fact]
        public void BucketSort()
        {
            var arr = new[] {1, 3, 5, 3, 4, 6, 2, 1, 5};
            sAlgo.BucketSort(arr, 4);
            _testOutputHelper.WriteLine(Utils.LogArr(arr));
        }
    }
}