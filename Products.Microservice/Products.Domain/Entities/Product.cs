using Products.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public CategoryEnum Category { get; set; }
        public string? Description { get; set; }
        public bool Active { get; set; } = true;
        public string? ImageUrl { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        // Validações de negócio
        public void Activate() => Active = true;
        public void Deactivate() => Active = false;

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice < 0)
                throw new ArgumentException("O preço não pode ser negativo");

            Price = newPrice;
            UpdatedAt = DateTime.UtcNow;
        }

        public void UpdateInfo(string name, string? description, string? imageUrl)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("O nome do produto é obrigatório");

            Name = name;
            Description = description;
            ImageUrl = imageUrl;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}