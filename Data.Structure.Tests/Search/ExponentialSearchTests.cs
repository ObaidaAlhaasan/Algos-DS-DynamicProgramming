using Data.Structure.Search;
using Xunit;

namespace Data.Structure.Tests.Search
{
    public class ExponentialSearchTests
    {
        private readonly int[] arr;

        public ExponentialSearchTests() => this.arr = new[] {3, 5, 6, 9, 11, 18, 20, 21, 24, 30};


        [Fact]
        public void ExponentialSearch_Return_Index_Correctly()
        {
            Assert.Equal(1, ExponentialSearch.Find(arr, 5));
        }

        [Fact]
        public void ExponentialSearch_Return_MinusOne_Correctly()
        {
            Assert.Equal(-1, ExponentialSearch.Find(arr, 235));
        }
    }
}