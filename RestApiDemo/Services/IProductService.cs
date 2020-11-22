using RestApiDemo.Contracts.v1.ModelDtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApiDemo.Services
{
    /// <summary>
    /// Intermediate service handling data between repository and controller
    /// </summary>
    public interface IProductService
    {
        Task<ProductDto> GetByIdAsync(int productId);
        Task<List<ProductDto>> GetAllAsync();
        Task<IEnumerable<ProductDto>> GetAllPagedAsync(int pageNr, int pageSize);
        Task<ProductDto> UpdateDescrAsync(int productId, string newDescription);
    }
}
