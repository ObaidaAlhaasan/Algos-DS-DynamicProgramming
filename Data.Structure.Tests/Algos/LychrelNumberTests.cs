using Data.Structure.Algos;
using Xunit;

namespace Data.Structure.Tests.Algos
{
    public class LychrelNumberTests
    {
        private readonly int LIMIT = 40;

        [Fact]
        public void Facts()
        {
            ConversionAtIteration(1, 0);
            ConversionAtIteration(2, 0);
            ConversionAtIteration(10, 1);
            ConversionAtIteration(11, 0);
            ConversionAtIteration(19, 2);
            ConversionAtIteration(78, 4);
            ConversionAtIteration(89, 24);

            DoesNotConverges(196);
        }

        private void DoesNotConverges(int n) => ConversionAtIteration(n, LIMIT);

        private void ConversionAtIteration(int n, int iteration)
        {
            Assert.Equal(iteration, Lychrel.ConversionAtIteration(ulong.Parse(n.ToString()), LIMIT));
        }


        [Fact]
        public void Palindromes()
        {
            Assert.True(Lychrel.IsPalindrome(1));
            Assert.True(Lychrel.IsPalindrome(11));
            Assert.True(Lychrel.IsPalindrome(121));
            Assert.True(Lychrel.IsPalindrome(1234321));
        }

        [Fact]
        public void IsNotPalindromes()
        {
            Assert.False(Lychrel.IsPalindrome(10));
            Assert.False(Lychrel.IsPalindrome(12));
            Assert.False(Lychrel.IsPalindrome(123));
            Assert.False(Lychrel.IsPalindrome(12331));
            Assert.True(Lychrel.IsPalindrome(1234321));
        }


        [Fact]
        public void Reverse()
        {
            Reversed(2, Lychrel.Reverse(2));
            Reversed(22, Lychrel.Reverse(22));
            Reversed(333, Lychrel.Reverse(333));
            Reversed(321, Lychrel.Reverse(123));
            Reversed(5544, Lychrel.Reverse(4455));
            Reversed(135, Lychrel.Reverse(531));
        }

        private void Reversed(int expected, ulong actual) => Assert.Equal(ulong.Parse(expected.ToString()), actual);
    }
}