using FluentAssertions;
using Products.Domain.Entities;
using Products.Domain.Enums;
using Xunit;

namespace Products.Tests.Domain;

public class ProductTests
{
    [Fact]
    public void Activate_ShouldSetActiveToTrue()
    {
        var product = new Product { Active = false };

        product.Activate();

        product.Active.Should().BeTrue();
    }

    [Fact]
    public void Deactivate_ShouldSetActiveToFalse()
    {
        var product = new Product { Active = true };

        product.Deactivate();

        product.Active.Should().BeFalse();
    }

    [Fact]
    public void UpdatePrice_WithValidPrice_ShouldUpdatePriceAndTimestamp()
    {
        var product = new Product
        {
            Price = 10.00m,
            UpdatedAt = DateTime.UtcNow.AddDays(-1)
        };
        var oldUpdateTime = product.UpdatedAt;

        product.UpdatePrice(25.90m);

        product.Price.Should().Be(25.90m);
        product.UpdatedAt.Should().BeAfter(oldUpdateTime);
    }

    [Fact]
    public void UpdatePrice_WithNegativePrice_ShouldThrowArgumentException()
    {
        var product = new Product { Price = 10.00m };

        Action act = () => product.UpdatePrice(-5.00m);

        act.Should().Throw<ArgumentException>()
            .WithMessage("O preço não pode ser negativo");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("   ")]
    public void UpdateInfo_WithInvalidName_ShouldThrowArgumentException(string invalidName)
    {
        var product = new Product { Name = "Original Name" };

        Action act = () => product.UpdateInfo(invalidName, "Description", "url");

        act.Should().Throw<ArgumentException>()
            .WithMessage("O nome do produto é obrigatório");
    }

    [Fact]
    public void UpdateInfo_WithValidData_ShouldUpdateProductInfo()
    {
        var product = new Product
        {
            Name = "Old Name",
            Description = "Old Description",
            ImageUrl = "old-url"
        };

        product.UpdateInfo("New Name", "New Description", "new-url");

        product.Name.Should().Be("New Name");
        product.Description.Should().Be("New Description");
        product.ImageUrl.Should().Be("new-url");
    }
}