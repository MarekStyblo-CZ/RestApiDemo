using Microsoft.EntityFrameworkCore;
using RestApiDemo.Models.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiDemo.Data.TestDataSet
{
    public class TestData
    {
        public List<Product> DemoProducts { get; set; }

        public TestData()
        {
            DemoProducts = new List<Product>();

            DemoProducts.Add(new Product { Id = 1, Name = "Notebook Hp 110", ImgUri = "products/notebooks/HP/110/img.jpg", Price = 5500, Description = "Hp 110, 2,1 Ghz processor" });
            DemoProducts.Add(new Product { Id = 2, Name = "Notebook Hp 210", ImgUri = "products/notebooks/HP/210/img.jpg", Price = 5600, Description = "Hp 210, 2,2 Ghz processor" });
            DemoProducts.Add(new Product { Id = 3, Name = "Notebook Hp 310", ImgUri = "products/notebooks/HP/310/img.jpg", Price = 5700, Description = "Hp 310, 2,3 Ghz processor" });
            DemoProducts.Add(new Product { Id = 4, Name = "Notebook Hp 410", ImgUri = "products/notebooks/HP/410/img.jpg", Price = 5800, Description = "Hp 410, 2,4 Ghz processor" });
            DemoProducts.Add(new Product { Id = 5, Name = "Notebook Hp 510", ImgUri = "products/notebooks/HP/510/img.jpg", Price = 5900, Description = "Hp 510, 2,5 Ghz processor" });
            DemoProducts.Add(new Product { Id = 6, Name = "Notebook Hp 610", ImgUri = "products/notebooks/HP/610/img.jpg", Price = 6000, Description = "Hp 610, 2,6 Ghz processor" });
            DemoProducts.Add(new Product { Id = 7, Name = "Notebook Hp 710", ImgUri = "products/notebooks/HP/710/img.jpg", Price = 6100, Description = "Hp 710, 2,7 Ghz processor" });
            DemoProducts.Add(new Product { Id = 8, Name = "Notebook Hp 810", ImgUri = "products/notebooks/HP/810/img.jpg", Price = 6200, Description = "Hp 810, 2,1 Ghz processor" });
            DemoProducts.Add(new Product { Id = 9, Name = "Notebook Hp 910", ImgUri = "products/notebooks/HP/910/img.jpg", Price = 6300, Description = "Hp 910, 2,2 Ghz processor" });
            DemoProducts.Add(new Product { Id = 10, Name = "Notebook Hp 1010", ImgUri = "products/notebooks/HP/1010/img.jpg", Price = 6400, Description = "Hp 1010, 2,3 Ghz processor" });
            DemoProducts.Add(new Product { Id = 11, Name = "Notebook Hp 1110", ImgUri = "products/notebooks/HP/1110/img.jpg", Price = 6500, Description = "Hp 1110, 2,4 Ghz processor" });
            DemoProducts.Add(new Product { Id = 12, Name = "Notebook Hp 1210", ImgUri = "products/notebooks/HP/1210/img.jpg", Price = 6600, Description = "Hp 1210, 2,5 Ghz processor" });
            DemoProducts.Add(new Product { Id = 13, Name = "Notebook Hp 1310", ImgUri = "products/notebooks/HP/1310/img.jpg", Price = 6700, Description = "Hp 1310, 2,6 Ghz processor" });
            DemoProducts.Add(new Product { Id = 14, Name = "Notebook Hp 1410", ImgUri = "products/notebooks/HP/1410/img.jpg", Price = 6800, Description = "Hp 1410, 2,7 Ghz processor" });
            DemoProducts.Add(new Product { Id = 15, Name = "Notebook Hp 1510", ImgUri = "products/notebooks/HP/1510/img.jpg", Price = 6900, Description = "Hp 1510, 2,1 Ghz processor" });
            DemoProducts.Add(new Product { Id = 16, Name = "Notebook Hp 1610", ImgUri = "products/notebooks/HP/1610/img.jpg", Price = 7000, Description = "Hp 1610, 2,2 Ghz processor" });
            DemoProducts.Add(new Product { Id = 17, Name = "Notebook Hp 1710", ImgUri = "products/notebooks/HP/1710/img.jpg", Price = 7100, Description = "Hp 1710, 2,3 Ghz processor" });
            DemoProducts.Add(new Product { Id = 18, Name = "Notebook Hp 1810", ImgUri = "products/notebooks/HP/1810/img.jpg", Price = 7200, Description = "Hp 1810, 2,4 Ghz processor" });
            DemoProducts.Add(new Product { Id = 19, Name = "Notebook Hp 1910", ImgUri = "products/notebooks/HP/1910/img.jpg", Price = 7300, Description = "Hp 1910, 2,5 Ghz processor" });
            DemoProducts.Add(new Product { Id = 20, Name = "Notebook Hp 2010", ImgUri = "products/notebooks/HP/2010/img.jpg", Price = 7400, Description = "Hp 2010, 2,6 Ghz processor" });
            DemoProducts.Add(new Product { Id = 21, Name = "Notebook Hp 2110", ImgUri = "products/notebooks/HP/2110/img.jpg", Price = 7500, Description = "Hp 2110, 2,7 Ghz processor" });

        }

        /// <summary>
        /// Get dbContext for Sql database
        /// </summary>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public SqlDbContext GetDbContext(string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqlDbContext>();
            optionsBuilder.UseSqlServer(connectionString);
            return new SqlDbContext(optionsBuilder.Options);
        }

        /// <summary>
        /// Get dbContext for InMemory database
        /// </summary>
        /// <returns></returns>
        public SqlDbContext GenerateInMemoryTestData()
        {
            var options = new DbContextOptionsBuilder<SqlDbContext>()
            .UseInMemoryDatabase(databaseName: "ProductDbInMemory")
            .Options;

            // Insert seed data into the database using one instance of the context
            var dbContext = new SqlDbContext(options);

            //remove all data if there are already some from previous data
            dbContext.Products.ForEachAsync(p => dbContext.Remove(p));
            dbContext.SaveChanges();

            //regenerate data for test
            DemoProducts.ForEach(p => dbContext.Products.Add(p));
            dbContext.SaveChanges();

            return dbContext;
        }

        /// <summary>
        /// Get dbContext for InMemory database which is empty 
        /// </summary>
        /// <returns></returns>
        public SqlDbContext GenerateInMemoryTestDataEmpty()
        {
            var options = new DbContextOptionsBuilder<SqlDbContext>()
            .UseInMemoryDatabase(databaseName: "ProductDbInMemory")
            .Options;

            // Insert seed data into the database using one instance of the context
            var dbContext = new SqlDbContext(options);

            //remove all data if there are already some from previous test
            dbContext.Products.ForEachAsync(p => dbContext.Remove(p));
            dbContext.SaveChanges();

            return dbContext;
        }
    }
}
