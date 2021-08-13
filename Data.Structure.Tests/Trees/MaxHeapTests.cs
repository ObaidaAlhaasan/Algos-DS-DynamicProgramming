using Data.Structure.Trees;
using Xunit;

namespace Data.Structure.Tests
{
    public class MaxHeapTests
    {
        [Fact]
        public void Heapfiy_DoesSort_Array()
        {
            var heap = new MaxHeap();

            var arr3 = new int[] {2, 1, 4, 6, 7, 9};
            var arr = new int[] {5, 3, 8, 4, 1, 2};

            heap.Heapify(arr);

            var x = arr;
        }

        [Fact]
        public void Heap_ReturnCorrectNum_WhenCall_GetKAt()
        {
            var heap = new MaxHeap();
            var arr = new int[] {5, 3, 8, 4, 1, 2};
            heap.Heapify(arr);

            Assert.Equal(8, heap.GetAtK(arr, 1));
            Assert.Equal(5, heap.GetAtK(arr, 2));
        }
    }
}