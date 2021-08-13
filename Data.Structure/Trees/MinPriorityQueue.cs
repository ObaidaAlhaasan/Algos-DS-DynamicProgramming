namespace Data.Structure.Trees
{
    public class MinPriorityQueue
    {
        public MinHeap heap { get; set; }

        public MinPriorityQueue()
        {
            heap = new MinHeap();
        }

        public void Insert(int key, string val)
        {
            heap.Insert(new MinHeap.Node {Key = key, Value = val});
        }

        public int Remove()
        {
            return heap.Remove().Key;
        }

        public bool IsEmpty()
        {
            return heap.IsEmpty();
        }
    }
}