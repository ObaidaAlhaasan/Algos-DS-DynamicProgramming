using Data.Structure.Search;
using Xunit;

namespace Data.Structure.Tests.Search
{
    public class BinarySearchTests
    {
        private readonly int[] arr;

        public BinarySearchTests()
        {
            this.arr = new[] {3, 5, 6, 9, 11, 18, 20, 21, 24, 30};
        }

        [Fact]
        public void BinarySearch_Return_Index_Correctly_Rec()
        {
            Assert.Equal(1, BinarySearch.FindRec(arr, 5));
        }

        [Fact]
        public void BinarySearch_Return_MinusOne_Correctly_Rec()
        {
            Assert.Equal(-1, BinarySearch.FindRec(arr, 235));
        }


        [Fact]
        public void BinarySearch_Return_Index_Correctly_Iteration()
        {
            Assert.Equal(1, BinarySearch.FindIter(arr, 5));
        }

        [Fact]
        public void BinarySearch_Return_MinusOne_Correctly_Iteration()
        {
            Assert.Equal(-1, BinarySearch.FindIter(arr, 235));
        }
    }
}