using Data.Structure.Recursion;
using Xunit;

namespace Data.Structure.Tests.Recursion
{
    public class RecursionAlgoTests
    {
        [Fact]
        public void ReverseString()
        {
            Assert.Equal("olleh", RecursionAlgo.ReverseString("hello"));
        }

        [Fact]
        public void IsPalindrome()
        {
            Assert.True(RecursionAlgo.IsPalindrome("kayak"));
            Assert.False(RecursionAlgo.IsPalindrome("hello"));
        }

        [Fact]
        public void DecimalToBinary()
        {
            Assert.Equal("11101001", RecursionAlgo.DecimalToBinary(233));
        }
    }
}