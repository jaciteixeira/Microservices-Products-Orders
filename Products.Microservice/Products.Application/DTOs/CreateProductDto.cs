using Products.Domain.Enums;

namespace Products.Application.DTOs
{
    public record CreateProductDto(
        string Name,
        decimal Price,
        CategoryEnum Category,
        string? Description,
        string? ImageUrl
    );
}