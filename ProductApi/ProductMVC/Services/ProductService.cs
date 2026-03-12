using Newtonsoft.Json;
using ProductMVC.Models;
using System.Text;

namespace ProductMVC.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<ProductService> _logger;
        private readonly string _baseUrl = "api/products/";

        public ProductService(HttpClient httpClient, ILogger<ProductService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        // GET all products
        public async Task<List<Product>> GetAllProductsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(_baseUrl);
                response.EnsureSuccessStatusCode();

                var content = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(content);

                return products ?? new List<Product>();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting products from API");
                throw;
            }
        }

        // GET product by ID
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{_baseUrl}{id}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<Product>(content);
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error getting product {id} from API");
                throw;
            }
        }

        // POST create product
        public async Task<Product?> CreateProductAsync(Product product)
        {
            try
            {
                var json = JsonConvert.SerializeObject(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(_baseUrl, content);
                response.EnsureSuccessStatusCode();

                var responseContent = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Product>(responseContent);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating product");
                throw;
            }
        }

        // PUT update product
        public async Task<bool> UpdateProductAsync(int id, Product product)
        {
            try
            {
                var json = JsonConvert.SerializeObject(product);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PutAsync($"{_baseUrl}{id}", content);
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error updating product {id}");
                throw;
            }
        }

        // DELETE product
        public async Task<bool> DeleteProductAsync(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync($"{_baseUrl}{id}");
                return response.IsSuccessStatusCode;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting product {id}");
                throw;
            }
        }
    }
}
