using AutoMapper;
using RestApiDemo.Contracts.v1.ModelDtos;
using RestApiDemo.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiDemo.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ILoggingService _logger;
        private readonly IMapper _mapper;

        public ProductService()
        {
        }

        public ProductService(IProductRepository productRepository, ILoggingService logger, IMapper mapper)
        {
            _productRepository = productRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = (await _productRepository.GetAllAsync()).ToList();
            _logger.LogDebug("Retrieved {Count} products", products.Count); //#todo test
            var productDtos = new List<ProductDto>();
            products.ForEach(p => productDtos.Add(_mapper.Map(p, new ProductDto())));
            return productDtos;
        }

    }
}
       
