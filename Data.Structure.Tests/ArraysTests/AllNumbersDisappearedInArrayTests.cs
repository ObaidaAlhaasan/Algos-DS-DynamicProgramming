using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Data.Structure.Tests.ArraysTests
{
    public class AllNumbersDisappearedInArrayTests
    {
        [Fact]
        public void Test1()
        {
            var ar = new int[] {4, 3, 2, 7, 8, 2, 3, 1};
            Assert.Equal(new int[] {5, 6}, FindDisappearedNumbers(ar));
        }

        [Fact]
        public void Test2()
        {
            var ar = new int[] {1, 1};
            Assert.Equal(new int[] {2}, FindDisappearedNumbers(ar));
        }

        [Fact]
        public void Test3()
        {
            var ar = new int[] {1, 2, 4, 6, 3, 7, 8};
            Assert.Equal(new int[] {5}, FindDisappearedNumbers(ar));
        }

        [Fact]
        public void Test4()
        {
            var ar = new int[] {1, 2, 3, 5};
            Assert.Equal(new int[] {4}, FindDisappearedNumbers(ar));
        }

        private IList<int> FindDisappearedNumbers(int[] nums)
        {
            var hash = new HashSet<int>(nums);
            var r = new List<int>();

            for (int i = 1; i <= nums.Length; i++)
            {
                if (hash.Contains(i)) continue;
                r.Add(i);
            }

            return r;
        }
    }
}