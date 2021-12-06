using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;
using Xunit.Sdk;

namespace Data.Structure.Tests.ArraysTests
{
    public class DuplicateZerosTests
    {
        [Fact]
        public void HaveZeros_ShouldDuplicate()
        {
            int[] input = { 1, 0, 2, 3, 0, 4, 5, 0 };
            DuplicateZeros(input);
            Assert.Equal(new[] { 1, 0, 0, 2, 3, 0, 0, 4 }, input);
        }

        [Fact]
        public void HaveZeros_ShouldDuplicate1()
        {
            int[] input = { 1, 0, 2, 3, 0, 4, 5, 0 };
            DuplicateZeros(input);
            Assert.Equal(new[] { 1, 0, 0, 2, 3, 0, 0, 4 }, input);
        }


        [Fact]
        public void AllZeros()
        {
            int[] input = { 0, 0, 0, 0, 0, 0, 0 };
            DuplicateZeros(input);

            Assert.Equal(new[] { 0, 0, 0, 0, 0, 0, 0 }, input);
        }

        [Fact]
        public void ShiftTest()
        {
            int[] input = { 1, 0, 2, 3, 4 };
            Shift(input, 2);
        }

        public void DuplicateZeros(int[] arr)
        {
            for (var i = 0; i < arr.Length; i++)
                if (arr[i] == 0)
                    Shift2(arr, ++i);
        }

        private void Shift2(int[] arr, int i)
        {
            if (i == arr.Length)
                return;

            // copy value of next to zero element
            var current = arr[i];

            // assign it to zero
            arr[i] = 0;

            // loop to shift elements to right
            while (i < arr.Length)
            {
                var inRange = i + 1 < arr.Length;
                if (inRange)
                {
                    var nextEle = arr[i + 1];
                    arr[++i] = current;
                    current = nextEle;
                }
                else
                {
                    i++;
                }
            }
        }

        private void Shift(int[] input, int ind)
        {
            if (ind == input.Length) return;

            var currentEleTemp = input[ind];

            input[ind] = 0;

            while (ind < input.Length)
            {
                if (ind + 1 < input.Length)
                {
                    var nextEle = input[ind + 1];
                    input[++ind] = currentEleTemp;
                    currentEleTemp = nextEle;
                }
                else
                    ind++;
            }
        }
    }

    public class CheckIfNAndItsDoubleExist
    {
        [Fact]
        public async Task Test1()
        {
            var arr = new[] { 10, 2, 5, 3 };

            Assert.True(CheckIfExist(arr));
        }

        [Fact]
        public async Task Test2()
        {
            var arr = new[] { 7, 1, 14, 11 };

            Assert.True(CheckIfExist(arr));
        }


        [Fact]
        public async Task Test3()
        {
            var arr = new[] { 3, 1, 7, 11 };

            Assert.False(CheckIfExist(arr));
        }

        public bool CheckIfExist(int[] arr)
        {
            var s = new HashSet<decimal>();

            for (var i = 0; i < arr.Length; i++)
            {
                if (s.Contains(arr[i] * 2) || s.Contains((decimal)arr[i] / 2))
                    return true;

                s.Add(arr[i]);
            }

            return false;
        }
    }

    public class ValidMountainArrayTests
    {
        [Fact]
        public async Task Test1()
        {
            var arr = new[] { 1, 2 };
            Assert.False(ValidMountainArray(arr));
        }

        [Fact]
        public async Task Test2()
        {
            var arr = new[] { 3, 5, 5 };
            Assert.False(ValidMountainArray(arr));
        }

        [Fact]
        public async Task Test3()
        {
            var arr = new[] { 0, 3, 2, 1 };
            Assert.True(ValidMountainArray(arr));
        }

        [Fact]
        public async Task Test4()
        {
            var arr = new[] { 0, 2, 3, 4, 5, 2, 1, 0 };
            Assert.True(ValidMountainArray(arr));
        }

        [Fact]
        public async Task Test5()
        {
            var arr = new[] { 0, 2, 3, 3, 5, 2, 1, 0 };
            Assert.False(ValidMountainArray(arr));
        }

        [Fact]
        public async Task Test6()
        {
            var arr = new[] { 1, 3, 2 };
            Assert.True(ValidMountainArray(arr));
        }

        [Fact]
        public async Task Test7()
        {
            var arr = new[] { 0, 1, 2, 3, 4, 8, 9, 10, 11, 12, 11 };
            Assert.True(ValidMountainArray(arr));
        }

        [Fact]
        public async Task Test8()
        {
            var arr = new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.False(ValidMountainArray(arr));
        }

        [Fact]
        public async Task Test9()
        {
            var arr = new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };

            Assert.False(ValidMountainArray(arr));
        }


        [Fact]
        public async Task Test10()
        {
            var arr = new[] { 2, 0, 2 };

            Assert.False(ValidMountainArray(arr));
        }


        [Fact]
        public async Task Test11()
        {
            var arr = new[] { 0, 1, 2, 1, 2 };

            Assert.False(ValidMountainArray(arr));
        }


        [Fact]
        public async Task Test12()
        {
            var arr = new[] { 1, 1, 1, 1, 1, 1, 1, 2, 1 };

            Assert.False(ValidMountainArray(arr));
        }

        public bool ValidMountainArray(int[] arr)
        {
            if (arr.Length < 3)
                return false;

            var state = "";
            var isSortedAsc = true;
            var isSortedDesc = true;

            if (arr[0] > arr[1])
                return false;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                var next = arr[i + 1];

                if (next < arr[i])
                {
                    if (state == "")
                        return false;

                    state = "Dec";
                    isSortedAsc = false;
                }
                else if (next > arr[i])
                {
                    if (state == "")
                        state = "Inc";

                    isSortedDesc = false;
                }
                else
                {
                    return false;
                }

                if (state == "Inc" && next <= arr[i])
                    return false;

                if (state == "Dec" && next >= arr[i])
                    return false;
            }


            return !isSortedAsc && !isSortedDesc;
        }
    }
}