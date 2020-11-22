using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApiDemo.Services;

namespace RestApiDemo.Controllers.v1
{
    /// <summary>
    /// Version v1 of the API
    /// </summary>
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/v1.0")]
    [ApiController]
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
            var product = await _productService.GetByIdAsync(productId);
            if (product == null)
                return NotFound();
            else
                return Ok(product);
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
    }
}
