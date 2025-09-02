using BusinessLogicLayer.IServices;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductsMicroService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("getproduct")]
        public async Task<IActionResult> GetProduct(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Guid not be empty");

            ResponseMessage response = await _productService.GetProductById(id);
            return Ok(response);

        }

        [HttpGet("getproducts")]
        public async Task<IActionResult> GetProducts()
        {

            ResponseMessage response = await _productService.GetAllProducts();
            return Ok(response);

        }

        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (product == null)
                return BadRequest("product not be empty");

            ResponseMessage response = await _productService.AddNewProduct(product);
            return Ok(response);

        }

        [HttpPut("updateproduct")]
        public async Task<IActionResult> UpdateProduct(Product product)
        {
            if (product == null)
                return BadRequest("product not be empty");

            ResponseMessage response = await _productService.UpdateExistingProduct(product);
            return Ok(response);    
        }

        [HttpDelete("deleteproduct")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            if (id == Guid.Empty)
                return BadRequest("Guid not be empty");

            ResponseMessage response = await _productService.DeleteProductById(id);
            return Ok(response);
        }
    }
}
