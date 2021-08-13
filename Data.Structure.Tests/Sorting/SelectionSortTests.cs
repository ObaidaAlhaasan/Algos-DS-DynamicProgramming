using System;
using Data.Structure.Sorting;
using Xunit;
using Xunit.Abstractions;

namespace Data.Structure.Tests.Sorting
{
    public class SelectionSortTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly SelectionSort selectionSort;

        public SelectionSortTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            selectionSort = new SelectionSort();
        }

        [Fact]
        public void Sort_ASC()
        {
            var arr = new[] {1, 5, 3, 7, 4, 2, 3, 3,-1};
            selectionSort.Sort(arr);
            _testOutputHelper.WriteLine(string.Join(",", arr));
        }
    }
}