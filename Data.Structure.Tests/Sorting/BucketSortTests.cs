using System;
using System.Linq;
using Data.Structure.Sorting;
using Xunit;
using Xunit.Abstractions;

namespace Data.Structure.Tests.Sorting
{
    public class BucketSortTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly BucketSort bucketSort;

        public BucketSortTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            bucketSort = new BucketSort();
        }


        [Fact]
        public void Sort()
        {
            // var arr = new[] {1, 12, 13, 5, 10, 3, 11, 10};
            var arr = new[] {7, 1, 3, 5, 3};
            bucketSort.Sort(arr, 3);
            _testOutputHelper.WriteLine(Utils.LogArr(arr));
        }
    }
}