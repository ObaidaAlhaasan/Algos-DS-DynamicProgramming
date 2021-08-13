using Data.Structure.Trees;
using Xunit;

namespace Data.Structure.Tests
{
    public class MinPriorityQueueTests
    {
        [Fact]
        public void MinPriorityQueue_Insert()
        {
            var mQ = new MinPriorityQueue();

            mQ.Insert(30, "30");
            mQ.Insert(20, "20");
            mQ.Insert(10, "10");

            Assert.Equal(10, mQ.heap.Elements[0].Key);
        }


        [Fact]
        public void MinPriorityQueue_Remove()
        {
            var mQ = new MinPriorityQueue();

            mQ.Insert(30, "30");
            mQ.Insert(20, "20");
            mQ.Insert(10, "10");

            mQ.Remove();
            Assert.Equal(20, mQ.Remove()
            );
        }
    }
}