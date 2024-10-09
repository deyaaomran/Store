using StoreP.Core.Dtos.Brands;
using StoreP.Core.Dtos.Products;
using StoreP.Core.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreP.Core.Services.Contract
{
    public interface IProductService
    {
        Task <IEnumerable<ProductDto>> GetAllProductsAsync();

        Task<IEnumerable<TypeBrandDto>> GetAllTypesAsync();

        Task<IEnumerable<TypeBrandDto>> GetAllBrandsAsync();

        Task<ProductDto> GetProductById(int id);









    }
}
