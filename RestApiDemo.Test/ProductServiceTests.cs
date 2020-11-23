using AutoMapper;
using Moq;
using RestApiDemo.Contracts.v1.ModelDtos;
using RestApiDemo.Data.Repository;
using RestApiDemo.Data.TestDataSet;
using RestApiDemo.Models.DbSets;
using RestApiDemo.Services;
using RestApiDemo.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace RestApiDemo.Test
{
    public class ProductServiceTests
    {
        private const string DATA_SOURCE = "MEMORY"; //DB or MEMORY
        private const string DB_CONNECTION_STRING = "Server=(localdb)\\mssqllocaldb;Database=RestApiDemo.marek.styblo;Trusted_Connection=True;MultipleActiveResultSets=true";

        private readonly IMapper _mapper; //reinitialised for each test
        private readonly Mock<ILoggingService> _logger; //reinitialised for each test
        private readonly ProductService _sut; //reinitialised for each test
        private readonly TestData _demoData; //reinitialised for each test

        //reinitalised before each test
        public ProductServiceTests()
        {
            //init automapper
            var automapperProfileProduct = new AutoMapperProfileProduct();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(automapperProfileProduct));
            _mapper = new Mapper(configuration);

            //init logger
            _logger = new Mock<ILoggingService>();

            _demoData = new TestData();

            switch (DATA_SOURCE)
            {
                case "DB":
                    var repoDb = new ProductRepository(_demoData.GetDbContext(DB_CONNECTION_STRING), _mapper);
                    _sut = new ProductService(repoDb, _logger.Object, _mapper); //access real db data
                    break;
                case "MEMORY":
                    var repoMem = new ProductRepository(new TestData().GenerateInMemoryTestData(), _mapper);
                    _sut = new ProductService(repoMem, _logger.Object, _mapper); //access moq data through in memory db
                    break;
                default:
                    throw new ArgumentException($"Unknown data source. Requested:{DATA_SOURCE}. Known options: [DB,MEMORY] ");
            }
        }

        [Theory]
        [InlineData(1)]
        public async Task GetByIdAsync_ShouldReturnProduct_WhenProductExists(int productId)
        {
            //arrange
            var expectedProduct = _demoData.DemoProducts.FirstOrDefault(p => p.Id == productId);

            //act
            var receivedProduct = await _sut.GetByIdAsync(expectedProduct.Id);

            //assert
            Assert.Equal(expectedProduct.Id, receivedProduct.Id);
            Assert.Equal(expectedProduct.Name, receivedProduct.Name);
            Assert.Equal(expectedProduct.ImgUri, receivedProduct.ImgUri);
            Assert.Equal(expectedProduct.Price, receivedProduct.Price);
            Assert.Equal(expectedProduct.Description, receivedProduct.Description);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task GetByIdAsync_ShouldReturnException_WhenProductIdLessThan1(int productId)
        {
            //act + assert
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.GetByIdAsync(productId));
        }

        [Theory]
        [InlineData(100)]
        public async Task GetByIdAsync_ShouldReturnNull_WhenProductDoesNotExists(int productId)
        {
            //arrange
            //_productRepoMock.Setup(p => p.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(() => null);

            //act
            var receivedProduct = await _sut.GetByIdAsync(productId);

            //assert
            Assert.Null(receivedProduct);
        }


        [Fact]
        public async Task GetAllAsync_ShouldReturnAllProducts_WhenThereAreData()
        {
            //arrange
            var expectedProducts = _demoData.DemoProducts.OrderBy(p => p.Id).ToList();

            //act
            var receivedProducts = await _sut.GetAllAsync();

            //assert
            Assert.Equal(expectedProducts.Count(), receivedProducts.Count());

            //supposing the lists are ordered in the same way by Id
            for (int i = 0; i < expectedProducts.Count(); i++)
            {
                Assert.Equal(expectedProducts[i].Id, receivedProducts[i].Id);
                Assert.Equal(expectedProducts[i].Name, receivedProducts[i].Name);
                Assert.Equal(expectedProducts[i].ImgUri, receivedProducts[i].ImgUri);
                Assert.Equal(expectedProducts[i].Price, receivedProducts[i].Price);
                Assert.Equal(expectedProducts[i].Description, receivedProducts[i].Description);
            }
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturnEmptyList_WhenThereAreNoData()
        {
            //arrange
            var expectedProducts = new List<ProductDto>();
            //hard switch to just inmemory db to avoid deleting whole data set in case sql db data source selected 
            var inMemoryDbSut = new ProductService(new ProductRepository(new TestData().GenerateInMemoryTestDataEmpty(), _mapper), _logger.Object, _mapper); //access moq data

            //act
            var receivedProducts = await inMemoryDbSut.GetAllAsync();

            //assert
            Assert.Equal(expectedProducts.Count() == 0, receivedProducts.Count() == 0);
        }


        [Theory]
        [InlineData(0, 1)]
        public async Task GetAllPagedAsync_ShouldReturnException_WhenPageNrLower1(int pageNr, int pageSize)
        {
            //acr + assert
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.GetAllPagedAsync(pageNr, pageSize));
        }

        [Theory]
        [InlineData(1, 0)]
        public async Task GetAllPagedAsync_ShouldReturnException_WhenPageSizeLower1(int pageNr, int pageSize)
        {
            //acr + assert
            await Assert.ThrowsAsync<ArgumentException>(() => _sut.GetAllPagedAsync(pageNr, pageSize));
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(2, 2)]
        public async Task GetAllPagedAsync_ShouldReturnPagedProducts_WhenThereAreData(int pageNr, int pageSize)
        {
            //arrange
            var expectedProducts = _demoData.DemoProducts
                .OrderBy(p => p.Id)
                .Skip((pageNr - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(p => p.Id)
                .ToList();

            //act
            var receivedProducts = (await _sut.GetAllPagedAsync(pageNr, pageSize)).ToList();

            //assert
            Assert.Equal(expectedProducts.Count(), receivedProducts.Count());

            //supposing the lists are ordered in the same way by Id
            for (int i = 0; i < expectedProducts.Count(); i++)
            {
                Assert.Equal(expectedProducts[i].Id, receivedProducts[i].Id);
                Assert.Equal(expectedProducts[i].Name, receivedProducts[i].Name);
                Assert.Equal(expectedProducts[i].ImgUri, receivedProducts[i].ImgUri);
                Assert.Equal(expectedProducts[i].Price, receivedProducts[i].Price);
                Assert.Equal(expectedProducts[i].Description, receivedProducts[i].Description);
            }
        }

        [Theory]
        [InlineData(4, 10)]
        public async Task GetAllPagedAsync_ShouldReturnEmptyList_WhenOutOfDataLimits(int pageNr, int pageSize)
        {
            //arrange
            var expectedProducts = new List<ProductDto>();

            //act
            var receivedProducts = (await _sut.GetAllPagedAsync(pageNr, pageSize)).ToList();

            //assert
            Assert.Equal(expectedProducts.Count(), receivedProducts.Count());
                        
        }

        [Theory]
        [InlineData(1, 2)]
        public async Task GetAllPagedAsync_ShouldReturnEmptyList_WhenThereAreNoData(int pageNr, int pageSize)
        {
            //arrange
            var expectedProducts = new List<ProductDto>();
            //hard switch to just inmemory db to avoid deleting whole data set in case sql db data source selected 
            var inMemoryDbSut = new ProductService(new ProductRepository(new TestData().GenerateInMemoryTestDataEmpty(), _mapper), _logger.Object, _mapper); //access moq data

            //act
            var receivedProducts = (await inMemoryDbSut.GetAllPagedAsync(pageNr, pageSize)).ToList();

            //assert
            Assert.Equal(expectedProducts.Count() == 0, receivedProducts.Count() == 0);
        }

        [Theory]
        [InlineData(1, "new test Descr")]
        public async Task UpdateDescrAsync_ShouldReturnUpdatedProduct_WhenProductIdFound(int productId, string newDescription)
        {
            //arrange
            var expectedProduct = _demoData.DemoProducts.FirstOrDefault(p => p.Id == productId);
            var originalDescr = expectedProduct.Description;
            
            expectedProduct.Description = newDescription;

            //act
            var updatedProduct = await _sut.UpdateDescrAsync(productId, newDescription);

            //assert
            Assert.Equal(expectedProduct.Id, updatedProduct.Id);
            Assert.Equal(expectedProduct.Name, updatedProduct.Name);
            Assert.Equal(expectedProduct.ImgUri, updatedProduct.ImgUri);
            Assert.Equal(expectedProduct.Price, updatedProduct.Price);
            Assert.Equal(expectedProduct.Description, updatedProduct.Description);

            await _sut.UpdateDescrAsync(productId, originalDescr); //restore original description in db for other tests
        }

        [Theory]
        [InlineData(100, "new test Descr")]
        public async Task UpdateDescrAsync_ShouldReturnNull_WhenProductIdNotFound(int productId, string newDescription)
        {
            //arrange
            Product expectedProduct = null;

            //act
            var updatedProduct = await _sut.UpdateDescrAsync(productId, newDescription);

            //assert
            Assert.Equal(expectedProduct == null, updatedProduct == null);
        }

    }
}
