using Diamond_Kata;
using Xunit;

namespace DiamondKataTests
{
    public class DiamondTests
    {
        [Fact]
        public void GivenAnInvalidCharacterDiamondFailsToConstructWithExceptionThrown()
        {
            Action constructInvalidDiamond = () => new Diamond('*');
            constructInvalidDiamond.Should().Throw<ArgumentException>();
        }

        [Fact]
        public void GivenAValidCharacterDiamondConstructsWithoutExceptionThrown()
        {
            Action constructInvalidDiamond = () => new Diamond('Z');
            constructInvalidDiamond.Should().NotThrow<ArgumentException>();
        }

        [Fact]
        public void GivenLetterATheDiamondConstructsCorrectly()
        {
            var diamond = new Diamond('a');
            diamond.Lines.Should().NotBeEmpty();
            diamond.Lines.Should().HaveCount(1);
            diamond.Lines.Should().BeEquivalentTo(new List<string> { "A" });
        }


        [Theory]
        [InlineData('B')]
        [InlineData('b')]
        public void GivenValidLetterDiamondConstructCorrectlyIngnoringCasing(char letter)
        {
            Diamond diamond = new Diamond(letter);
            diamond.Lines.Should().HaveCount(3);
            diamond.Lines.Should().BeEquivalentTo(new List<string> { " A ", "B B", " A " });
        }
    }
}