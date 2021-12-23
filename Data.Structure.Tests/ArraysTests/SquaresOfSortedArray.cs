using System;
using System.Linq;
using Xunit;

namespace Data.Structure.Tests.ArraysTests
{
    public class SquaresOfSortedArray
    {
        [Fact]
        public void Test1()
        {
            var arr = new int[] {-4, -1, 0, 3, 10};
            var o = SortedSquares(arr);
            Assert.Equal(new int[] {0, 1, 9, 16, 100}, o);
        }

        [Fact]
        public void Test8()
        {
            var arr = new int[] {-7, -3, 2, 3, 11};
            var o = SortedSquares(arr);
            Assert.Equal(new int[] {4, 9, 9, 49, 121}, o);
        }

        public int[] SortedSquares(int[] nums)
        {
            nums = nums.Select(x => x * x).ToArray();
            Array.Sort(nums);
            return nums;
        }
    }
}