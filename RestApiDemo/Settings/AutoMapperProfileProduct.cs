using AutoMapper;
using RestApiDemo.Contracts.v1.ModelDtos;
using RestApiDemo.Models.DbSets;

namespace RestApiDemo.Settings
{
    public class AutoMapperProfileProduct:Profile
    {
        public AutoMapperProfileProduct()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
