using RestApiDemo.Contracts.v1.ModelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiDemo.Services
{
    /// <summary>
    /// Intermediate service handling data between repository and controller
    /// </summary>
    public interface IProductService
    {
        Task<ProductDto> GetByIdAsync(int productId);
    }
}
