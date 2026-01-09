using FluentAssertions;
using Products.Application.DTOs;
using Products.Domain.Enums;

namespace Products.Tests.Application.DTOs
{
    public class ProductDtoTests
    {
        [Fact]
        public void ProductDto_WithValidData_ShouldCreateSuccessfully()
        {
            var id = 1;
            var name = "Produto Teste";
            var price = 99.99m;
            var category = CategoryEnum.SANDWICH;
            var description = "Descrição do produto";
            var active = true;
            var imageUrl = "https://example.com/image.jpg";
            var createdAt = DateTime.UtcNow;
            var updatedAt = DateTime.UtcNow;

            var dto = new ProductDto(
                id, name, price, category, description,
                active, imageUrl, createdAt, updatedAt
            );

            dto.Should().NotBeNull();
            dto.Id.Should().Be(id);
            dto.Name.Should().Be(name);
            dto.Price.Should().Be(price);
            dto.Category.Should().Be(category);
            dto.Description.Should().Be(description);
            dto.Active.Should().Be(active);
            dto.ImageUrl.Should().Be(imageUrl);
            dto.CreatedAt.Should().Be(createdAt);
            dto.UpdatedAt.Should().Be(updatedAt);
        }

        [Fact]
        public void ProductDto_WithNullableFields_ShouldCreateSuccessfully()
        {
            var createdAt = DateTime.UtcNow;
            var updatedAt = DateTime.UtcNow;

            var dto = new ProductDto(
                1, "Produto", 50.00m, CategoryEnum.DRINK, null,
                true, null, createdAt, updatedAt
            );

            dto.Description.Should().BeNull();
            dto.ImageUrl.Should().BeNull();
        }

        [Fact]
        public void ProductDto_WithInactiveProduct_ShouldStoreCorrectly()
        {
            var createdAt = DateTime.UtcNow;
            var updatedAt = DateTime.UtcNow;

            var dto = new ProductDto(
                1, "Produto Inativo", 25.00m, CategoryEnum.DRINK,
                "Produto descontinuado", false, null, createdAt, updatedAt
            );

            dto.Active.Should().BeFalse();
        }

        [Fact]
        public void ProductDto_WithDifferentCategories_ShouldStoreCorrectly()
        {
            var createdAt = DateTime.UtcNow;
            var updatedAt = DateTime.UtcNow;

            var dto = new ProductDto(
                1, "Livro", 30.00m, CategoryEnum.DRINK, "Um livro interessante",
                true, "https://example.com/book.jpg", createdAt, updatedAt
            );

            dto.Category.Should().Be(CategoryEnum.DRINK);
        }

        [Fact]
        public void ProductDto_WithZeroPrice_ShouldCreateSuccessfully()
        {
            var createdAt = DateTime.UtcNow;
            var updatedAt = DateTime.UtcNow;

            var dto = new ProductDto(
                1, "Produto Grátis", 0m, CategoryEnum.SANDWICH, "Amostra grátis",
                true, null, createdAt, updatedAt
            );

            dto.Price.Should().Be(0m);
        }

        [Fact]
        public void ProductDto_WithHighPrice_ShouldCreateSuccessfully()
        {
            var createdAt = DateTime.UtcNow;
            var updatedAt = DateTime.UtcNow;

            var dto = new ProductDto(
                1, "Produto Premium", 9999.99m, CategoryEnum.SANDWICH, "Produto caro",
                true, null, createdAt, updatedAt
            );

            dto.Price.Should().Be(9999.99m);
        }

        [Fact]
        public void ProductDto_EqualityComparison_ShouldWorkCorrectly()
        {
            var createdAt = new DateTime(2024, 1, 1);
            var updatedAt = new DateTime(2024, 1, 2);

            var dto1 = new ProductDto(
                1, "Produto", 50.00m, CategoryEnum.SANDWICH, "Descrição",
                true, "https://example.com/image.jpg", createdAt, updatedAt
            );

            var dto2 = new ProductDto(
                1, "Produto", 50.00m, CategoryEnum.SANDWICH, "Descrição",
                true, "https://example.com/image.jpg", createdAt, updatedAt
            );

            dto1.Should().Be(dto2);
        }

        [Fact]
        public void ProductDto_DifferentIds_ShouldNotBeEqual()
        {
            var createdAt = new DateTime(2024, 1, 1);
            var updatedAt = new DateTime(2024, 1, 2);

            var dto1 = new ProductDto(
                1, "Produto", 50.00m, CategoryEnum.SANDWICH, "Descrição",
                true, "https://example.com/image.jpg", createdAt, updatedAt
            );

            var dto2 = new ProductDto(
                2, "Produto", 50.00m, CategoryEnum.SANDWICH, "Descrição",
                true, "https://example.com/image.jpg", createdAt, updatedAt
            );

            dto1.Should().NotBe(dto2);
        }

        [Fact]
        public void ProductDto_WithLongDescription_ShouldCreateSuccessfully()
        {
            var longDescription = new string('A', 1000);
            var createdAt = DateTime.UtcNow;
            var updatedAt = DateTime.UtcNow;

            var dto = new ProductDto(
                1, "Produto", 50.00m, CategoryEnum.SANDWICH, longDescription,
                true, null, createdAt, updatedAt
            );

            dto.Description.Should().Be(longDescription);
            dto.Description.Should().HaveLength(1000);
        }

        [Fact]
        public void ProductDto_WithSpecialCharactersInName_ShouldCreateSuccessfully()
        {
            var name = "Produto @ Especial & Único!";
            var createdAt = DateTime.UtcNow;
            var updatedAt = DateTime.UtcNow;

            var dto = new ProductDto(
                1, name, 50.00m, CategoryEnum.SANDWICH, null,
                true, null, createdAt, updatedAt
            );

            dto.Name.Should().Be(name);
        }
    }
}