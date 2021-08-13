using System.Collections.Generic;
using System.Linq;
using Data.Structure.Dynamic.Tabulation;
using Xunit;

namespace Data.Structure.Tests.Dynamic.TabulationTests
{
    public class TabulationTests
    {
        [Fact]
        public void FibOfNum()
        {
            Assert.Equal(8, Fib.G(6));
            Assert.Equal(21, Fib.G(8));
            Assert.Equal(12586269025, Fib.G(50));
        }

        [Fact]
        public void GridTravelerOfNum()
        {
            Assert.Equal(1, GridTraveler.G(1, 1));
            Assert.Equal(3, GridTraveler.G(2, 3));
            Assert.Equal(3, GridTraveler.G(3, 2));
            Assert.Equal(6, GridTraveler.G(3, 3));
            Assert.Equal(2333606220, GridTraveler.G(18, 18));
        }

        [Fact]
        public void CanSumNumFromArr()
        {
            Assert.Equal(true, CanSum.G(new[] { 2, 3 }, 7));
            Assert.Equal(true, CanSum.G(new[] { 5, 3, 4, 7 }, 7));
            Assert.Equal(false, CanSum.G(new[] { 2, 4 }, 7));
            Assert.Equal(true, CanSum.G(new[] { 2, 3, 5 }, 8));
            Assert.Equal(false, CanSum.G(new[] { 7, 14 }, 300));
        }

        [Fact]
        public void HowSumNumFromArr()
        {
            var l1 = HowSum.G(new[] { 2, 3 }, 7);

            Assert.True(l1?.Contains(2) == true && l1?.Contains(3) == true);

            var l2 = HowSum.G(new[] { 5, 3, 4, 7 }, 7);
            Assert.True(l2?.Contains(4));
            Assert.True(l2?.Contains(3));

            var l3 = HowSum.G(new[] { 2, 3, 5 }, 8);
            Assert.True(l3?.All(x => x == 2) == true && l3?.Count == 4);

            Assert.Equal(null, HowSum.G(new[] { 7, 14 }, 300));
        }

        [Fact]
        public void BestSumNumFromArr()
        {
            Assert.True(BestSum.G(new[] { 5, 3, 4, 7 }, 7)?.Contains(7));

            Assert.True(BestSum.G(new[] { 2, 3, 5 }, 8)?.Contains(3) == true);
            Assert.True(BestSum.G(new[] { 2, 3, 5 }, 8)?.Contains(5) == true);
            Assert.True(BestSum.G(new[] { 2, 3, 5 }, 8)?.Count == 2);

            var ints = BestSum.G(new[] { 1, 4, 5 }, 8);
            Assert.True(ints?.All(x => x == 4));

            var list = BestSum.G(new[] { 1, 2, 5, 25 }, 100);
            Assert.True(list?.All(x => x == 25));
        }

        [Fact]
        public void CanConstructFromWords()
        {
            Assert.True(CanConstruct.G("abcdef", new List<string> { "ab", "abc", "cd", "def", "abcd" }));
            Assert.False(CanConstruct.G("skateboard", new List<string> { "bo", "rd", "ate", "t", "ska", "sk", "boar" }));
            Assert.True(CanConstruct.G("enterapotentpot", new List<string> { "a", "p", "ent", "enter", "ot", "o", "t" }));
            Assert.False(CanConstruct.G("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new List<string> { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" }));
        }


        [Fact]
        public void CountConstructFromWords()
        {
            Assert.Equal(2, CountConstruct.G("purple", new List<string> { "purp", "p", "ur", "le", "purpl" }));
            Assert.Equal(1, CountConstruct.G("abcdef", new List<string> { "ab", "abc", "cd", "def", "abcd" }));
            Assert.Equal(0, CountConstruct.G("skateboard", new List<string> { "bo", "rd", "ate", "t", "ska", "sk", "boar" }));
            Assert.Equal(4, CountConstruct.G("enterapotentpot", new List<string> { "a", "p", "ent", "enter", "ot", "o", "t" }));
            Assert.Equal(0, CountConstruct.G("eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef", new List<string> { "e", "ee", "eee", "eeee", "eeeee", "eeeeee" }));
        }


        [Fact]
        public void AllConstructNumFromArr()
        {
            var list1 = AllConstruct.G("purple", new List<string> { "purp", "p", "ur", "le", "purpl" });
            Assert.True(list1?.Any(l => l.Contains("purp") && l.Contains("le")));
            Assert.True(list1?.Any(l => l.Contains("p") && l.Contains("ur") && l.Contains("p") && l.Contains("le")));
            Assert.True(list1?.Count == 2);

            var list2 = AllConstruct.G("abcdef", new List<string> { "ab", "abc", "cd", "def", "abcd", "ef", "c" });
            Assert.True(list2?.Any(l => l.Contains("ab") && l.Contains("cd") && l.Contains("ef")));
            Assert.True(list2?.Any(l => l.Contains("ab") && l.Contains("c") && l.Contains("def")));
            Assert.True(list2?.Any(l => l.Contains("abc") && l.Contains("def")));
            Assert.True(list2?.Any(l => l.Contains("abcd") && l.Contains("ef")));
            Assert.True(list2?.Count == 4);
            
            var list3 = AllConstruct.G("skateboard", new List<string> { "bo", "rd", "ate", "t", "ska", "sk", "boar" });
            Assert.True(list3.Count == 0);

            var list4 = AllConstruct.G("aaaaaaaaaz", new List<string> { "a", "aa", "aaa", "aaaa", "aaaaa" });
            Assert.True(list4.Count == 0);
        }
    }
}