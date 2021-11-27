using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Structure.Algos;
using Xunit;

namespace Data.Structure.Tests.Algos
{
    public class SortIntTests
    {
        private readonly IntSorter _intSorter = new();

        [Fact]
        public async Task Sort()
        {
            AssertSorted(IntList(), IntList());
            AssertSorted(IntList(1), IntList(1));
            AssertSorted(IntList(2, 1), IntList(1, 2));
            AssertSorted(IntList(1, 3, 2), IntList(1, 2, 3));
            AssertSorted(IntList(1, 4, 2), IntList(1, 2, 4));
            AssertSorted(IntList(3, 2, 1), IntList(1, 2, 3));

            AssertSortedBigInt();
        }

        [Fact]
        private void AssertSortedBigInt()
        {
            var n = 25000;
            var unsorted = new List<int>();
            var rand = new Random();

            for (var i = 0; i < n; i++)
                unsorted.Add(rand.Next(n));

            var sorted = _intSorter.Sort(unsorted).ToArray();

            for (int i = 0; i < sorted.Length - 1; i++)
            {
                Assert.True(sorted[i] <= sorted[i + 1]);
            }
        }

        [Fact]
        private void AssertSortedBigIntII()
        {
            var n = 25000;
            var unsorted = new List<int>();
            var rand = new Random();

            for (var i = 0; i < n; i++)
                unsorted.Add(rand.Next(n));

            var sorted = _intSorter.SortII(unsorted).ToArray();

            for (int i = 0; i < sorted.Length - 1; i++)
            {
                Assert.True(sorted[i] <= sorted[i + 1]);
            }
        }
        

        [Fact]
        public async Task Sort_II()
        {
            AssertSortedII(IntList(), IntList());
            AssertSortedII(IntList(1), IntList(1));
            AssertSortedII(IntList(2, 1), IntList(1, 2));
            AssertSortedII(IntList(2, 1, 3), IntList(1, 2, 3));
            AssertSortedII(IntList(2, 3, 1), IntList(1, 2, 3));
            AssertSortedII(IntList(3, 2, 1), IntList(1, 2, 3));
            AssertSortedII(IntList(1, 3, 2), IntList(1, 2, 3));
            AssertSortedII(IntList(3, 2, 1), IntList(1, 2, 3));
            AssertSortedII(IntList(3, 2, 2, 1), IntList(1, 2, 2, 3));
            
            AssertSortedBigIntII();
        }

        private void AssertSortedII(IEnumerable<int> unsortedList, IEnumerable<int> sortedList)
        {
            Assert.Equal(sortedList, _intSorter.SortII(unsortedList.ToList()));
        }

        private void AssertSorted(IEnumerable<int> unsortedList, IEnumerable<int> sortedList)
        {
            Assert.Equal(sortedList, _intSorter.Sort(unsortedList));
        }

        private IEnumerable<int> IntList(params int[] n)
        {
            return new List<int>(n);
        }
    }
}