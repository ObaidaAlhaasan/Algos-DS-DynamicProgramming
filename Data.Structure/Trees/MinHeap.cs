using System;

namespace Data.Structure.Trees
{
    public class MinHeap
    {
        public Node[] Elements { get; set; }
        public int Size { get; set; }

        public MinHeap()
        {
            Elements = new Node[10];
        }

        public void Insert(Node element)
        {
            if (IsFull())
                throw new Exception();

            Elements[Size++] = element;

            BubbleUp();
        }

        public Node Remove()
        {
            if (IsEmpty())
                throw new Exception();

            var element = Elements[0];

            Elements[0] = Elements[--Size];

            BubbleDown();

            return element;
        }

        private void BubbleDown()
        {
            var index = 0;

            while (index <= Size && !ValidParent(index))
            {
                var smallerIndex = SmallerIndex(index);
                Swap(index, smallerIndex);
                index = smallerIndex;
            }
        }

        private bool ValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            var validParent = Elements[index].Key <= LeftChild(index).Key;
            if (HasRightChild(index))
            {
                validParent &= Elements[index].Key <= Elements[RightIndex(index)].Key;
            }

            return validParent;
        }

        private Node LeftChild(int index)
        {
            return Elements[LeftIndex(index)];
        }

        private Node RightChild(int index)
        {
            return Elements[RightIndex(index)];
        }

        private bool HasLeftChild(int index) => LeftIndex(index) <= Size;
        private bool HasRightChild(int index) => RightIndex(index) <= Size;

        private int SmallerIndex(int index)
        {
            if (!HasLeftChild(index))
            {
                return index;
            }

            if (!HasRightChild(index))
            {
                return LeftIndex(index);
            }

            return LeftChild(index).Key < RightChild(index).Key ? LeftIndex(index) : RightIndex(index);
        }

        private int LeftIndex(int index) => index * 2 + 1;

        private int RightIndex(int index) => index * 2 + 2;

        private void BubbleUp()
        {
            var index = Size - 1;

            while (index > 0 && Elements[index].Key < Elements[ParentIndex(index)].Key)
            {
                Swap(index, ParentIndex(index));

                index = ParentIndex(index);
            }
        }

        private void Swap(int index, int parentIndex)
        {
            var temp = Elements[index];
            Elements[index] = Elements[parentIndex];
            Elements[parentIndex] = temp;
        }

        private int ParentIndex(int index) => (index - 1) / 2;

        public bool IsEmpty()
        {
            return Size == 0;
        }

        public bool IsFull()
        {
            return Size >= Elements.Length;
        }

        public class Node
        {
            public int Key { get; set; }
            public string Value { get; set; }
        }
    }
}