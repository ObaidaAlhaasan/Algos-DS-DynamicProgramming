using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;

namespace Data.Structure.Trees
{
    public class Graph
    {
        public Dictionary<string, Node> Nodes { get; set; } = new Dictionary<string, Node>();
        public Dictionary<Node, LinkedList<Node>> Edges { get; set; } = new Dictionary<Node, LinkedList<Node>>();

        public void AddNode(string label)
        {
            var node = new Node(label);
            Nodes.TryAdd(label, node);

            Edges.TryAdd(node, new LinkedList<Node>());
        }

        public void RemoveNode(string label)
        {
            Nodes.TryGetValue(label, out var node);

            foreach (var edge in Edges.Keys)
            {
                Edges.TryGetValue(edge, out var edges);
                edges.Remove(node);
            }

            Edges.Remove(node);
            Nodes.Remove(label);
        }

        public void AddEdge(string from, string to)
        {
            GetFromAndToNodes(from, to, out var fromNode, out var toNode);

            Edges.TryGetValue(fromNode, out var edges);

            if (edges?.Contains(toNode) == false) edges.AddLast(toNode);
        }

        private void GetFromAndToNodes(string from, string to, out Node fromNode, out Node toNode)
        {
            if (!Nodes.TryGetValue(from, out fromNode))
                throw new Exception();

            if (!Nodes.TryGetValue(to, out toNode))
                throw new Exception();
        }

        public void RemoveEdge(string from, string to)
        {
            GetFromAndToNodes(from, to, out var fromNode, out var toNode);

            Edges.TryGetValue(fromNode, out var edges);

            edges?.Remove(toNode);
        }

        public void Print()
        {
            foreach (var edge in Edges)
            {
                var node = edge.Key;

                foreach (var toNode in edge.Value)
                    Console.WriteLine($"Node {node.Label} connected To {toNode.Label}");
            }
        }

        public class Node
        {
            public Node(string label)
            {
                Label = label;
            }

            public string Label { get; set; }


            public override string ToString()
            {
                return Label;
            }
        }

        public void TraverseDepthFirstRecursive(string label)
        {
            var node = Nodes.GetValueOrDefault(label);
            var visited = new HashSet<Node>();
            TraverseDepthFirstRecursive(node, visited);
        }

        private void TraverseDepthFirstRecursive(Node node, ISet<Node> visited)
        {
            if (node == null || visited.Contains(node))
                return;

            visited.Add(node);
            foreach (var ne in (Edges.GetValueOrDefault(node) ?? new LinkedList<Node>()).Where(ne => !visited.Contains(ne)))
                TraverseDepthFirstRecursive(ne, visited);
        }

        public void TraverseDepthFirstIterative(string label)
        {
            var visited = new HashSet<Node>();

            var stack = new Stack<Node>();
            var root = Nodes.GetValueOrDefault(label);
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();

                if (visited.Contains(node))
                    continue;

                Console.WriteLine(node.Label);
                visited.Add(node);

                var nodes = Edges.GetValueOrDefault(node);
                foreach (var nd in nodes)
                {
                    if (!visited.Contains(nd))
                        stack.Push(nd);
                }
            }
        }

        public void TraverseBreadthFirstIterative(string label)
        {
            var visited = new HashSet<Node>();
            var q = new Queue<Node>();
            var root = Nodes.GetValueOrDefault(label);
            q.Enqueue(root);

            while (q.Count > 0)
            {
                var node = q.Dequeue();

                if (visited.Contains(node))
                    continue;

                Console.WriteLine(node.Label);
                visited.Add(node);

                foreach (var neighbor in Edges.GetValueOrDefault(node).Where(neighbor => !visited.Contains(neighbor)))
                    q.Enqueue(neighbor);
            }
        }

        public Node[] TopologicalSort()
        {
            var stack = new Stack<Node>();
            var visited = new HashSet<Node>();
            foreach (var node in Nodes)
            {
                var root = Nodes.GetValueOrDefault(node.Key);
                TopologicalSort(root, visited, stack);
            }

            var sortedList = stack.ToArray();
            return sortedList;
        }

        private void TopologicalSort(Node node, HashSet<Node> visited, Stack<Node> stack)
        {
            if (node == null || visited.Contains(node))
                return;

            visited.Add(node);
            foreach (var neighbor in Edges.GetValueOrDefault(node).Where(n => !visited.Contains(n)))
                TopologicalSort(neighbor, visited, stack);

            stack.Push(node);
        }

        public bool HasCycle()
        {
            var all = new HashSet<Node>();
            all.UnionWith(Nodes.Values);
            var visited = new HashSet<Node>();
            var visiting = new HashSet<Node>();

            while (all.Count > 0)
            {
                var node = all.FirstOrDefault();
                if (HasCycle(node, all, visited, visiting))
                    return true;
            }

            return false;
        }

        private bool HasCycle(Node node, HashSet<Node> all, HashSet<Node> visited, HashSet<Node> visiting)
        {
            all.Remove(node);

            visiting.Add(node);

            foreach (var neighbor in Edges.GetValueOrDefault(node))
            {
                if (visited.Contains(neighbor))
                    continue;

                if (visiting.Contains(neighbor))
                    return true;

                if (HasCycle(neighbor, all, visited, visiting))
                    return true;
            }

            visiting.Remove(node);
            visited.Add(node);
            return false;
        }
    }
}