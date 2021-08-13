using Data.Structure.Sorting;
using Xunit;
using Xunit.Abstractions;

namespace Data.Structure.Tests.Sorting
{
    public class CountingSortTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly CountingSort _countSort;

        public CountingSortTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            _countSort = new CountingSort();
        }

        [Fact]
        public void Sort()
        {
            var arr = new[] {1, 5, 3, 7, 4, 2, 3, 3, 0};
            _countSort.Sort(arr, 7);
            _testOutputHelper.WriteLine(Utils.LogArr(arr));
        }
    }
}