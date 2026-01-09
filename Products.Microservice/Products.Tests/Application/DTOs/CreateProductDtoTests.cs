using FluentAssertions;
using Products.Application.DTOs;
using Products.Domain.Enums;

namespace Products.Tests.Application.DTOs
{
    public class CreateProductDtoTests
    {
        [Fact]
        public void CreateProductDto_WithValidData_ShouldCreateSuccessfully()
        {
            var name = "Novo Produto";
            var price = 149.99m;
            var category = CategoryEnum.SANDWICH;
            var description = "Descrição completa do produto";
            var imageUrl = "https://example.com/product.jpg";

            var dto = new CreateProductDto(
                name, price, category, description, imageUrl
            );

            dto.Should().NotBeNull();
            dto.Name.Should().Be(name);
            dto.Price.Should().Be(price);
            dto.Category.Should().Be(category);
            dto.Description.Should().Be(description);
            dto.ImageUrl.Should().Be(imageUrl);
        }

        [Fact]
        public void CreateProductDto_WithNullableFields_ShouldCreateSuccessfully()
        {
            var dto = new CreateProductDto(
                "Produto Simples", 99.99m, CategoryEnum.DRINK, null, null
            );

            dto.Description.Should().BeNull();
            dto.ImageUrl.Should().BeNull();
        }

        [Fact]
        public void CreateProductDto_WithOnlyDescription_ShouldCreateSuccessfully()
        {
            var dto = new CreateProductDto(
                "Produto", 50.00m, CategoryEnum.DESSERT, "Descrição disponível", null
            );

            dto.Description.Should().Be("Descrição disponível");
            dto.ImageUrl.Should().BeNull();
        }

        [Fact]
        public void CreateProductDto_WithOnlyImageUrl_ShouldCreateSuccessfully()
        {
            var dto = new CreateProductDto(
                "Produto", 75.00m, CategoryEnum.SANDWICH, null, "https://example.com/img.jpg"
            );

            dto.Description.Should().BeNull();
            dto.ImageUrl.Should().Be("https://example.com/img.jpg");
        }

        [Fact]
        public void CreateProductDto_WithDifferentCategories_ShouldStoreCorrectly()
        {
            var dtoBooks = new CreateProductDto(
                "Livro", 30.00m, CategoryEnum.DRINK, "Um livro", null
            );

            var dtoClothing = new CreateProductDto(
                "Camisa", 45.00m, CategoryEnum.DESSERT, "Uma camisa", null
            );

            var dtoElectronics = new CreateProductDto(
                "Notebook", 2500.00m, CategoryEnum.SANDWICH, "Computador portátil", null
            );

            dtoBooks.Category.Should().Be(CategoryEnum.DRINK);
            dtoClothing.Category.Should().Be(CategoryEnum.DESSERT);
            dtoElectronics.Category.Should().Be(CategoryEnum.SANDWICH);
        }

        [Fact]
        public void CreateProductDto_WithZeroPrice_ShouldCreateSuccessfully()
        {
            var dto = new CreateProductDto(
                "Produto Grátis", 0m, CategoryEnum.SANDWICH, "Amostra grátis", null
            );

            dto.Price.Should().Be(0m);
        }

        [Fact]
        public void CreateProductDto_WithHighPrice_ShouldCreateSuccessfully()
        {
            var dto = new CreateProductDto(
                "Produto Premium", 99999.99m, CategoryEnum.SANDWICH, "Produto de luxo", null
            );

            dto.Price.Should().Be(99999.99m);
        }

        [Fact]
        public void CreateProductDto_WithDecimalPrice_ShouldMaintainPrecision()
        {
            var price = 12.345m;

            var dto = new CreateProductDto(
                "Produto", price, CategoryEnum.SANDWICH, null, null
            );

            dto.Price.Should().Be(price);
        }

        [Fact]
        public void CreateProductDto_EqualityComparison_ShouldWorkCorrectly()
        {
            var dto1 = new CreateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, "Descrição", "https://example.com/img.jpg"
            );

            var dto2 = new CreateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, "Descrição", "https://example.com/img.jpg"
            );

            dto1.Should().Be(dto2);
        }

        [Fact]
        public void CreateProductDto_DifferentNames_ShouldNotBeEqual()
        {
            var dto1 = new CreateProductDto(
                "Produto A", 50.00m, CategoryEnum.SANDWICH, null, null
            );

            var dto2 = new CreateProductDto(
                "Produto B", 50.00m, CategoryEnum.SANDWICH, null, null
            );

            dto1.Should().NotBe(dto2);
        }

        [Fact]
        public void CreateProductDto_DifferentPrices_ShouldNotBeEqual()
        {
            var dto1 = new CreateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, null, null
            );

            var dto2 = new CreateProductDto(
                "Produto", 60.00m, CategoryEnum.SANDWICH, null, null
            );

            dto1.Should().NotBe(dto2);
        }

        [Fact]
        public void CreateProductDto_DifferentCategories_ShouldNotBeEqual()
        {
            var dto1 = new CreateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, null, null
            );

            var dto2 = new CreateProductDto(
                "Produto", 50.00m, CategoryEnum.DRINK, null, null
            );

            dto1.Should().NotBe(dto2);
        }

        [Fact]
        public void CreateProductDto_WithLongDescription_ShouldCreateSuccessfully()
        {
            var longDescription = new string('A', 2000);

            var dto = new CreateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, longDescription, null
            );

            dto.Description.Should().Be(longDescription);
            dto.Description.Should().HaveLength(2000);
        }

        [Fact]
        public void CreateProductDto_WithSpecialCharactersInName_ShouldCreateSuccessfully()
        {
            var name = "Produto @ #1 & Especial!";

            var dto = new CreateProductDto(
                name, 50.00m, CategoryEnum.DRINK, null, null
            );

            dto.Name.Should().Be(name);
        }

        [Fact]
        public void CreateProductDto_WithEmptyStringDescription_ShouldCreateSuccessfully()
        {
            var dto = new CreateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, string.Empty, null
            );

            dto.Description.Should().Be(string.Empty);
            dto.Description.Should().NotBeNull();
        }

        [Fact]
        public void CreateProductDto_WithComplexImageUrl_ShouldCreateSuccessfully()
        {
            var imageUrl = "https://cdn.example.com/images/products/2024/01/product_image_12345.jpg?quality=high&size=large";

            var dto = new CreateProductDto(
                "Produto", 50.00m, CategoryEnum.SANDWICH, null, imageUrl
            );

            dto.ImageUrl.Should().Be(imageUrl);
        }

        [Fact]
        public void CreateProductDto_WithMinimumRequiredFields_ShouldCreateSuccessfully()
        {
            var dto = new CreateProductDto(
                "P", 0.01m, CategoryEnum.DRINK, null, null
            );

            dto.Name.Should().Be("P");
            dto.Price.Should().Be(0.01m);
            dto.Category.Should().Be(CategoryEnum.DRINK);
            dto.Description.Should().BeNull();
            dto.ImageUrl.Should().BeNull();
        }

        [Fact]
        public void CreateProductDto_WithNegativePrice_ShouldCreateSuccessfully()
        {
            var dto = new CreateProductDto(
                "Produto com Desconto", -10.00m, CategoryEnum.SANDWICH, "Crédito", null
            );

            dto.Price.Should().Be(-10.00m);
        }
    }
}