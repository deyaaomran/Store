

using AutoMapper;
using Microsoft.Extensions.Configuration;
using StoreP.Core.Dtos.Products;
using StoreP.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreP.Core.Mapping.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile(IConfiguration configuration) 
        {
            CreateMap<Product, ProductDto>()
                .ForMember(d => d.BrandName, options => options.MapFrom(s => s.Brand))
                .ForMember(d => d.TypeName, options => options.MapFrom(s => s.Type))
                .ForMember(d => d.PictureUrl, options => options.MapFrom(s => $"{configuration["BASEURL"]}{s.PictureUrl}"));
            CreateMap<ProductBrand , TypeBrandDto>();
            CreateMap<ProductType, TypeBrandDto>();
        }
    }
}
