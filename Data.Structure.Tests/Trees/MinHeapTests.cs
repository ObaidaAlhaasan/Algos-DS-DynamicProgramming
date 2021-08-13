using System.Linq;
using Data.Structure.Trees;
using Xunit;

namespace Data.Structure.Tests.Trees
{
    public class MinHeapTests
    {
        [Fact]
        public void MinHeap_InsertAndBubbleUpCorrectly_OnInsert()
        {
            var heap = new MinHeap();

            heap.Insert(new MinHeap.Node {Key = 3, Value = "3"});
            heap.Insert(new MinHeap.Node {Key = 2, Value = "2"});
            heap.Insert(new MinHeap.Node {Key = 1, Value = "1"});

            Assert.Equal(1, heap.Elements.First().Key);
        }

        [Fact]
        public void MinHeap_InsertAndBubbleDownCorrectly_OnRemove()
        {
            var heap = new MinHeap();
            heap.Insert(new MinHeap.Node {Key = 3, Value = "3"});
            heap.Insert(new MinHeap.Node {Key = 2, Value = "2"});
            heap.Insert(new MinHeap.Node {Key = 1, Value = "1"});

            heap.Remove();

            Assert.Equal(2, heap.Remove().Key);
        }
    }
}