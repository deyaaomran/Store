using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreP.Core.Services.Contract;

namespace StoreP.APIs.Controllers
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
        [HttpGet] // Get BaseUrl/api/Products
        public async Task<IActionResult> GetAllProduct() // endpoint
        {
            var result =await _productService.GetAllProductsAsync();
            return Ok(result); //200
        }

        [HttpGet("brands")] // Get BaseUrl/api/Products/brands
        public async Task<IActionResult> GetAllBrandsAsync()
        {
            var brand = await _productService.GetAllBrandsAsync();
            return Ok(brand);
        }

        [HttpGet("types")] // Get BaseUrl/api/Products/types
        public async Task<IActionResult> GetAllTypesAsync()
        {
            var type = await _productService.GetAllTypesAsync();
            return Ok(type);
        }

        [HttpGet("{id}")] // Get BaseUrl/api/Products/id
        public async Task<IActionResult> GetProductById(int? id)
        {
            if(id == null) return BadRequest("Invalid id !!");
            var product = await _productService.GetProductById(id.Value);
            if (product == null) return BadRequest($"The Product whit id :{id} not found at DB :( ");
            return Ok(product);
        }

         

         

    }
}
