using Microsoft.AspNetCore.Mvc;
using PotApp.Dtos.ProductDtos;
using PotApp.Dtos.UserDtos;
using PotApp.Services;


namespace PotApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(ProductService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GetProductsResponse>> GetProducts()
        => Ok(await service.GetProductsAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await service.GetProductByIdAsync(id);
            if (product is null)
            {
                return NotFound("Product was not found.");
            }
            return Ok(product);
        }   

        [HttpPost]
        public async Task<ActionResult<ProductDto>> CreateProduct(CreateProductRequest request)
        {
            var product = await service.CreateProductAsync(request);
            return StatusCode(StatusCodes.Status201Created, product);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProduct(int id, ProductDto request)
        {
            var product = await service.UpdateProductAsync(id, request);
            if (product is null)
            {
                return NotFound("Product with this Id was not found.");
            }
            return Ok(product);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ProductDto>> UpdateProductPartial(int id, UpdateProductRequest request)
        {
            var product = await service.UpdateProductPartialAsync(id, request);
            if (product is null)
            {
                return NotFound("Product with this Id was not found.");
            }
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            var result = await service.DeleteProductAsync(id);
            if (result is null)
            {
                return NotFound("Product with this Id was not found.");
            }
            return Ok("Product deleted successfully.");
        }
    }
}
