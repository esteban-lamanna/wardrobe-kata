using FluentAssertions;
using Xunit;

namespace Wardrobe.Tests
{
    public class WardrobeShould
    {
        [Fact]
        public void SetElements()
        {
            var wardrobe = new Wardrobe();

            var elements = wardrobe.GetAllPossibleCombination();

            elements.Should().NotBeEmpty();
        }
    }
}