using Products.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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