using System;

namespace Data.Structure.Trees
{
    public class AvlTree
    {
        public AvlNode Root { get; private set; }

        public void Insert(int val)
        {
            Root = Insert(val, Root);
        }

        private AvlNode Insert(int val, AvlNode root)
        {
            if (root == null)
                return new AvlNode(val);

            if (val > root.Value)
                root.Right = Insert(val, root.Right);
            else if (val < root.Value) root.Left = Insert(val, root.Left);

            SetHeight(root);

            return Balance(root);
        }

        private void SetHeight(AvlNode root) => root.Height = Math.Max(Height(root.Left), Height(root.Right)) + 1;

        private AvlNode Balance(AvlNode root)
        {
            if (IsLeftHeavy(root))
            {
                if (IsRightHeavy(root.Left))
                    root.Left = LeftRotation(root.Left);

                return RightRotation(root);
            }

            if (IsRightHeavy(root))
            {
                if (IsLeftHeavy(root.Right))
                    root.Right = RightRotation(root.Right);

                return LeftRotation(root);
            }

            return root;
        }

        //   30
        //  20
        // 10

        private AvlNode RightRotation(AvlNode root)
        {
            var newRoot = root.Left;
            root.Left = newRoot.Right;
            newRoot.Right = root;

            SetHeight(root);
            SetHeight(newRoot);
            return newRoot;
        }

        // 10
        //  20
        //   30

        private AvlNode LeftRotation(AvlNode root)
        {
            var newRoot = root.Right;
            root.Right = newRoot.Left;
            newRoot.Left = root;

            SetHeight(root);
            SetHeight(newRoot);
            return newRoot;
        }


        private bool IsLeftHeavy(AvlNode root) => GetBalanceFactor(root) > 1;
        private bool IsRightHeavy(AvlNode root) => GetBalanceFactor(root) < 1;


        //   (3) 30 (0)
        //  (2) 20 (0)
        // (1) 10  =
        // (0) 5  =

        //    20 
        //  10   30
        // 5


        private int GetBalanceFactor(AvlNode root) => root == null ? 0 : Height(root.Left) - Height(root.Right);


        private int Height(AvlNode? node) => node?.Height ?? -1;

        public class AvlNode
        {
            public AvlNode(int val)
            {
                Value = val;
            }

            public AvlNode(int val, AvlNode left, AvlNode right)
            {
                Value = val;
                Left = left;
                Right = right;
            }

            public AvlNode Left { get; set; }
            public AvlNode Right { get; set; }
            public int Value { get; set; }
            public int Height { get; set; }
        }
    }
}