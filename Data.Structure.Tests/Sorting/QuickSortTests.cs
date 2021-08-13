using System.Data.Common;
using Data.Structure.Sorting;
using Xunit;
using Xunit.Abstractions;

namespace Data.Structure.Tests.Sorting
{
    public class QuickSortTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public QuickSortTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Sort()
        {
            var arr = new[] {1, 22, 13, 5, 10, 3, 11, 10};
            QuickSort.Sort(arr);
            _testOutputHelper.WriteLine(Utils.LogArr(arr));
        }
    }
}