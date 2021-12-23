using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Data.Structure.Tests.ArraysTests
{
    public class ThirdMaxElementTests
    {
        [Fact]
        public void Test1()
        {
            var arr = new int[] {3, 2, 1};
            var o = ThirdMax(arr);
            Assert.Equal(1, o);
        }

        [Fact]
        public void Test2()
        {
            var arr = new int[] {1, 2};
            var o = ThirdMax(arr);
            Assert.Equal(2, o);
        }

        [Fact]
        public void Test3()
        {
            var arr = new int[] {2, 2, 3, 1};
            var o = ThirdMax(arr);
            Assert.Equal(1, o);
        }

        [Fact]
        public void Test4()
        {
            var arr = new int[] {1, 1, 2};
            var o = ThirdMax(arr);
            Assert.Equal(2, o);
        }

        [Fact]
        public void Test5()
        {
            var arr = new int[] {1, 2, 2, 5, 3, 5};
            var o = ThirdMax(arr);
            Assert.Equal(2, o);
        }

        [Fact]
        public void Test6()
        {
            var arr = new int[] {1, 14, 2, 16, 10, 20};
            var o = ThirdMax(arr);
            Assert.Equal(14, o);
        }

        [Fact]
        public void Test7()
        {
            var arr = new int[] {19, -10, 20, 14, 2, 16, 10};
            var o = ThirdMax(arr);
            Assert.Equal(16, o);
        }

        [Fact]
        public void Test8()
        {
            var arr = new int[] {3, 3, 4, 3, 4, 3, 0, 3, 3};
            var o = ThirdMax(arr);
            Assert.Equal(0, o);
        }

        private int ThirdMax(int[] arr)
        {
            if (arr.Length <= 2)
                return arr.Max();

            var ar = arr.Distinct();
            if (ar.Count() <= 2)
                return ar.Max();

            return ar.OrderByDescending(x => x).Skip(2).First();
        }
    }
}