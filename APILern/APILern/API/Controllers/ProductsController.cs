using APILern.Domain.Entities;
using APILern.Domain.Interface;
using Microsoft.AspNetCore.Mvc;

namespace APILern.Controller;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetAllProductsAsync()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    [HttpGet("{id}", Name = "GetProductById")]
    public async Task<ActionResult<Product>> GetProductByIdAsync(int id)
    {
        var product = await _productService.GetByIdAsync(id);
        return product is null ? NotFound() : Ok(product);
    }

    [HttpPost]
    public async Task<ActionResult> AddProductAsync([FromBody] AddProductDto productDto)
    {
        var createId = await _productService.AddAsync(productDto);

        return CreatedAtRoute(routeName: "GetProductById", routeValues: new { id = createId }, new { id = createId });
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ProductResponseDto>> UpdateProductAsync(int id, [FromBody] UpdateProductDto product)
    {
        var updated = await _productService.UpdateAsync(id, product);
        return updated is null ? NotFound() : Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProductAsync(int id)
    {
        var success = await _productService.DeleteAsync(id);
        return success ? NoContent() : NotFound();
    }
}