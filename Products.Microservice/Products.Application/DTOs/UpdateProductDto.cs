using Products.Domain.Enums;

namespace Products.Application.DTOs
{
    public record UpdateProductDto(
        string Name,
        decimal Price,
        CategoryEnum Category,
        string? Description,
        bool Active,
        string? ImageUrl
    );
}