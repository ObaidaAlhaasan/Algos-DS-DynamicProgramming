using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Data.Structure.Tests.ArraysTests
{
    public class RemoveElementTests
    {
        [Fact]
        public async Task Test1()
        {
            var arr = new int[] { 3, 2, 2, 3 };
            var val = 3;
            var k = RemoveElement(arr, val);

            Assert.Equal(2, k);
            Assert.Equal(new[] { 2, 2 }, arr.Take(k));
        }

        [Fact]
        public async Task Test2()
        {
            var arr = new int[] { 0, 1, 2, 2, 3, 0, 4, 2 };
            var val = 2;
            var k = RemoveElement(arr, val);

            Assert.Equal(5, k);
            // 1 
            // Assert.Equal(new[] { 0, 0, 1, 3, 4 }, arr.Take(k));
            // 2 
            Assert.Equal(new[] { 0, 1, 3, 0, 4, 0, 4, 2 }, arr);
        }

        public int RemoveElement2(int[] nums, int val)
        {
            var k = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if (nums[i] == val)
                {
                    nums[i] = int.MaxValue;
                    k--;
                }

                k++;
            }

            Array.Sort(nums);
            return k;
        }

        public int RemoveElement(int[] nums, int val)
        {
            var retVal = nums.Where(item => item != val).ToArray();
            Array.Copy(retVal, 0, nums, 0, retVal.Length);

            return retVal.Length;
        }
    }
}