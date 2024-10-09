using AutoMapper;
using StoreP.Core;
using StoreP.Core.Dtos.Products;
using StoreP.Core.Entities;
using StoreP.Core.Services.Contract;
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

        public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
         =>  _mapper.Map<IEnumerable<ProductDto>>(await _unitOfWork.Repsitory<Product, int>().GetAllAsync());

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
            var product = await _unitOfWork.Repsitory<Product, int>().GetAsync(id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
