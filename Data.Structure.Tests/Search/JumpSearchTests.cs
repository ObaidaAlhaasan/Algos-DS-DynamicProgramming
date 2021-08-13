using Data.Structure.Search;
using Xunit;

namespace Data.Structure.Tests.Search
{
    public class JumpSearchTests
    {
        private readonly int[] arr;

        public JumpSearchTests()
        {
            this.arr = new[] {3, 5, 6, 9, 11, 18, 20, 21, 24, 30};
        }


        [Fact]
        public void JumpSearch_Return_Index_Correctly_Rec()
        {
            Assert.Equal(1, JumpSearch.Find(arr, 5));
        }

        [Fact]
        public void JumpSearch_Return_MinusOne_Correctly_Rec()
        {
            Assert.Equal(-1, JumpSearch.Find(arr, 235));
        }
    }
}