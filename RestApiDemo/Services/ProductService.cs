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

        public async Task<ProductDto> GetByIdAsync(int productId)
        {
            if (productId < 1)
            {
                _logger.LogDebug("productId < 1", productId);
                throw new ArgumentException("productId < 1"); //#todo
            }
            var product = await _productRepository.GetByIdAsync(productId);

            if (product != null)
            {
                _logger.LogDebug($"Found product with Id:{productId}", product);
                return _mapper.Map(product, new ProductDto());
            }
            else
            {
                _logger.LogDebug($"product with Id:{productId} not found", productId);
                return null;
            }
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = (await _productRepository.GetAllAsync()).ToList();
            _logger.LogDebug("Retrieved {Count} products", products.Count); //#todo test
            var productDtos = new List<ProductDto>();
            products.ForEach(p => productDtos.Add(_mapper.Map(p, new ProductDto())));
            return productDtos;
        }

        public async Task<IEnumerable<ProductDto>> GetAllPagedAsync(int pageNr, int pageSize)
        {
            if (pageNr < 1)
            {
                _logger.LogDebug("pageNr < 1", pageNr);
                throw new ArgumentException("pageNr < 1");
            }
            if (pageSize < 1)
            {
                _logger.LogDebug("pageSize < 1", pageNr);
                throw new ArgumentException("pageSize < 1");
            }

            var productsPaged = (await _productRepository.GetAllPagedAsync(pageNr, pageSize)).ToList();
            _logger.LogDebug("Retrieved {Count} products", productsPaged.Count); //#todo

            var productDtos = new List<ProductDto>();
            productsPaged.ForEach(p => productDtos.Add(_mapper.Map(p, new ProductDto())));
            return productDtos;
        }

        public async Task<ProductDto> UpdateDescrAsync(int productId, string newDescription)
        {
            if (productId < 1)
            {
                _logger.LogDebug("productId < 1", productId);
                throw new ArgumentException("productId < 1");
            }

            var updatedProduct = await _productRepository.UpdateDescrAsync(productId, newDescription);
            if (updatedProduct == null)
                _logger.LogDebug($"Product id:{productId} not found", newDescription); //#todo
            else
                _logger.LogDebug($"Product id:{productId} updated with new description", newDescription); //#todo

            return _mapper.Map(updatedProduct, new ProductDto());
        }

    }
}
       
