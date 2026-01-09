using FluentAssertions;
using Products.Application.DTOs;
using Products.Domain.Enums;

namespace Products.Tests.Application.DTOs
{
    public class UpdateProductDtoTests
    {
        [Fact]
        public void UpdateProductDto_WithValidData_ShouldCreateSuccessfully()
        {
            var name = "Produto Atualizado";
            var price = 199.99m;
            var category = CategoryEnum.SANDWICH;
            var description = "Nova descrição do produto";
            var active = true;
            var imageUrl = "https://example.com/new-image.jpg";

            var dto = new UpdateProductDto(
                name, price, category, description, active, imageUrl
            );

            dto.Should().NotBeNull();
            dto.Name.Should().Be(name);
            dto.Price.Should().Be(price);
            dto.Category.Should().Be(category);
            dto.Description.Should().Be(description);
            dto.Active.Should().Be(active);
            dto.ImageUrl.Should().Be(imageUrl);
        }

        [Fact]
        public void UpdateProductDto_WithNullableFields_ShouldCreateSuccessfully()
        {
            var dto = new UpdateProductDto(
                "Produto", 50.00m, CategoryEnum.DRINK, null, true, null
            );

            dto.Description.Should().BeNull();
            dto.ImageUrl.Should().BeNull();
        }

        [Fact]
        public void UpdateProductDto_WithInactiveStatus_ShouldCreateSuccessfully()
        {
            var dto = new UpdateProductDto(
                "Produto Descontinuado", 25.00m, CategoryEnum.SANDWICH,
                "Produto não disponível", false, null
            );

            dto.Active.Should().BeFalse();
        }

        [Fact]
        public void UpdateProductDto_WithActiveStatus_ShouldCreateSuccessfully()
        {
            var dto = new UpdateProductDto(
                "Produto Ativo", 75.00m, CategoryEnum.SANDWICH,
                "Produto disponível", true, "https://example.com/active.jpg"
            );

            dto.Active.Should().BeTrue();
        }

        [Fact]
        public void UpdateProductDto_WithDifferentCategories_ShouldStoreCorrectly()
        {
            var dtoBooks = new UpdateProductDto(
                "Livro Atualizado", 35.00m, CategoryEnum.DRINK, "Livro revisado", true, null
            );

            var dtoClothing = new UpdateProductDto(
                "Roupa Atualizada", 55.00m, CategoryEnum.DESSERT, "Nova coleção", true, null
            );

            dtoBooks.Category.Should().Be(CategoryEnum.DRINK);
            dtoClothing.Category.Should().Be(CategoryEnum.DESSERT);
        }

        [Fact]
        public void UpdateProductDto_WithZeroPrice_ShouldCreateSuccessfully()
        {
            var dto = new UpdateProductDto(
                "Produto Promocional", 0m, CategoryEnum.SANDWICH, "Promoção especial", true, null
            );

            dto.Price.Should().Be(0m);
        }

        [Fact]
        public void UpdateProductDto_WithHighPrice_ShouldCreateSuccessfully()
        {
            var dto = new UpdateProductDto(
                "Produto Premium Plus", 99999.99m, CategoryEnum.SANDWICH,
                "Edição limitada", true, null
            );

            dto.Price.Should().Be(99999.99m);
        }

        [Fact]
        public void UpdateProductDto_WithDecimalPrice_ShouldMaintainPrecision()
        {
            var price = 123.456m;
            var dto = new UpdateProductDto(
                "Produto", price, CategoryEnum.SANDWICH, null, true, null
            );

            dto.Price.Should().Be(price);
        }

        [Fact]
        public void UpdateProductDto_EqualityComparison_ShouldWorkCorrectly()
        {
            var dto1 = new UpdateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, "Descrição", true, "https://example.com/img.jpg"
            );

            var dto2 = new UpdateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, "Descrição", true, "https://example.com/img.jpg"
            );

            dto1.Should().Be(dto2);
        }

        [Fact]
        public void UpdateProductDto_DifferentActiveStatus_ShouldNotBeEqual()
        {
            var dto1 = new UpdateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, "Descrição", true, null
            );

            var dto2 = new UpdateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, "Descrição", false, null
            );

            dto1.Should().NotBe(dto2);
        }

        [Fact]
        public void UpdateProductDto_DifferentNames_ShouldNotBeEqual()
        {
            var dto1 = new UpdateProductDto(
                "Produto A", 50.00m, CategoryEnum.SANDWICH, null, true, null
            );

            var dto2 = new UpdateProductDto(
                "Produto B", 50.00m, CategoryEnum.SANDWICH, null, true, null
            );

            dto1.Should().NotBe(dto2);
        }

        [Fact]
        public void UpdateProductDto_DifferentPrices_ShouldNotBeEqual()
        {
            var dto1 = new UpdateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, null, true, null
            );

            var dto2 = new UpdateProductDto(
                "Produto", 75.00m, CategoryEnum.SANDWICH, null, true, null
            );

            dto1.Should().NotBe(dto2);
        }

        [Fact]
        public void UpdateProductDto_WithLongDescription_ShouldCreateSuccessfully()
        {
            var longDescription = new string('X', 3000);
            var dto = new UpdateProductDto(
                "Produto", 50.00m, CategoryEnum.DRINK, longDescription, true, null
            );

            dto.Description.Should().Be(longDescription);
            dto.Description.Should().HaveLength(3000);
        }

        [Fact]
        public void UpdateProductDto_WithSpecialCharactersInName_ShouldCreateSuccessfully()
        {
            var name = "Produto Atualizado @ 2024 & Melhorado!";
            var dto = new UpdateProductDto(
                name, 50.00m, CategoryEnum.SANDWICH, null, true, null
            );

            dto.Name.Should().Be(name);
        }

        [Fact]
        public void UpdateProductDto_WithEmptyStringDescription_ShouldCreateSuccessfully()
        {
            var dto = new UpdateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, string.Empty, true, null
            );

            dto.Description.Should().Be(string.Empty);
        }

        [Fact]
        public void UpdateProductDto_WithComplexImageUrl_ShouldCreateSuccessfully()
        {
            var imageUrl = "https://storage.example.com/products/updated/2024/product_v2_12345.jpg?token=abc&format=webp";
            var dto = new UpdateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, null, true, imageUrl
            );

            dto.ImageUrl.Should().Be(imageUrl);
        }

        [Fact]
        public void UpdateProductDto_ChangingFromActiveToInactive_ShouldWork()
        {
            var dtoActive = new UpdateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, "Produto em estoque", true, null
            );

            var dtoInactive = new UpdateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, "Produto fora de linha", false, null
            );

            dtoActive.Active.Should().BeTrue();
            dtoInactive.Active.Should().BeFalse();
        }

        [Fact]
        public void UpdateProductDto_AllFieldsWithMaximumData_ShouldCreateSuccessfully()
        {
            var name = new string('N', 200);
            var description = new string('D', 5000);
            var imageUrl = "https://example.com/" + new string('u', 500) + ".jpg";

            var dto = new UpdateProductDto(
                name, 99999.99m, CategoryEnum.SANDWICH, description, true, imageUrl
            );

            dto.Name.Should().HaveLength(200);
            dto.Description.Should().HaveLength(5000);
            dto.ImageUrl.Should().Contain("example.com");
        }
    }
}