using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders.Infrastructure.HttpClients
{
    public record ProductResponse(
        int Id,
        string Name,
        decimal Price,
        string Category,
        string? Description,
        bool Active,
        string? ImageUrl
    );
}