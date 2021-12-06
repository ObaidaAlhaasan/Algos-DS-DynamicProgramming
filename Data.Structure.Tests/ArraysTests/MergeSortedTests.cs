using System;
using System.Threading.Tasks;
using Xunit;

namespace Data.Structure.Tests.ArraysTests
{
    public class MergeSortedTests
    {
        [Fact]
        public async Task Nothing()
        {
            var input = new[] { 1, 2, 3, 0, 0, 0 };
            var m = 3;
            var input2 = new[] { 2, 5, 6 };
            var n = 3;
            Merge(input, m, input2, n);
            Assert.Equal(new[] { 1, 2, 2, 3, 5, 6 }, input);
        }


        [Fact]
        public async Task MergeWithEmpty()
        {
            var input = new[] { 1 };
            var m = 1;
            var input2 = new int[] { };
            var n = 0;

            Merge(input, m, input2, n);

            Assert.Equal(new[] { 1 }, input);
        }


        [Fact]
        public async Task Merging()
        {
            var input = new[] { 0 };
            var m = 0;
            var input2 = new[] { 1 };
            var n = 1;

            Merge(input, m, input2, n);

            Assert.Equal(new[] { 1 }, input);
        }

        public void Merge(int[] arr, int m, int[] arr2, int n)
        {
            for (int i = 0; i < arr2.Length; i++)
                arr[m++] = arr2[i];

            Array.Sort(arr);
        }
    }
}