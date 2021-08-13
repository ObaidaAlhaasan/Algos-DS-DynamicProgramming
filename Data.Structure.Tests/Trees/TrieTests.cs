using System;
using System.Linq;
using Data.Structure.Trees;
using Xunit;

namespace Data.Structure.Tests
{
    public class TrieTests
    {
        [Fact]
        public void Trie_HaveEmptyRootNode()
        {
            var trie = new Trie();

            trie.Insert("cat");
            trie.Insert("can");
            trie.Insert("car");

            trie.Insert("body");
            trie.Insert("boy");

            Assert.Equal(trie.Root.Value, default);
        }

        [Fact]
        public void Contain_Returns_CorrectResult()
        {
            var trie = new Trie();
            trie.Insert("cat");
            trie.Insert("can");
            trie.Insert("car");

            trie.Insert("body");
            trie.Insert("boy");


            Assert.True(trie.Contains("cat"));
            Assert.True(trie.Contains("can"));
            Assert.True(trie.Contains("car"));

            Assert.False(trie.Contains("baby"));

            Assert.False(trie.Contains("boyka"));
            Assert.False(trie.Contains(null));
        }

        [Fact]
        public void TraversePreOrder()
        {
            var trie = new Trie();
            trie.Insert("cat");
            trie.Insert("can");
            trie.Insert("car");

            trie.TraversePreOrder();
            trie.TraversePostOrder();
        }

        [Fact]
        public void RemoveWordsFromTrieCorrectly_WithoutAffectingOtherWords()
        {
            var trie = new Trie();
            trie.Insert("cat");
            trie.Insert("can");
            trie.Insert("car");
            trie.Insert("care");
            trie.Insert("bob");

            trie.Remove("bob");
            trie.Remove("car");

            Assert.True(trie.Contains("care"));
            Assert.False(trie.Contains("bob"));
            Assert.False(trie.Contains("car"));
        }


        [Fact]
        public void AutoComplete_WorkCorrectly()
        {
            var trie = new Trie();

            trie.Insert("cat");
            trie.Insert("can");
            trie.Insert("car");
            trie.Insert("care");
            trie.Insert("bob");

            var autoComplete = trie.AutoComplete("ca");

            Assert.True(autoComplete.Contains("cat"));
            Assert.True(autoComplete.Contains("car"));
            Assert.True(autoComplete.Contains("care"));
            Assert.False(autoComplete.Contains("bob"));
        }


        [Fact]
        public void containsRecursive_ReturnsCorrectResult()
        {
            var trie = new Trie();
            trie.Insert("cat");
            trie.Insert("can");
            trie.Insert("car");
            trie.Insert("care");
            trie.Insert("bob");

            trie.Remove("car");

            Assert.True(trie.ContainsRecursive("care"));
            Assert.True(trie.ContainsRecursive("bob"));
        }


        [Fact]
        public void CountWords_ReturnCorrectly()
        {
            var trie = new Trie();
            trie.Insert("cat");
            trie.Insert("can");
            trie.Insert("car");
            trie.Insert("care");
            trie.Insert("bob");
            trie.Remove("car");


            Assert.Equal(4, trie.CountWords());
            trie.Remove("bob");
            Assert.Equal(3, trie.CountWords());
        }

        [Fact]
        public void LongestCommonPrefix()
        {
            var trie = new Trie();

            Assert.Equal("car", trie.LongestCommonPrefix(new[] {"card", "care"}));
            Assert.Equal("", trie.LongestCommonPrefix(new[] {"car", "dog"}));
        }
    }
}