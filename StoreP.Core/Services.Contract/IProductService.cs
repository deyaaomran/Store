using StoreP.Core.Dtos.Brands;
using StoreP.Core.Dtos.Products;
using StoreP.Core.Dtos.Types;
using StoreP.Core.Helper;
using StoreP.Core.Specifications.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreP.Core.Services.Contract
{
    public interface IProductService
    {
        Task <PaginationResponse<ProductDto>> GetAllProductsAsync(ProductSpecParams productSpec);

        Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync();

        Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync();

        Task<ProductDto> GetProductById(int id);









    }
}
