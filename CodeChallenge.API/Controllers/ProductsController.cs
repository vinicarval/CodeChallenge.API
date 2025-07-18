using CodeChallenge.API.Models;
using CodeChallenge.API.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CodeChallenge.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            return Ok(await _productService.GetAllProductsAsync());
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productService.GetProductByIdAsync(id));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(Product product)
        {
            return Created($"api/products/{product.Id}", await _productService.AddProductAsync(product));
        }


        [HttpPut]
        public async Task<IActionResult> Put(Product product)
        {
            var result = await _productService.UpdateProductAsync(product);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteProductAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
