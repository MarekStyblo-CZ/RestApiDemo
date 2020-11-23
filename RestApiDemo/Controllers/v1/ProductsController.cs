using Microsoft.AspNetCore.Mvc;
using RestApiDemo.Services;
using System;
using System.Threading.Tasks;

namespace RestApiDemo.Controllers.v1
{
    /// <summary>
    /// Version v1 of the API
    /// </summary>
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/v1.0")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Returns product according to its id
        /// </summary>
        /// <param name="productId">PK</param>
        /// <returns></returns>
        [HttpGet("products/{productId}")]
        public async Task<ActionResult> GetProduct(int productId)
        {
            try
            {
                var product = await _productService.GetByIdAsync(productId);
                if (product == null)
                    return NotFound();
                else
                    return Ok(product);
            }
            catch (ArgumentException e)
            {
                return BadRequest(e.Message);
            }
        }
                    

        /// <summary>
        /// Returns whole list of products from db
        /// </summary>
        /// <returns></returns>
        [HttpGet("products")]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        /// <summary>
        /// Updates the product's description
        /// </summary>
        /// <param name="productId">PK</param>
        /// <param name="productDescr">Updated description</param>
        /// <returns></returns>
        [HttpPut("products/{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, string productDescr)
        {
            var productToUpdate = await _productService.UpdateDescrAsync(productId, productDescr);
            if (productToUpdate == null)
                return BadRequest();

            return Accepted();
        }

    }
}
