using Data.Structure.Search;
using Xunit;

namespace Data.Structure.Tests.Search
{
    public class TernarySearchTests
    {
        private readonly int[] arr;

        public TernarySearchTests() => this.arr = new[] {3, 5, 6, 9, 11, 18, 20, 21, 24, 30};


        [Fact]
        public void TernarySearch_Return_Index_Correctly_Rec()
        {
            Assert.Equal(1, TernarySearch.FindRec(arr, 5));
        }

        [Fact]
        public void TernarySearch_Return_MinusOne_Correctly_Rec()
        {
            Assert.Equal(-1, TernarySearch.FindRec(arr, 235));
        }

    }
}