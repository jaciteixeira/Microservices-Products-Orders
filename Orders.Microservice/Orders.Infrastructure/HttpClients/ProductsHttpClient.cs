using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Orders.Infrastructure.HttpClients
{
    public class ProductsHttpClient : IProductsHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProductsHttpClient> _logger;

        public ProductsHttpClient(HttpClient httpClient, ILogger<ProductsHttpClient> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<ProductResponse?> GetProductByIdAsync(int productId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"/api/products/{productId}");

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Produto {ProductId} não encontrado. Status: {Status}",
                        productId, response.StatusCode);
                    return null;
                }

                var content = await response.Content.ReadAsStringAsync();
                var product = JsonSerializer.Deserialize<ProductResponse>(content, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao buscar produto {ProductId}", productId);
                throw new Exception($"Erro ao comunicar com o serviço de produtos: {ex.Message}", ex);
            }
        }
    }
}