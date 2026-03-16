using ProductManagementDemo.API.DTOs;

namespace ProductManagementDemo.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductDetailDto> GetProductByIdAsync(int id);
        Task<PagedResultDto<ProductSummaryDto>> GetAllProductsAsync(ProductFilterDto filter, int page = 1, int size = 10);
        Task<ProductDetailDto> CreateProductAsync(CreateProductDto dto);
        Task<ProductDetailDto> UpdateProductAsync(int id, UpdateProductDto dto);
        Task<bool> DeleteProductAsync(int id);
        Task<bool> SoftDeleteProductAsync(int id);

        Task<List<ProductSummaryDto>> GetFeaturedProductsAsync(int count = 10);
        Task<List<ProductSummaryDto>> GetBestSellingProductsAsync(int count = 10);
        Task<List<ProductSummaryDto>> GetNewArrivalsAsync(int days = 30, int count = 10);

        Task<InventoryStatusDto> GetProductInventoryAsync(int productId);
        Task<bool> UpdateInventoryAsync(int id, UpdateInventoryDto dto);

        Task<bool> IsSkuUniqueAsync(string sku, int? excludeId = null);
    }
}
