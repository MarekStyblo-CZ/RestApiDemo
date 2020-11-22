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

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await this._db.Products
                .OrderBy(p => p.Id)
                .ToListAsync();
        }


    }
}
