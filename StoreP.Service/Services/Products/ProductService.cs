﻿using AutoMapper;
using StoreP.Core;
using StoreP.Core.Dtos.Products;
using StoreP.Core.Entities;
using StoreP.Core.Helper;
using StoreP.Core.Services.Contract;
using StoreP.Core.Specifications;
using StoreP.Core.Specifications.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreP.Service.Services.Products
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,
                                IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginationResponse<ProductDto>> GetAllProductsAsync(ProductSpecParams productSpec)
        {
            var spec = new ProductSpecifications(productSpec);
         
            var mappedProducts = _mapper.Map<IEnumerable<ProductDto>>(await _unitOfWork.Repsitory<Product, int>().GetAllWithSpecAsync(spec));
            var countSpec = new ProductWithCountSpecifications(productSpec);
            var count = await _unitOfWork.Repsitory<Product, int>().GetCountAsync(countSpec);

            return new PaginationResponse<ProductDto>(productSpec.PageSize ,productSpec.PageIndex , count , mappedProducts);
        }

        public async Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync()
        {
           return _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitOfWork.Repsitory<ProductBrand, int>().GetAllAsync());
        }


        public async Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync()
        {
            return _mapper.Map<IEnumerable<TypeBrandDto>>(await _unitOfWork.Repsitory<ProductType, int>().GetAllAsync());
        }

        public async Task<ProductDto> GetProductById(int id)
        {
            var spec = new ProductSpecifications(id);
            var product = await _unitOfWork.Repsitory<Product, int>().GetWithSpecAsync(spec);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
