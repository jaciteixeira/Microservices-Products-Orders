using Products.Domain.Enums;
using System;

namespace Products.Application.DTOs
{
    public record ProductDto(
        int Id,
        string Name,
        decimal Price,
        CategoryEnum Category,
        string? Description,
        bool Active,
        string? ImageUrl,
        DateTime CreatedAt,
        DateTime UpdatedAt
    );
}