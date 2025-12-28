using Products.Application.DTOs;
using Products.Application.Services.Interface;
using Products.Domain.Entities;
using Products.Domain.Enums;
using Products.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Application.Services.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public async Task<ProductDto?> GetByIdAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            return product != null ? MapToDto(product) : null;
        }

        public async Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            var products = await _repository.GetAllAsync();
            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> GetByCategoryAsync(CategoryEnum category)
        {
            var products = await _repository.GetByCategoryAsync(category);
            return products.Select(MapToDto);
        }

        public async Task<IEnumerable<ProductDto>> GetActiveProductsAsync()
        {
            var products = await _repository.GetActiveProductsAsync();
            return products.Select(MapToDto);
        }

        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Category = dto.Category,
                Description = dto.Description,
                ImageUrl = dto.ImageUrl,
                Active = true
            };

            var created = await _repository.AddAsync(product);
            return MapToDto(created);
        }

        public async Task<ProductDto> UpdateAsync(int id, UpdateProductDto dto)
        {
            var product = await _repository.GetByIdAsync(id)
                ?? throw new KeyNotFoundException($"Produto com ID {id} não encontrado");

            product.UpdateInfo(dto.Name, dto.Description, dto.ImageUrl);
            product.UpdatePrice(dto.Price);
            product.Active = dto.Active;
            product.Category = dto.Category;

            var updated = await _repository.UpdateAsync(product);
            return MapToDto(updated);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        private static ProductDto MapToDto(Product product) => new(
            product.Id,
            product.Name,
            product.Price,
            product.Category,
            product.Description,
            product.Active,
            product.ImageUrl,
            product.CreatedAt,
            product.UpdatedAt
        );
    }
}