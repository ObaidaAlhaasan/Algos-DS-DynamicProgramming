using System;
using Data.Structure.Trees;
using static System.Console;

namespace Data.Structure
{
    class Program
    {
        static void Main(string[] args)
        {
            // TreeCalls();
            // TreeExercises();

            // AvlTreeCalls();
            // TrieCalls();

            GraphCalls();
        }

        private static void GraphCalls()
        {
            var gp = new Graph();

            gp.AddNode("A");
            gp.AddNode("B");
            gp.AddNode("C");

            gp.AddEdge("A", "B");
            gp.AddEdge("A", "C");
            gp.AddEdge("B", "A");

            gp.RemoveNode("C");
            gp.RemoveEdge("B", "A");
            gp.Print();
        }

        private static void TrieCalls()
        {
            var trie = new Trie();
            trie.Insert("cat");
            trie.Insert("can");
            trie.Insert("car");

            trie.TraversePreOrder();
            Console.WriteLine("=============");
            trie.TraversePostOrder();
        }

        private static void AvlTreeCalls()
        {
            var avlTree = new AvlTree();
            avlTree.Insert(40);
            avlTree.Insert(30);
            avlTree.Insert(20);
        }

        private static void TreeExercises()
        {
            var tree1 = new Tree();
            tree1.InsertRec(7);
            tree1.InsertRec(4);
            tree1.InsertRec(9);
            tree1.InsertRec(1);
            tree1.InsertRec(6);
            tree1.InsertRec(8);
            tree1.InsertRec(10);

            WriteLine(tree1.Size());
            WriteLine(tree1.LeavesCount());
            WriteLine(tree1.Max());
            WriteLine(tree1.Contains(10));
            WriteLine(tree1.Contains(16));
            WriteLine(tree1.AreSibling(1, 9));
            WriteLine(tree1.AreSibling(4, 9));
            foreach (var ancestor in tree1.GetAncestors(10)) WriteLine(ancestor);
        }

        private static int Factorial(int n)
        {
            if (n == 0)
                return 1;

            return n * Factorial(n - 1);
        }

        public static void TreeCalls()
        {
            var tree1 = new Tree();
            tree1.InsertRec(7);
            tree1.InsertRec(4);
            tree1.InsertRec(9);
            tree1.InsertRec(1);
            tree1.InsertRec(6);
            tree1.InsertRec(8);
            tree1.InsertRec(10);
            // WriteLine(tree1.EqualsTo(tree2));
            // tree1.SwapRoot();
            tree1.LevelOrderTraversal();

            WriteLine(tree1.IsBst());

            WriteLine("+++++++++++++++");
            foreach (var k in tree1.GetAtK(2)) WriteLine(k);
            WriteLine("+++++++++++++++");
            WriteLine("-----------");
            WriteLine("-----------");

            WriteLine(tree1.Find(8));
            WriteLine(tree1.Find(88));
            WriteLine(tree1.Find(-1));
            tree1.PreOrderTraversal();
            tree1.InOrderTraversal();
            tree1.PostOrderTraversal();
            WriteLine(tree1.Height());
            WriteLine(tree1.Min());

            var tree2 = new Tree();
            tree2.InsertRec(10);
            WriteLine(tree1.EqualsTo(tree2));
        }
    }
}