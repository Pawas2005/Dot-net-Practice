using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManagementDemo.API.Data;
using ProductManagementDemo.API.DTOs;
using ProductManagementDemo.API.Entities;
using ProductManagementDemo.API.Helpers.Extensions;
using ProductManagementDemo.API.Helpers.QueryObjects;
using ProductManagementDemo.API.Services.Interfaces;

namespace ProductManagementDemo.API.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ProductQuery _productQuery;
        private readonly ILogger<ProductService> _logger;

        public ProductService(AppDbContext context, IMapper mapper, ILogger<ProductService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
            _productQuery = new ProductQuery();
        }

        public async Task<ProductDetailDto> GetProductByIdAsync(int id)
        {
            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .Include(p => p.Inventory)
                .Include(p => p.Attributes)
                .Include(p => p.Reviews)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == id)
                ?? throw new KeyNotFoundException($"Product {id} not found");

            return product.ToDetailDto();
        }

        public async Task<PagedResultDto<ProductSummaryDto>> GetAllProductsAsync(
            ProductFilterDto filter, int page = 1, int size = 10)
        {
            var query = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Inventory)
                .AsNoTracking();

            query = _productQuery.ApplyFilter(query, filter);
            var total = await query.CountAsync();

            query = _productQuery.ApplySorting(query, filter?.SortBy, filter?.SortDescending ?? false);
            var products = await _productQuery.ApplyPagination(query, page, size).ToListAsync();

            return new PagedResultDto<ProductSummaryDto>
            {
                Items      = products.Select(p => p.ToSummaryDto()).ToList(),
                TotalCount = total,
                PageNumber = page,
                PageSize   = size,
                TotalPages = (int)Math.Ceiling(total / (double)size)
            };
        }

        public async Task<ProductDetailDto> CreateProductAsync(CreateProductDto dto)
        {
            if (!await IsSkuUniqueAsync(dto.Sku))
                throw new InvalidOperationException($"SKU '{dto.Sku}' already exists");

            if (await _context.Categories.FindAsync(dto.CategoryId) == null)
                throw new KeyNotFoundException($"Category {dto.CategoryId} not found");

            var product = _mapper.Map<Product>(dto);
            product.CreatedAt = DateTime.UtcNow;
            product.PublishedAt = DateTime.UtcNow;

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            _context.Inventories.Add(new Inventory
            {
                ProductId       = product.Id,
                Quantity        = 0,
                ReorderPoint    = dto.MinimumStockQuantity,
                LastRestockedAt = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();

            _logger.LogInformation("Product created: {Name} ({Sku})", product.Name, product.SKU);
            return await GetProductByIdAsync(product.Id);
        }

        public async Task<ProductDetailDto> UpdateProductAsync(int id, UpdateProductDto dto)
        {
            var product = await _context.Products.FindAsync(id)
                ?? throw new KeyNotFoundException($"Product {id} not found");

            _mapper.Map(dto, product);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Product updated: {Id}", id);
            return await GetProductByIdAsync(id);
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteProductAsync(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null) return false;

            product.IsActive = false;
            product.UpdatedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProductSummaryDto>> GetFeaturedProductsAsync(int count = 10)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Inventory)
                .Where(p => p.IsFeatured && p.IsActive)
                .OrderByDescending(p => p.AverageRating)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();

            return products.Select(p => p.ToSummaryDto()).ToList();
        }

        public async Task<List<ProductSummaryDto>> GetBestSellingProductsAsync(int count = 10)
        {
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Inventory)
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.SoldCount)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();

            return products.Select(p => p.ToSummaryDto()).ToList();
        }

        public async Task<List<ProductSummaryDto>> GetNewArrivalsAsync(int days = 30, int count = 10)
        {
            var cutoff = DateTime.UtcNow.AddDays(-days);
            var products = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Inventory)
                .Where(p => p.IsActive && p.CreatedAt >= cutoff)
                .OrderByDescending(p => p.CreatedAt)
                .Take(count)
                .AsNoTracking()
                .ToListAsync();

            return products.Select(p => p.ToSummaryDto()).ToList();
        }

        public async Task<InventoryStatusDto> GetProductInventoryAsync(int productId)
        {
            var inventory = await _context.Inventories
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.ProductId == productId)
                ?? throw new KeyNotFoundException($"Inventory for product {productId} not found");

            return inventory.ToStatusDto();
        }

        public async Task<bool> UpdateInventoryAsync(int id, UpdateInventoryDto dto)
        {
            var inventory = await _context.Inventories.FirstOrDefaultAsync(i => i.ProductId == id);
            if (inventory == null) return false;

            inventory.Quantity = dto.Quantity;
            inventory.LastRestockedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> IsSkuUniqueAsync(string sku, int? excludeId = null)
        {
            var query = _context.Products.Where(p => p.SKU == sku);
            if (excludeId.HasValue) query = query.Where(p => p.Id != excludeId.Value);
            return !await query.AnyAsync();
        }
    }
}
