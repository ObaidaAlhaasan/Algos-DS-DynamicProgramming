using System.Threading.Tasks;
using Data.Structure.Algos;
using Xunit;

namespace Data.Structure.Tests.Algos
{
    public class NameInverterTests
    {
        private readonly NameInverter _nameInverter;

        public NameInverterTests()
        {
            _nameInverter = new NameInverter();
        }

        [Fact]
        public async Task Inverter_GivenNull_ReturnEmptyStr()
        {
            AssertInverted(string.Empty, null);
        }


        [Fact]
        public async Task GivenEmpty_ShouldReturnEmpty()
        {
            AssertInverted(string.Empty, string.Empty);
        }

        [Fact]
        public async Task GiveSimpleName_ShouldReturnSimpleName()
        {
            AssertInverted("Bob", "Bob");
            AssertInverted("Name", "Name");
        }

        [Fact]
        public async Task GivenFirstLast_ShouldReturnLastFirstSeparatedByComma()
        {
            AssertInverted("Last, First", "First Last");
        }

        [Fact]
        public async Task GivenSimpleNameWithSpaces_ShouldReturnSimpleNameWithoutSpaces()
        {
            AssertInverted("Name", "  Name      ");
        }

        [Fact]
        public async Task GivenFirstLastWithExtraSpaces_ReturnLastFirst()
        {
            AssertInverted("Last, First", " First        Last      ");
        }

        [Fact]
        public async Task Ignore_Honorific()
        {
            AssertInverted("Last, First", "Mr. First Last");
            AssertInverted("Last, First", "Mrs. First Last");
        }

        [Fact]
        public async Task PostNominal_StayAtEnd()
        {
            AssertInverted("Last, First Sr.", "First Last Sr.");
            AssertInverted("Last, First Bs. Phd", "First Last Bs. Phd");
        }

        [Fact]
        public async Task Integrations()
        {
            AssertInverted("Ford, Robert III Dr.", "Robert Ford III Dr.");
        }

        private void AssertInverted(string expected, string? original)
        {
            var inverted = _nameInverter.Invert(original);
            Assert.Equal(expected, inverted);
        }
    }
}