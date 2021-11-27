using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Data.Structure.Tests.Algos
{
    public class PrimeFactorsTests
    {
        [Fact]
        public async Task CanFactorIntoPrimes()
        {
            AssertPrimeFactors(ArrList(), 1);
            AssertPrimeFactors(ArrList(2), 2);
            AssertPrimeFactors(ArrList(3), 3);
            AssertPrimeFactors(ArrList(2, 2), 4);
            AssertPrimeFactors(ArrList(5), 5);
            AssertPrimeFactors(ArrList(2, 3), 6);
            AssertPrimeFactors(ArrList(7), 7);
            AssertPrimeFactors(ArrList(2, 2, 2), 8);
            AssertPrimeFactors(ArrList(3, 3), 9);
            AssertPrimeFactors(ArrList(2, 2, 3, 3, 5, 7, 11, 11, 13), 2 * 2 * 3 * 3 * 5 * 7 * 11 * 11 * 13);
        }

        private void AssertPrimeFactors(List<int> primeFactors, int n) => Assert.Equal(primeFactors, Of(n));

        private List<int> ArrList(params int[] nums) => new(nums);

        private List<int> Of(int n)
        {
            var factors = new List<int>();

            for (var divisor = 2; n > 1; divisor++)
            {
                for (; n % divisor == 0; n /= divisor)
                    factors.Add(divisor);
            }

            return factors;
        }
    }
}