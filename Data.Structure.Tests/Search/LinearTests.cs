using Data.Structure.Search;
using Xunit;

namespace Data.Structure.Tests.Search
{
    public class LinearTests
    {
        [Fact]
        public void Linear_Return_Minus_One()
        {
            var arr = new[] {1, 4, 65, 76, 21};

            Assert.Equal(-1, LinearSearch.Find(arr, 55));
        }

        [Fact]
        public void Linear_Return_Index()
        {
            var arr = new[] {1, 4, 65, 76, 21};

            Assert.Equal(2, LinearSearch.Find(arr, 65));
        }
    }
}