using AutoMapper;
using RestApiDemo.Contracts.v1.ModelDtos;
using RestApiDemo.Models.DbSets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
