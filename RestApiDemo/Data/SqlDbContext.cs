using Microsoft.EntityFrameworkCore;
using RestApiDemo.Data.TestDataSet;
using RestApiDemo.Models.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiDemo.Data
{
    public class SqlDbContext : DbContext
    {
        public SqlDbContext(DbContextOptions<SqlDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var testData = new TestData();
           
            modelBuilder.Entity<Product>().HasData(testData.DemoProducts); //ensures that by using Add-migration -> db will be populated with initial test data
        }

    }
}
