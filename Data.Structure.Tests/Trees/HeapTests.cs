using System;
using System.Collections.Generic;
using System.Linq;
using Data.Structure.Trees;
using Xunit;

namespace Data.Structure.Tests
{
    public class HeapTests
    {
        private readonly Heap _heap;

        public HeapTests()
        {
            _heap = new Heap();
        }

        [Fact]
        public void Heap_Has_InsertMethod()
        {
            _heap.Insert(10);
            Assert.Equal(_heap.Size, 1);
        }

        [Fact]
        public void Heap_Has_RemoveMethod()
        {
            _heap.Insert(10);
            _heap.Remove();

            Assert.Equal(_heap.Size, 0);
        }

        [Fact]
        public void Heap_BubbleUp_LargestNum_ToBeRoot()
        {
            _heap.Insert(10);
            _heap.Insert(5);
            _heap.Insert(17);
            _heap.Insert(4);
            _heap.Insert(22);

            Assert.Equal(22, _heap.Elements[0]);
        }

        [Fact]
        public void Heap_ThrowException_IF_Full()
        {
            for (var i = 0; i < Heap.MaxSize; i++) _heap.Insert(i);

            Assert.ThrowsAny<Exception>(() => _heap.Insert(100));
        }

        [Fact]
        public void Heap_WhenRemove_BubbleDown_Element_And_SetRoot_ToNextLargestItem()
        {
            _heap.Insert(10);
            _heap.Insert(5);
            _heap.Insert(17);
            _heap.Insert(4);
            _heap.Insert(22);

            Assert.Equal(22, _heap.Remove());
            Assert.Equal(17, _heap.Remove());
            Assert.Equal(10, _heap.Elements[0]);
        }

        [Fact]
        public void Remove_FromEmptyHeap_ThrowException()
        {
            Assert.Throws<Exception>(() => _heap.Remove());
        }

        [Fact]
        public void Remove_FromHeap_ItHandleEdgeCases_Of_NonExistingLeftOrRightChildren()
        {
            _heap.Insert(10);
            _heap.Insert(5);
            _heap.Insert(17);
            _heap.Insert(4);
            _heap.Insert(22);

            _heap.Remove();

            Assert.Equal(17, _heap.Elements[0]);
        }


        [Fact]
        public void Heap_Sort_Int_Array_ASC_DESC()
        {
            var ah = new Heap();
            var ascElements = new[] {5, 7, 2};
            ah.SortASC(ascElements);

            var dh = new Heap();
            var descElements = new[] {3, 1, -1};
            dh.SortDESC(descElements);

            Assert.True(Utils.IsSortedACS(descElements));
            Assert.True(Utils.IsSortsedDESC(ascElements));
        }
    }
}