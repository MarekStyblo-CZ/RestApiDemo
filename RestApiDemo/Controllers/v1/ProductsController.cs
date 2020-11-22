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
    [Route("api/v1.0/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Returns whole list of products from db
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }
    }
}
