using Microsoft.AspNetCore.Mvc;
using ProductMVC.Models;
using ProductMVC.Services;

namespace ProductMVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        private readonly ILogger<ProductController> _logger;

        public ProductController(ProductService productService, ILogger<ProductController> logger)
        {
            _productService = productService;
            _logger = logger;
        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                return View(products);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading products");
                TempData["Error"] = "Unable to load products. Please try again.";
                return View(new List<Product>());
            }
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error loading product {id}");
                TempData["Error"] = "Unable to load product details.";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            return View(new Product());
        }

        // POST: Product/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var created = await _productService.CreateProductAsync(product);
                    if (created != null)
                    {
                        TempData["Success"] = "Product created successfully!";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating product");
                    ModelState.AddModelError("", "Unable to create product. Please try again.");
                }
            }
            return View(product);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error loading product {id} for edit");
                TempData["Error"] = "Unable to load product for editing.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Product/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var success = await _productService.UpdateProductAsync(id, product);
                    if (success)
                    {
                        TempData["Success"] = "Product updated successfully!";
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, $"Error updating product {id}");
                    ModelState.AddModelError("", "Unable to update product. Please try again.");
                }
            }
            return View(product);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var product = await _productService.GetProductByIdAsync(id);
                if (product == null)
                {
                    return NotFound();
                }
                return View(product);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error loading product {id} for delete");
                TempData["Error"] = "Unable to load product for deletion.";
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var success = await _productService.DeleteProductAsync(id);
                if (success)
                {
                    TempData["Success"] = "Product deleted successfully!";
                }
                else
                {
                    TempData["Error"] = "Unable to delete product.";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error deleting product {id}");
                TempData["Error"] = "An error occurred while deleting.";
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
