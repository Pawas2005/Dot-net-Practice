using ProductManagementDemo.API.Entities;

namespace ProductManagementDemo.API.Data
{
    public static class SeedData
    {
        public static async Task InitializeAsync(AppDbContext context)
        {
            if (context.Categories.Any()) return;

            // Categories
            var electronics = new Category { Name = "Electronics", DisplayOrder = 1 };
            var clothing = new Category { Name = "Clothing", DisplayOrder = 2 };
            var books = new Category { Name = "Books", DisplayOrder = 3 };
            context.Categories.AddRange(electronics, clothing, books);
            await context.SaveChangesAsync();

            var phones = new Category { Name = "Smartphones", DisplayOrder = 1, ParentCategoryId = electronics.Id };
            var laptops = new Category { Name = "Laptops", DisplayOrder = 2, ParentCategoryId = electronics.Id };
            context.Categories.AddRange(phones, laptops);
            await context.SaveChangesAsync();

            // Suppliers
            var supplier1 = new Supplier { Name = "TechSupply Co.", Email = "contact@techsupply.com", Phone = "555-0100", Rating = 4.5 };
            var supplier2 = new Supplier { Name = "Global Goods Ltd.", Email = "info@globalgoods.com", Phone = "555-0200", Rating = 4.2 };
            context.Suppliers.AddRange(supplier1, supplier2);
            await context.SaveChangesAsync();

            // Products
            var p1 = new Product
            {
                Name = "iPhone 15 Pro",
                Description = "Apple flagship smartphone with titanium design and A17 Pro chip.",
                Price = 999.99m,
                DiscountedPrice = 949.99m,
                CategoryId = phones.Id,
                SupplierId = supplier1.Id,
                SKU = "APPL-IP15P-256",
                IsActive = true,
                IsFeatured = true,
                CreatedAt = DateTime.UtcNow,
                PublishedAt = DateTime.UtcNow,
                ImageUrl = "https://example.com/iphone15pro.jpg",
                Tags = "[\"smartphone\",\"apple\",\"ios\"]",
                Specifications = "{\"Storage\":\"256GB\",\"Color\":\"Natural Titanium\"}",
                AverageRating = 4.8,
                ReviewCount = 120
            };
            var p2 = new Product
            {
                Name = "Dell XPS 15",
                Description = "Premium laptop with OLED display and Intel Core i9.",
                Price = 1799.99m,
                CategoryId = laptops.Id,
                SupplierId = supplier2.Id,
                SKU = "DELL-XPS15-I9",
                IsActive = true,
                IsFeatured = true,
                CreatedAt = DateTime.UtcNow,
                PublishedAt = DateTime.UtcNow,
                ImageUrl = "https://example.com/dellxps15.jpg",
                Tags = "[\"laptop\",\"dell\",\"windows\"]",
                Specifications = "{\"RAM\":\"32GB\",\"Storage\":\"1TB SSD\"}",
                AverageRating = 4.6,
                ReviewCount = 85
            };
            var p3 = new Product
            {
                Name = "Samsung Galaxy S24",
                Description = "Flagship Android smartphone with AI features.",
                Price = 899.99m,
                CategoryId = phones.Id,
                SupplierId = supplier1.Id,
                SKU = "SAMS-GS24-128",
                IsActive = true,
                CreatedAt = DateTime.UtcNow,
                PublishedAt = DateTime.UtcNow,
                ImageUrl = "https://example.com/galaxys24.jpg",
                Tags = "[\"smartphone\",\"samsung\",\"android\"]",
                Specifications = "{\"RAM\":\"8GB\",\"Storage\":\"128GB\"}",
                AverageRating = 4.5,
                ReviewCount = 95
            };
            context.Products.AddRange(p1, p2, p3);
            await context.SaveChangesAsync();

            // Inventory
            context.Inventories.AddRange(
                new Inventory { ProductId = p1.Id, Quantity = 50, ReorderPoint = 10, WarehouseLocation = "A1-01", LastRestockedAt = DateTime.UtcNow },
                new Inventory { ProductId = p2.Id, Quantity = 20, ReorderPoint = 5, WarehouseLocation = "B2-03", LastRestockedAt = DateTime.UtcNow },
                new Inventory { ProductId = p3.Id, Quantity = 75, ReorderPoint = 15, WarehouseLocation = "A1-05", LastRestockedAt = DateTime.UtcNow }
            );

            // Attributes
            context.ProductAttributes.AddRange(
                new ProductAttribute { ProductId = p1.Id, Name = "Color", Value = "Natural Titanium" },
                new ProductAttribute { ProductId = p1.Id, Name = "Storage", Value = "256GB" },
                new ProductAttribute { ProductId = p2.Id, Name = "Display", Value = "15.6\" OLED" }
            );

            // Reviews
            context.ProductReviews.AddRange(
                new ProductReview { ProductId = p1.Id, Rating = 5, Comment = "Excellent phone!", IsApproved = true, CreatedAt = DateTime.UtcNow.AddDays(-5) },
                new ProductReview { ProductId = p1.Id, Rating = 4, Comment = "Great but pricey.", IsApproved = true, CreatedAt = DateTime.UtcNow.AddDays(-3) },
                new ProductReview { ProductId = p2.Id, Rating = 5, Comment = "Best laptop I've owned.", IsApproved = true, CreatedAt = DateTime.UtcNow.AddDays(-10) }
            );

            await context.SaveChangesAsync();
        }
    }
}
