using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreP.APIs.Errors;
using StoreP.Core.Dtos.Products;
using StoreP.Core.Helper;
using StoreP.Core.Services.Contract;
using StoreP.Core.Specifications.Products;

namespace StoreP.APIs.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [ProducesResponseType(typeof(PaginationResponse<ProductDto> ), StatusCodes.Status200OK)]
        [HttpGet] // Get BaseUrl/api/Products
        public async Task<ActionResult<PaginationResponse<ProductDto>>> GetAllProduct([FromQuery] ProductSpecParams productSpec) // endpoint
        {
            var result =await _productService.GetAllProductsAsync(productSpec);
            return Ok( result); //200
        }



        [ProducesResponseType(typeof(IEnumerable<TypeBrandDto>), StatusCodes.Status200OK)]
        [HttpGet("brands")] // Get BaseUrl/api/Products/brands
        public async Task<ActionResult<IEnumerable<TypeBrandDto>>> GetAllBrandsAsync()
        {
            var brand = await _productService.GetAllBrandsAsync();
            return Ok(brand);
        }




        [ProducesResponseType(typeof(IEnumerable<TypeBrandDto>), StatusCodes.Status200OK)]
        [HttpGet("types")] // Get BaseUrl/api/Products/types
        public async Task<ActionResult<IEnumerable<TypeBrandDto>>> GetAllTypesAsync()
        {
            var type = await _productService.GetAllTypesAsync();
            return Ok(type);
        }



        [ProducesResponseType(typeof(TypeBrandDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(TypeBrandDto), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(TypeBrandDto), StatusCodes.Status404NotFound)]
        [HttpGet("{id}")] // Get BaseUrl/api/Products/id
        public async Task<IActionResult> GetProductById(int? id)
        {
            if(id == null) return BadRequest(new ApiErrorResponse(400));
            var product = await _productService.GetProductById(id.Value);
            if (product == null) return BadRequest(new ApiErrorResponse(404));
            return Ok(product);
        }

         

         

    }
}
