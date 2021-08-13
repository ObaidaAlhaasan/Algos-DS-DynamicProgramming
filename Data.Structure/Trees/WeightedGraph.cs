using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml;

namespace Data.Structure.Trees
{
    public class WeightedGraph
    {
        public Dictionary<string, Node> Nodes { get; set; } = new();

        public void AddNode(string label) => Nodes.Add(label, new Node(label));

        public void AddEdge(string from, string to, int weight)
        {
            var fromNode = Nodes.GetValueOrDefault(from);
            var toNode = Nodes.GetValueOrDefault(to);
            if (fromNode == null || toNode == null)
                throw new Exception();

            fromNode.AddEdge(toNode, weight);
            toNode.AddEdge(fromNode, weight);
        }

        public GraphPath GetShortestPath(string from, string to)
        {
            var fromNode = Nodes.GetValueOrDefault(from);
            var toNode = Nodes.GetValueOrDefault(to);
            if (fromNode == null || toNode == null)
                throw new Exception();

            var previousNodes = new Dictionary<Node, Node>();
            var queue = new SortedSet<NodeEntry>(new NodeEntryComparer());
            var visited = new HashSet<Node>();

            var distances = Nodes.ToDictionary(node => node.Value, node => int.MaxValue);

            distances[fromNode] = 0;

            queue.Add(new NodeEntry {Node = fromNode, Priority = 0});

            while (queue.Count > 0)
            {
                var currentEntry = queue.First();
                var currentNode = currentEntry.Node;
                queue.Remove(currentEntry);

                visited.Add(currentNode);

                foreach (var edge in currentNode.GetEdges())
                {
                    if (visited.Contains(edge.To))
                        continue;

                    var newDistance = distances.GetValueOrDefault(currentNode) + edge.Weight;
                    if (newDistance < distances.GetValueOrDefault(edge.To))
                    {
                        distances[edge.To] = newDistance;
                        previousNodes[edge.To] = currentNode;
                        queue.Add(new NodeEntry {Node = edge.To, Priority = newDistance});
                    }
                }
            }

            return BuildPath(toNode, previousNodes);
        }

        private GraphPath BuildPath(Node toNode, Dictionary<Node, Node> previousNodes)
        {
            var stack = new Stack<Node>();

            stack.Push(toNode);
            var previous = previousNodes.GetValueOrDefault(toNode);

            while (previous != null)
            {
                stack.Push(previous);
                previous = previousNodes.GetValueOrDefault(previous);
            }

            return new GraphPath(stack.Select(x => x.Label).ToList());
        }


        public void Print()
        {
            foreach (var node in Nodes)
            {
                var edges = node.Value.GetEdges();
                if (edges.Count > 0)
                {
                    var l = edges.Select(x => x.To.Label);
                    Console.WriteLine($"{node.Key} Is connected to [{string.Join(", ", l)}]");
                }
            }
        }

        public class Node
        {
            public IList<Edge> ConnectedEdges { get; set; } = new List<Edge>();
            public string Label { get; private set; }

            public Node(string label)
            {
                Label = label;
            }

            public void AddEdge(Node toNode, int weight) => ConnectedEdges.Add(new Edge(this, toNode, weight));

            public IList<Edge> GetEdges() => ConnectedEdges;

            public override string ToString() => Label;
        }

        public class NodeEntry
        {
            public Node Node { get; set; }
            public int Priority { get; set; }
        }

        public class Edge
        {
            public Node From { get; private set; }
            public Node To { get; private set; }
            public int Weight { get; private set; }

            public Edge(Node from, Node to, int weight)
            {
                From = from;
                To = to;
                Weight = weight;
            }

            public override string ToString()
            {
                return $"From -> {From} - To -> {To} - W {Weight.ToString()}";
            }
        }

        public bool HasCycle()
        {
            var visited = new HashSet<Node>();
            foreach (var node in Nodes)
                if (!visited.Contains(node.Value) && HasCycle(node.Value, visited, null))
                    return true;

            return false;
        }

        private bool HasCycle(Node node, ISet<Node> visited, Node parent)
        {
            visited.Add(node);

            foreach (var edge in node.GetEdges())
            {
                if (edge.To == parent)
                    continue;

                if (visited.Contains(edge.To) || HasCycle(edge.To, visited, node))
                    return true;
            }

            return false;
        }

        public WeightedGraph GetMinSpanningTree_PrimAlgo()
        {
            var tree = new WeightedGraph();

            var edges = new SortedSet<Edge>(Comparer<Edge>.Create((e, e1) => e.Weight.CompareTo(e1.Weight)));

            if (tree.IsEmpty())
                return tree;

            var startNode = Nodes.Values.FirstOrDefault();
            edges.UnionWith(startNode.ConnectedEdges);

            tree.AddNode(startNode.Label);

            if (startNode.ConnectedEdges.Count == 0)
            {
                return tree;
            }

            while (tree.Nodes.Count < Nodes.Count)
            {
                var minEdge = edges.FirstOrDefault();
                edges.Remove(minEdge);

                var nextNode = minEdge.To;
                if (tree.ContainsNode(nextNode.Label))
                    continue;

                tree.AddNode(nextNode.Label);
                tree.AddEdge(minEdge.From.Label, nextNode.Label, minEdge.Weight);

                foreach (var edge in nextNode.GetEdges())
                    if (!tree.ContainsNode(edge.To.Label))
                        edges.Add(edge);
            }

            return tree;
        }

        private bool IsEmpty()
        {
            return Nodes.Count == 0;
        }

        public bool ContainsNode(string label) => Nodes.ContainsKey(label);
    }

    public class GraphPath
    {
        public GraphPath(List<string> prvNodes)
        {
            Nodes = prvNodes;
        }

        public List<string> Nodes { get; private set; } = new List<string>();


        public override string ToString()
        {
            return Nodes.Aggregate("", (current, node) => current + node + ", ");
        }
    }

    public class NodeEntryComparer : IComparer<WeightedGraph.NodeEntry>
    {
        public int Compare(WeightedGraph.NodeEntry x, WeightedGraph.NodeEntry y)
        {
            if (ReferenceEquals(x, y)) return 0;
            if (ReferenceEquals(null, y)) return 1;
            if (ReferenceEquals(null, x)) return -1;
            return x.Priority.CompareTo(y.Priority);
        }
    }
}