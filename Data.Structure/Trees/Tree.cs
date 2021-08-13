using System;
using System.Collections.Generic;

namespace Data.Structure.Trees
{
    public class Tree
    {
        public Node Root { get; set; }

        public void Insert(int val)
        {
            if (SetRootIfNull(val))
                return;

            var node = Root;
            while (true)
            {
                if (val > node.Value)
                {
                    if (node.Right == null)
                    {
                        node.Right = new Node(val);
                        return;
                    }

                    node = node.Right;
                }
                else
                {
                    if (node.Left == null)
                    {
                        node.Left = new Node(val);
                        return;
                    }

                    node = node.Left;
                }
            }
        }

        private bool SetRootIfNull(int val)
        {
            if (Root != null) return false;

            Root = new Node(val);
            return true;
        }

        public void InsertRec(int val)
        {
            if (SetRootIfNull(val))
                return;


            Root = InsertRec(Root, val);
        }

        private Node InsertRec(Node root, int val)
        {
            if (root == null)
                return new Node(val);

            if (val > root.Value)
                root.Right = InsertRec(root.Right, val);
            else
                root.Left = InsertRec(root.Left, val);

            return root;
        }


        public class Node
        {
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int Value { get; set; }

            public int Height { get; set; }

            public Node(int value) => Value = value;

            public Node(int value, Node? left, Node? right)
            {
                Left = left;
                Right = right;
                Value = value;
            }

            public override string ToString()
            {
                return $"Value: {Value.ToString()}";
            }

            public bool IsLeaf() => Left == null && Right == null;
        }

        public bool Find(int val) => Find(Root, val);

        private bool Find(Node root, int val)
        {
            if (root == null)
                return false;

            if (root.Value == val)
                return true;

            if (val > root.Value)
                return Find(root.Right, val);

            if (val < root.Value)
                return Find(root.Left, val);

            return false;
        }

        public void PreOrderTraversal()
        {
            Console.WriteLine("================= P =================");
            PreOrderTraversal(Root);
            Console.WriteLine("================= P =================");
        }

        private void PreOrderTraversal(Node root)
        {
            if (root == null)
                return;

            Console.WriteLine(root.Value);

            PreOrderTraversal(root.Left);
            PreOrderTraversal(root.Right);
        }

        public void InOrderTraversal()
        {
            Console.WriteLine("================= I =================");
            InOrderTraversal(Root);
            Console.WriteLine("================= I =================");
        }

        private void InOrderTraversal(Node root)
        {
            if (root == null)
                return;

            InOrderTraversal(root.Left);
            Console.WriteLine(root.Value);
            InOrderTraversal(root.Right);
        }

        public void PostOrderTraversal()
        {
            Console.WriteLine("================= P =================");
            PostOrderTraversal(Root);
            Console.WriteLine("================= P =================");
        }

        private void PostOrderTraversal(Node root)
        {
            if (root == null)
                return;

            PostOrderTraversal(root.Left);
            PostOrderTraversal(root.Right);
            Console.WriteLine(root.Value);
        }

        public int Height()
        {
            return Height(Root);
        }

        private int Height(Node root)
        {
            if (root == null)
                return -1;

            if (root.IsLeaf())
                return 0;

            var lH = Height(root.Left);
            var rH = Height(root.Right);

            return 1 + Math.Max(lH, rH);
        }

        public int Min() => Min(Root);

        private int Min(Node root)
        {
            if (root == null)
                return 0;

            if (root.IsLeaf())
                return root.Value;

            return Math.Min(Math.Min(Min(root.Left), Min(root.Right)), root.Value);
        }

        public bool EqualsTo(Tree tree2) => EqualsTo(Root, tree2.Root);

        private bool EqualsTo(Node root1, Node root2)
        {
            if (root1 == null && root2 == null)
                return true;

            if (root1 != null && root2 != null)
            {
                var lE = EqualsTo(root1.Left, root2.Left);
                var rE = EqualsTo(root1.Right, root2.Right);
                return lE && rE && root1.Value == root2.Value;
            }

            return false;
        }

        public bool IsBst() => IsBst(Root, int.MinValue, int.MaxValue);

        private bool IsBst(Node root, int minValue, int maxValue)
        {
            if (root == null)
                return true;

            if (root.Value < minValue || root.Value > maxValue)
                return false;

            var lIsBst = IsBst(root.Left, minValue, root.Value - 1);
            var rIsBst = IsBst(root.Right, root.Value + 1, maxValue);

            return lIsBst && rIsBst;
        }

        public void SwapRoot()
        {
            var temp = Root.Left;
            Root.Left = Root.Right;
            Root.Right = temp;
        }

        public IEnumerable<int> GetAtK(int k)
        {
            var list = new List<int>();
            GetAtK(Root, k, list);
            return list;
        }

        private void GetAtK(Node root, int i, List<int> list)
        {
            if (root == null)
                return;

            if (i == 0)
            {
                list.Add(root.Value);
                return;
            }

            GetAtK(root.Right, i - 1, list);
            GetAtK(root.Left, i - 1, list);
        }

        public void LevelOrderTraversal()
        {
            LevelOrderTraversal(Root);
        }

        private void LevelOrderTraversal(Node root)
        {
            var height = Height(root);
            for (int i = 0; i <= height; i++)
            {
                var nodes = GetAtK(i);
                foreach (var node in nodes) Console.WriteLine(node);
            }
        }

        public int Size()
        {
            var s = 0;
            Size(Root, ref s);
            return s;
        }

        private void Size(Node root, ref int i)
        {
            if (root == null)
                return;

            i++;

            Size(root.Left, ref i);
            Size(root.Right, ref i);
        }

        public int LeavesCount()
        {
            var count = 0;
            LeavesCount(Root, ref count);
            return count;
        }

        private void LeavesCount(Node root, ref int count)
        {
            if (root == null)
                return;

            if (root.IsLeaf()) count++;

            LeavesCount(root.Left, ref count);
            LeavesCount(root.Right, ref count);
        }

        public int Max() => Max(Root);

        private int Max(Node root)
        {
            if (root == null)
                return 0;

            if (root.IsLeaf())
                return root.Value;

            return Math.Max(Math.Max(Max(root.Left), Max(root.Right)), root.Value);
        }

        public bool Contains(int val) => Contains(Root, val);

        private bool Contains(Node root, int val)
        {
            if (root == null)
                return false;

            if (root.Value == val)
                return true;

            return Contains(root.Left, val) || Contains(root.Right, val);
        }

        public bool AreSibling(int first, int second) => AreSibling(Root, first, second);

        private bool AreSibling(Node root, int first, int second)
        {
            if (root == null)
                return false;

            if (root.Left != null && root.Left.Value == first && root.Right != null && root.Right.Value == second ||
                root.Right != null && root.Right.Value == first && root.Left != null && root.Left.Value == second
            )
                return true;

            return false;
        }

        public IList<int> GetAncestors(int val)
        {
            var list = new List<int>();

            GetAncestors(Root, val, list);

            return list;
        }

        private bool GetAncestors(Node root, int val, List<int> list)
        {
            if (root == null)
                return false;

            if (root.Value == val)
                return true;

            if (GetAncestors(root.Left, val, list))
            {
                list.Add(root.Value);
                return true;
            }

            if (GetAncestors(root.Right, val, list))
            {
                list.Add(root.Value);
                return true;
            }

            return false;
        }

        private bool IsBalanced() => IsBalanced(Root);

        private bool IsBalanced(Node root)
        {
            if (root == null)
                return true;

            var balanceFactor = Height(root.Left) - Height(root.Right);

            return balanceFactor <= 1 && IsBalanced(root.Left) && IsBalanced(root.Right);
        }
    }
}