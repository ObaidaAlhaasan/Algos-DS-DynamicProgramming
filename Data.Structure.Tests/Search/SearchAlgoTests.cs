using Data.Structure.Search;
using Xunit;

namespace Data.Structure.Tests.Search
{
    public class SearchAlgoTests
    {
        private readonly int[] sortedArr;
        private static int[] arr;

        public SearchAlgoTests()
        {
            sortedArr = new[] {3, 5, 6, 9, 11, 18, 20, 21, 24, 30};
            arr = new[] {30, 21, 6, 24, 9, 18, 20, 5, 11, 3};
        }

        [Fact]
        public void LinearSearch()
        {
            Assert.Equal(1, SearchAlgo.LinearSearch(arr, 21));
            Assert.Equal(-1, SearchAlgo.LinearSearch(arr, 200));
        }

        [Fact]
        public void BinarySearch()
        {
            Assert.Equal(7, SearchAlgo.BinarySearch(sortedArr, 21));
            Assert.Equal(-1, SearchAlgo.BinarySearch(sortedArr, 200));
        }

        [Fact]
        public void BinarySearchLoop()
        {
            Assert.Equal(7, SearchAlgo.BinarySearchLoop(sortedArr, 21));
            Assert.Equal(-1, SearchAlgo.BinarySearchLoop(sortedArr, 200));
        }


        [Fact]
        public void TernarySearch()
        {
            Assert.Equal(7, SearchAlgo.TernarySearch(sortedArr, 21));
            Assert.Equal(-1, SearchAlgo.TernarySearch(sortedArr, 200));
        }

        [Fact]
        public void JumpSearch()
        {
            Assert.Equal(7, SearchAlgo.JumpSearch(sortedArr, 21));
            Assert.Equal(-1, SearchAlgo.JumpSearch(sortedArr, 200));
        }

        [Fact]
        public void ExponentialSearch()
        {
            Assert.Equal(7, SearchAlgo.ExponentialSearch(sortedArr, 21));
            Assert.Equal(-1, SearchAlgo.ExponentialSearch(sortedArr, 200));
        }
    }
}