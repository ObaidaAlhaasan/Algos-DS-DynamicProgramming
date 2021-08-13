using System;
using Data.Structure.Trees;
using Xunit;
using Xunit.Abstractions;

namespace Data.Structure.Tests
{
    public class WeightedGraphTests
    {
        private readonly ITestOutputHelper _testOutputHelper;
        private readonly WeightedGraph gp = new();

        public WeightedGraphTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
            gp.AddNode("A");
            gp.AddNode("B");
            gp.AddNode("C");
        }

        [Fact]
        public void GetShortestPath_DijkstraAlgo_ShouldReturn_A_C_B()
        {
            gp.AddEdge("A", "B", 1);
            gp.AddEdge("B", "C", 2);
            gp.AddEdge("A", "C", 10);
            var graph = gp.GetShortestPath("A", "C");

            Assert.True(graph.Nodes.Contains("A"));
            Assert.True(graph.Nodes.Contains("B"));
            Assert.True(graph.Nodes.Contains("C"));
        }

        [Fact]
        public void GetShortestPath_DijkstraAlgo_ShouldThrow()
        {
            Assert.Throws<Exception>(() => gp.GetShortestPath("A", "X"));
        }

        [Fact]
        public void GetShortesPath_DijkAlgo_ShouldReturnDirectPath()
        {
            gp.AddEdge("A", "B", 3);
            gp.AddEdge("B", "C", 5);
            gp.AddEdge("A", "C", 1);
            var graph = gp.GetShortestPath("A", "C");

            Assert.True(graph.Nodes.Contains("A"));
            Assert.True(graph.Nodes.Contains("C"));
            Assert.False(graph.Nodes.Contains("B"));

            _testOutputHelper.WriteLine(graph.ToString());
        }

        [Fact]
        public void WeightedGraph_ReturnCorrect_HasCycleResultFalse()
        {
            gp.AddEdge("A", "B", 3);
            gp.AddEdge("B", "C", 5);

            Assert.False(gp.HasCycle());
        }

        [Fact]
        public void WeightedGraph_ReturnCorrect_HasCycleResultTrue()
        {
            var g = new WeightedGraph();
            g.AddNode("A");
            g.AddNode("B");
            g.AddNode("C");

            g.AddEdge("A", "B", 3);
            g.AddEdge("B", "C", 5);
            g.AddEdge("C", "A", 5);

            Assert.True(g.HasCycle());
        }


        [Fact]
        public void GetSpanningTree()
        {
            gp.AddNode("D");
            gp.AddEdge("A", "B", 3);
            gp.AddEdge("B", "D", 4);
            gp.AddEdge("C", "D", 5);
            gp.AddEdge("A", "C", 1);
            gp.AddEdge("B", "C", 2);

            var tree = gp.GetMinSpanningTree_PrimAlgo();
            tree.Print();
        }
    }
}