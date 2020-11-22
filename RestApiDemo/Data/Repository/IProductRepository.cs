using RestApiDemo.Models.DbSets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestApiDemo.Data.Repository
{
    public interface IProductRepository
    {
        Task<Product> GetByIdAsync(int productId);
        Task<IEnumerable<Product>> GetAllAsync();
        Task<IEnumerable<Product>> GetAllPagedAsync(int pageNr, int pageSize);
        Task<Product> UpdateDescrAsync(int productId, string newDescription);
    }
}
