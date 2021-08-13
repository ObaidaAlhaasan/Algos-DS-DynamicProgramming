namespace Data.Structure.Trees
{
    public class PriorityQueueHeap
    {
        private readonly Heap _heap;

        public PriorityQueueHeap(int size)
        {
            _heap = new Heap(size);
        }

        public void Enqueue(int val) => _heap.Insert(val);

        public int Dequeue() => _heap.Remove();

        public bool IsEmpty() => _heap.IsEmpty();
    }
}