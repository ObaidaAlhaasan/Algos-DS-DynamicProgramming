using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Structure.Algos;
using Xunit;

namespace Data.Structure.Tests.Algos
{
    public class WordWrapperTests
    {
        [Fact]
        public async Task ShouldWrap()
        {
            AssertWraps("", 1, "");
            AssertWraps(null, 1, "");
            AssertWraps("x", 1, "x");
            AssertWraps("xx", 1, "x\nx");
            AssertWraps("xxx", 1, "x\nx\nx");
            AssertWraps("x x", 1, "x\nx");
            AssertWraps("x xx", 3, "x\nxx");
            AssertWraps("x xx", 3, "x\nxx");
            AssertWraps("four score and seven years ago our fathers brought forth upon this continent", 7, "four\nscore\nand\nseven\nyears\nago our\nfathers\nbrought\nforth\nupon\nthis\ncontine\nnt");
        }

        private static void AssertWraps(string? str, int width, string? expected)
        {
            Assert.Equal(expected, WordWrapper.Wrap(str, width));
        }
    }
}