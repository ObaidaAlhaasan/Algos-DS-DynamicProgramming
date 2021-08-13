using System.Linq;
using Data.Structure.Dynamic.Tabulation;
using Xunit;

namespace Data.Structure.Tests.Dynamic.TabulationTests
{
    public class TabulationTests
    {
        [Fact]
        public void FibOfNum()
        {
            Assert.Equal(8, Fib.G(6));
            Assert.Equal(21, Fib.G(8));
            Assert.Equal(12586269025, Fib.G(50));
        }

        [Fact]
        public void GridTravelerOfNum()
        {
            Assert.Equal(1, GridTraveler.G(1, 1));
            Assert.Equal(3, GridTraveler.G(2, 3));
            Assert.Equal(3, GridTraveler.G(3, 2));
            Assert.Equal(6, GridTraveler.G(3, 3));
            Assert.Equal(2333606220, GridTraveler.G(18, 18));
        }

        [Fact]
        public void CanSumNumFromArr()
        {
            Assert.Equal(true, CanSum.G(new[] { 2, 3 }, 7));
            Assert.Equal(true, CanSum.G(new[] { 5, 3, 4, 7 }, 7));
            Assert.Equal(false, CanSum.G(new[] { 2, 4 }, 7));
            Assert.Equal(true, CanSum.G(new[] { 2, 3, 5 }, 8));
            Assert.Equal(false, CanSum.G(new[] { 7, 14 }, 300));
        }

        [Fact]
        public void HowSumNumFromArr()
        {
            var l1 = HowSum.G(new[] { 2, 3 }, 7);

            Assert.True(l1?.Contains(2) == true && l1?.Contains(3) == true);

            var l2 = HowSum.G(new[] { 5, 3, 4, 7 }, 7);
            Assert.True(l2?.Contains(4));
            Assert.True(l2?.Contains(3));

            var l3 = HowSum.G(new[] { 2, 3, 5 }, 8);
            Assert.True(l3?.All(x => x == 2) == true && l3?.Count == 4);

            Assert.Equal(null, HowSum.G(new[] { 7, 14 }, 300));
        }

        [Fact]
        public void BestSumNumFromArr()
        {
            var l1 = BestSum.G(new[] { 2, 3 }, 7);

            Assert.True(l1?.Contains(7) == true && l1?.Count == 1);

            Assert.True(BestSum.G(new[] { 5, 3, 4, 7 }, 7)?.Contains(7));

            Assert.True(BestSum.G(new[] { 2, 3, 5 }, 8)?.Contains(3) == true);
            Assert.True(BestSum.G(new[] { 2, 3, 5 }, 8)?.Contains(5) == true);
            Assert.True(BestSum.G(new[] { 2, 3, 5 }, 8)?.Count == 2);

            var ints = BestSum.G(new[] { 1, 4, 5 }, 8);
            Assert.True(ints?.All(x => x == 4));

            var list = BestSum.G(new[] { 1, 2, 5, 25 }, 100);
            Assert.True(list?.All(x => x == 25));
        }
    }
}