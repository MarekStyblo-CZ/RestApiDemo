using Microsoft.AspNetCore.Mvc;
using RestApiDemo.Services;
using System.Threading.Tasks;

namespace RestApiDemo.Controllers.v2
{
    /// <summary>
    /// Version v2 of the API
    /// </summary>
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/v2.0")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ProductsController : ControllerBase
    {
        private const int DEFAULT_PAGE_SIZE = 10;

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Returns product list paged
        /// </summary>
        /// <param name="pageNr">Starting page</param>
        /// <param name="pageSize">Nr of products on page</param>
        /// <returns></returns>
        [HttpGet("products")]
        public async Task<ActionResult> GetProducts(int pageNr, int pageSize = DEFAULT_PAGE_SIZE)
        {
            var products = await _productService.GetAllPagedAsync(pageNr, pageSize);
            return Ok(products);
        }
    }
}
