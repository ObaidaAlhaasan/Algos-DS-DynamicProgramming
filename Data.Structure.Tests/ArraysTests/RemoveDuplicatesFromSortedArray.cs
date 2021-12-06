using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Data.Structure.Tests.ArraysTests
{
    public class RemoveDuplicatesFromSortedArray
    {
        [Fact]
        public async Task Test1()
        {
            var arr = new[] { 1, 1, 2 };
            var k = RemoveDuplicates(arr);
            Assert.Equal(new[] { 1, 2, int.MaxValue }, arr);
            Assert.Equal(2, k);
        }

        [Fact]
        public async Task Test2()
        {
            var arr = new[] { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
            var k = RemoveDuplicates(arr);
            Assert.Equal(new[] { 0, 1, 2, 3, 4, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue, int.MaxValue }, arr);
            Assert.Equal(5, k);
        }

        [Fact]
        public async Task Test3()
        {
            var arr = new[] { 1, 1 };
            var k = RemoveDuplicates(arr);
            Assert.Equal(new[] { 1, int.MaxValue }, arr);
            Assert.Equal(1, k);
        }

        [Fact]
        public async Task Test4()
        {
            var arr = new[] { 1, 1, 2, 2, 3, 3, 4, 4 };
            var k = RemoveDuplicates(arr);
            Assert.Equal(new[] { 1, 2, 3, 4 }, arr.Take(k));
            Assert.Equal(4, k);
        }


        public int RemoveDuplicates(int[] arr)
        {
            var k = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                k++;
                if (i + 1 < arr.Length)
                {
                    var j = i + 1;
                    var c = 0;
                    while (j < arr.Length && arr[j] == arr[i])
                    {
                        arr[j] = int.MaxValue;
                        j++;
                        c++;
                    }

                    i += c;
                }
            }

            Array.Sort(arr);
            return k;
        }
    }
}