using System;
using Data.Structure.Sorting;
using Xunit;
using Xunit.Abstractions;

namespace Data.Structure.Tests.Sorting
{
    public class BubbleSortTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly BubbleSort bs;

        public BubbleSortTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            bs = new BubbleSort();
        }

        [Fact]
        public void BubbleSort_ShouldSort_ArrOfIntegers()
        {
            var arr = new[] {7, 3, 1, 4, 6, 2, 3, 5};

            bs.SortACS(arr);
            _testOutputHelper.WriteLine(string.Join(",", arr));
            bs.SortDESC(arr);
            _testOutputHelper.WriteLine(string.Join(",", arr));
        }
    }
}