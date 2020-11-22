using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestApiDemo.Models.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiDemo.Data.Repository
{
    /// <summary>
    /// Repository to centralise the queries for products
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly SqlDbContext _db;
        
        public ProductRepository(SqlDbContext dbContext)
        {
            _db = dbContext;            
        }

        public async Task<Product> GetByIdAsync(int productId)
        {
            return await this._db.Products
                .FirstOrDefaultAsync(p => p.Id == productId);
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await this._db.Products
                .OrderBy(p => p.Id)
                .ToListAsync();
        }

        public async Task<Product> UpdateDescrAsync(int productId, string newDescription)
        {
            var productToUpdate = await this._db.Products
                .FirstOrDefaultAsync(p => p.Id == productId);

            if (productToUpdate != null) // item found
            {
                productToUpdate.Description = newDescription;
                await this._db.SaveChangesAsync();
                return productToUpdate;
            }
            else
                return null;
        }


    }
}
