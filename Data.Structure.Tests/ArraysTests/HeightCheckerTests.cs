using System;
using System.Dynamic;
using Xunit;

namespace Data.Structure.Tests.ArraysTests
{
    public class HeightCheckerTests
    {
        private readonly HeightChecker heightChecker;

        public HeightCheckerTests()
        {
            heightChecker = new HeightChecker();
        }


        [Fact]
        public void Test1()
        {
            var arr = new[] {1, 1, 4, 2, 1, 3};
            var r = heightChecker.Check(arr);
            Assert.Equal(3, r);
        }

        [Fact]
        public void Test2()
        {
            var arr = new[] {5, 1, 2, 3, 4};
            var r = heightChecker.Check(arr);
            Assert.Equal(5, r);
        }

        [Fact]
        public void Test3()
        {
            var arr = new[] {1, 2, 3, 4, 5};
            var r = heightChecker.Check(arr);
            Assert.Equal(0, r);
        }
    }

    public class HeightChecker
    {
        public int Check(int[] heights)
        {
            if (heights.Length is 0 or 1)
                return 0;

            var dest = (int[]) heights.Clone();

            Array.Sort(heights);

            int k = 0;
            for (int i = 0; i < heights.Length; i++)
            {
                if (heights[i] != dest[i])
                    k++;
            }

            return k;
        }
    }
}