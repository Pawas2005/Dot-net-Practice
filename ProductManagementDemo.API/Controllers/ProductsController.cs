using Microsoft.AspNetCore.Mvc;
using ProductManagementDemo.API.DTOs;
using ProductManagementDemo.API.Services.Interfaces;

namespace ProductManagementDemo.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _svc;

        public ProductsController(IProductService svc) => _svc = svc;

        // GET api/v1/products?categoryId=1&minPrice=500&sortBy=price&pageNumber=1
        [HttpGet]
        [ProducesResponseType(typeof(PagedResultDto<ProductSummaryDto>), 200)]
        public async Task<ActionResult<PagedResultDto<ProductSummaryDto>>> GetAll(
            [FromQuery] ProductFilterDto filter,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
            => Ok(await _svc.GetAllProductsAsync(filter, pageNumber, pageSize));

        // GET api/v1/products/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProductDetailDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductDetailDto>> Get(int id)
        {
            try { return Ok(await _svc.GetProductByIdAsync(id)); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
        }

        // POST api/v1/products
        [HttpPost]
        [ProducesResponseType(typeof(ProductDetailDto), 201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ProductDetailDto>> Create([FromBody] CreateProductDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            try
            {
                var product = await _svc.CreateProductAsync(dto);
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
            catch (InvalidOperationException ex) { return BadRequest(ex.Message); }
            catch (KeyNotFoundException ex) { return BadRequest(ex.Message); }
        }

        // PUT api/v1/products/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProductDetailDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductDetailDto>> Update(int id, [FromBody] UpdateProductDto dto)
        {
            try { return Ok(await _svc.UpdateProductAsync(id, dto)); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
        }

        // DELETE api/v1/products/5
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Delete(int id)
            => (await _svc.DeleteProductAsync(id)) ? NoContent() : NotFound();

        // PATCH api/v1/products/5/soft-delete
        [HttpPatch("{id}/soft-delete")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> SoftDelete(int id)
            => (await _svc.SoftDeleteProductAsync(id)) ? NoContent() : NotFound();

        // GET api/v1/products/featured?count=6
        [HttpGet("featured")]
        [ProducesResponseType(typeof(List<ProductSummaryDto>), 200)]
        public async Task<ActionResult<List<ProductSummaryDto>>> GetFeatured([FromQuery] int count = 10)
            => Ok(await _svc.GetFeaturedProductsAsync(count));

        // GET api/v1/products/best-selling
        [HttpGet("best-selling")]
        [ProducesResponseType(typeof(List<ProductSummaryDto>), 200)]
        public async Task<ActionResult<List<ProductSummaryDto>>> GetBestSelling([FromQuery] int count = 10)
            => Ok(await _svc.GetBestSellingProductsAsync(count));

        // GET api/v1/products/new-arrivals
        [HttpGet("new-arrivals")]
        [ProducesResponseType(typeof(List<ProductSummaryDto>), 200)]
        public async Task<ActionResult<List<ProductSummaryDto>>> GetNewArrivals(
            [FromQuery] int days = 30, [FromQuery] int count = 10)
            => Ok(await _svc.GetNewArrivalsAsync(days, count));

        // GET api/v1/products/5/inventory
        [HttpGet("{id}/inventory")]
        [ProducesResponseType(typeof(InventoryStatusDto), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<InventoryStatusDto>> GetInventory(int id)
        {
            try { return Ok(await _svc.GetProductInventoryAsync(id)); }
            catch (KeyNotFoundException ex) { return NotFound(ex.Message); }
        }

        // PUT api/v1/products/5/inventory
        [HttpPut("{id}/inventory")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateInventory(int id, [FromBody] UpdateInventoryDto dto)
            => (await _svc.UpdateInventoryAsync(id, dto)) ? NoContent() : NotFound();
    }
}
