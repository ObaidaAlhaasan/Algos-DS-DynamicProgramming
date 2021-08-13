using System;
using Data.Structure.Sorting;
using Xunit;
using Xunit.Abstractions;

namespace Data.Structure.Tests.Sorting
{
    public class MergeSortTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public MergeSortTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Sort_ASC()
        {
            var arr = new[] {1, 2, 3, 5, 3, 1, -1};
            MergeSort.Sort(arr);
            _testOutputHelper.WriteLine(Utils.LogArr(arr));
        }
    }
}