using FluentAssertions;
using Xunit;

namespace Wardrobe.Tests
{
    public class ConfigurationsShould
    {
        [Fact]
        public void HaveFourItems()
        {
            var items = Configurations.PossibleModels;

            items.Should().HaveCount(4);
        }

        [Fact]
        public void NotBeNullGetSmallerSize()
        {
            var item = Configurations.GetSmallerSize();

            item.Should().NotBeNull();
        }

        [Fact]
        public void GetSmallerSizeShouldBeFifty()
        {
            var item = Configurations.GetSmallerSize();

            item.Item1.Should().Be(AvailableSize.Fifty);
        }

    }
}