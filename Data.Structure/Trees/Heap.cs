using System;
using System.Collections.Generic;

namespace Data.Structure.Trees
{
    public class Heap
    {
        public Heap(int size = MaxSize)
        {
            Elements = new int[MaxSize];
            Size = 0;
        }

        public int[] Elements { get; private set; }
        public int Size { get; private set; }
        public const int MaxSize = 100;

        public void Insert(int val)
        {
            if (IsFull())
                throw new Exception();

            Elements[Size++] = val;

            BubbleUp();
        }

        private bool IsFull() => Size >= Elements.Length;

        private void BubbleUp()
        {
            var index = Size - 1;

            while (index > 0 && Elements[index] > Elements[ParentIndex(index)])
            {
                Swap(index, ParentIndex(index));

                // resetIndex to continue bubbling and use the newIndex that the Item got
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

        public int Remove()
        {
            if (IsEmpty())
                throw new Exception();

            var root = Elements[0];
            Elements[0] = Elements[--Size];

            BubbleDown();

            return root;
        }

        public bool IsEmpty() =>
            Size <= 0;

        private void BubbleDown()
        {
            var index = 0;

            while (index <= Size && !IsValidParent(index))
            {
                Swap(index, LargerChildIndex(index));

                index = LargerChildIndex(index);
            }
        }

        private bool IsValidParent(int index)
        {
            if (!HasLeftChild(index))
                return true;

            var isValid = Elements[index] >= LeftChild(index);

            if (HasRightChild(index))
                isValid &= Elements[index] >= RightChild(index);

            return isValid;
        }

        private bool HasLeftChild(int index) => LeftChildIndex(index) <= Size;

        private bool HasRightChild(int index) => RightChildIndex(index) <= Size;

        private int LargerChildIndex(int index)
        {
            if (!HasLeftChild(index))
                return index;

            if (!HasRightChild(index))
                return LeftChildIndex(index);

            return LeftChild(index) > RightChild(index) ? LeftChildIndex(index) : RightChildIndex(index);
        }

        private int RightChild(int index) => Elements[RightChildIndex(index)];

        private int LeftChild(int index) => Elements[LeftChildIndex(index)];

        private int RightChildIndex(int index) => index * 2 + 2;

        private int LeftChildIndex(int index) => index * 2 + 1;

        public void SortASC(int[] ascElements)
        {
            for (var index = 0; index < ascElements.Length; index++)
            {
                Insert(ascElements[index]);
            }

            for (var i = 0; i < ascElements.Length; i++)
                ascElements[i] = Remove();
        }


        public void SortDESC(int[] ascElements)
        {
            foreach (var t in ascElements)
                Insert(t);

            for (var i = ascElements.Length - 1; i >= 0; i--)
                ascElements[i] = Remove();
        }

        public int Max()
        {
            if (IsEmpty())
                throw new Exception();

            return Elements[0];
        }
    }
}