using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;

namespace Data.Structure.Trees
{
    public class Trie
    {
        public Node Root { get; private set; }

        public Trie()
        {
            Root = new Node(char.MinValue);
        }

        public void Insert(string word)
        {
            var current = Root;

            foreach (var ch in word)
            {
                current.TryAdd(ch);

                current = current.GetNode(ch);
            }

            current.IsEndOfWord = true;
        }

        public bool Contains(string word)
        {
            if (string.IsNullOrWhiteSpace(word))
                return false;

            var current = Root;
            foreach (var ch in word)
            {
                if (!current.HasChild(ch))
                {
                    return false;
                }

                current = current.GetNode(ch);
            }

            return current.IsEndOfWord;
        }


        public void TraversePreOrder()
        {
            TraversePreOrder(Root);
        }

        private void TraversePreOrder(Node root)
        {
            if (root == null)
            {
                return;
            }

            // pre-order visit the root first
            Console.WriteLine(root.Value);
            foreach (var child in root.Children)
                TraversePreOrder(child.Value);
        }

        public void TraversePostOrder()
        {
            TraversePostOrder(Root);
        }

        private void TraversePostOrder(Node root)
        {
            if (root == null)
                return;

            // post-order visit the leaf's first
            foreach (var child in root.Children)
                TraversePostOrder(child.Value);

            Console.WriteLine(root.Value);
        }

        public class Node
        {
            public char Value { get; set; }
            public bool IsEndOfWord { get; set; }
            public Dictionary<char, Node> Children { get; set; }

            public Node(char val)
            {
                Value = val;
                Children = new Dictionary<char, Node>();
            }

            public override string ToString() => $"Value :{Value} - Is End {IsEndOfWord}";

            public bool TryAdd(char ch)
            {
                return Children.TryAdd(ch, new Node(ch));
            }

            public Node GetNode(char ch)
            {
                Children.TryGetValue(ch, out var c);
                return c;
            }

            public bool HasChild(char ch) =>
                Children.ContainsKey(ch);

            public bool HasChildren()
            {
                return Children.Count > 0;
            }

            public void RemoveChild(char ch)
            {
                Children.Remove(ch);
            }
        }

        public void Remove(string word)
        {
            Remove(Root, word, 0);
        }

        private void Remove(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                Console.WriteLine(root.Value);
                root.IsEndOfWord = false;
                return;
            }

            var ch = word[index];
            var child = root.GetNode(ch);
            if (child == null)
            {
                return;
            }

            Remove(child, word, index + 1);

            if (!child.IsEndOfWord && !child.HasChildren())
            {
                root.RemoveChild(ch);
            }
        }

        public IList<string> AutoComplete(string word)
        {
            var list = new List<string>();
            var node = FindLastWord(word);

            AutoComplete(node, word, list);

            return list;
        }

        private Node FindLastWord(string word)
        {
            var current = Root;

            foreach (var ch in word)
            {
                var child = current.GetNode(ch);
                if (child == null)
                    return null;

                current = child;
            }

            return current;
        }

        private void AutoComplete(Node root, string word, List<string> list)
        {
            if (root == null)
                return;


            if (root.IsEndOfWord) list.Add(word);

            foreach (var child in root.Children)
            {
                AutoComplete(child.Value, word + child.Key, list);
            }
        }

        public bool ContainsRecursive(string word)
        {
            if (word == null)
            {
                return false;
            }

            return ContainsRecursive(Root, word, 0);
        }

        private bool ContainsRecursive(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                return root.IsEndOfWord;
            }

            if (root == null)
                return false;

            var ch = word[index];
            var child = root.GetNode(ch);
            if (child == null)
                return false;

            return ContainsRecursive(child, word, index + 1);
        }

        public int CountWords()
        {
            var counts = 0;
            CountWords(Root, ref counts);

            return counts;
        }

        private void CountWords(Node root, ref int counts)
        {
            if (root == null)
                return;

            if (root.IsEndOfWord)
                counts++;

            foreach (var child in root.Children)
            {
                CountWords(child.Value, ref counts);
            }
        }

        public string LongestCommonPrefix(string[] words)
        {
            var trie = new Trie();

            foreach (var word in words)
            {
                trie.Insert(word);
            }

            var prefix = "";
            var maxChars = GetShortest(words).Length;

            var current = trie.Root;

            while (prefix.Length < maxChars)
            {
                var children = current.Children;
                if (children.Count != 1)
                {
                    break;
                }

                current = children.ToArray()[0].Value
                    ;
                prefix += current.Value;
            }

            return prefix;
        }

        private string GetShortest(string[] words)
        {
            var shortest = words[0];

            foreach (var word in words)
            {
                if (word.Length < shortest.Length)
                {
                    shortest = word;
                }
            }

            return shortest;
        }
    }
}