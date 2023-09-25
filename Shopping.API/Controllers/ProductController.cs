using Microsoft.AspNetCore.Mvc;
using Shopping.Business.Abstract;
using Shopping.Entities;

namespace Shopping.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }
        [HttpGet]
        [Route("[action]/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductById(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }
        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            var createdProduct = await _productService.CreateProduct(product);
            return CreatedAtAction(nameof(Get), new { id = createdProduct.Id }, createdProduct);
        }
        [HttpPut]
        [Route("[action]")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            if (await _productService.GetProductById(product.Id) != null)
            {
                return Ok(await _productService.UpdateProduct(product));
            }
            return NotFound();
        }
        [HttpDelete]
        [Route("[action]/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (await _productService.GetProductById(id) != null)
            {
                await _productService.DeleteProduct(id);
                return Ok();
            }
            return NotFound();
        }
    }
}