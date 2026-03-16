using System.Text.Json;
using ProductManagementDemo.API.DTOs;
using ProductManagementDemo.API.Entities;

namespace ProductManagementDemo.API.Helpers.Extensions
{
    public static class ProductExtensions
    {
        public static ProductDetailDto ToDetailDto(this Product p) => new()
        {
            Id              = p.Id,
            Name            = p.Name,
            Description     = p.Description,
            Price           = p.Price,
            DiscountedPrice = p.DiscountedPrice,
            IsActive        = p.IsActive,
            IsFeatured      = p.IsFeatured,
            AverageRating   = p.AverageRating,
            ReviewCount     = p.ReviewCount,
            ImageUrl        = p.ImageUrl,
            Category        = new CategoryBasicDto { Id = p.Category?.Id ?? 0, Name = p.Category?.Name ?? "" },
            Supplier        = p.Supplier != null ? new SupplierBasicDto { Id = p.Supplier.Id, Name = p.Supplier.Name } : null,
            Inventory       = p.Inventory?.ToStatusDto(),
            Tags            = TryDeserialize<List<string>>(p.Tags) ?? new(),
            Specifications  = TryDeserialize<Dictionary<string, string>>(p.Specifications) ?? new(),
            Attributes      = p.Attributes.Select(a => new ProductAttributeDto { Name = a.Name, Value = a.Value }).ToList(),
            RecentReviews   = p.Reviews
                .Where(r => r.IsApproved)
                .OrderByDescending(r => r.CreatedAt)
                .Take(5)
                .Select(r => new ProductReviewDto { Rating = r.Rating, Comment = r.Comment, CreatedAt = r.CreatedAt })
                .ToList()
        };

        public static ProductSummaryDto ToSummaryDto(this Product p) => new()
        {
            Id              = p.Id,
            Name            = p.Name,
            Description     = p.Description?.Length > 100 ? p.Description[..100] + "..." : p.Description ?? "",
            Price           = p.Price,
            DiscountedPrice = p.DiscountedPrice,
            ImageUrl        = p.ImageUrl,
            CategoryName    = p.Category?.Name ?? "",
            AverageRating   = p.AverageRating,
            ReviewCount     = p.ReviewCount,
            IsInStock       = p.Inventory?.AvailableQuantity > 0
        };

        public static InventoryStatusDto ToStatusDto(this Inventory i) => new()
        {
            AvailableQuantity = i.AvailableQuantity,
            ReorderPoint      = i.ReorderPoint,
            WarehouseLocation = i.WarehouseLocation,
            LastRestockedAt   = i.LastRestockedAt
        };

        private static T? TryDeserialize<T>(string? json)
        {
            if (string.IsNullOrWhiteSpace(json)) return default;
            try { return JsonSerializer.Deserialize<T>(json); }
            catch { return default; }
        }
    }
}
