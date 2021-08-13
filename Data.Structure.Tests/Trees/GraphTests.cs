using System.Diagnostics.Contracts;
using Data.Structure.Trees;
using Xunit;

namespace Data.Structure.Tests
{
    public class GraphTests
    {
        private readonly Graph gp;

        public GraphTests()
        {
            this.gp = new Graph();
            gp.AddNode("A");
            gp.AddNode("B");
            gp.AddNode("C");
            gp.AddNode("D");
            gp.AddEdge("A", "B");
            gp.AddEdge("B", "D");
            gp.AddEdge("D", "C");
            gp.AddEdge("A", "C");
        }

        [Fact]
        public void GraphInsert()
        {
            gp.RemoveEdge("B", "C");

            gp.Print();
        }


        [Fact]
        public void Traverse_Recursive()
        {
            gp.TraverseDepthFirstRecursive("A");
            gp.TraverseDepthFirstRecursive("C");
        }

        [Fact]
        public void Traverse_Iterative()
        {
            gp.TraverseDepthFirstIterative("A");
        }

        [Fact]
        public void TraverseBreadthFirst()
        {
            gp.TraverseBreadthFirstIterative("A");
        }


        [Fact]
        public void TopologicalSort()
        {
            var g = new Graph();
            g.AddNode("A");
            g.AddNode("B");
            g.AddNode("X");
            g.AddNode("P");

            g.AddEdge("X", "A");
            g.AddEdge("X", "B");
            g.AddEdge("A", "P");
            g.AddEdge("B", "P");

            var topologicalSort = g.TopologicalSort();
            Assert.True(topologicalSort.Length > 0);
        }


        [Fact]
        public void HasNotCycle()
        {
            Assert.False(gp.HasCycle());
        }


        [Fact]
        public void HasCycle()
        {
            gp.AddEdge("C", "A");
            Assert.True(gp.HasCycle());
        }
    }
}