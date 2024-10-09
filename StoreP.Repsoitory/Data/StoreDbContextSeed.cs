using StoreP.Core.Entities;
using StoreP.Repository.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StoreP.Repository.Data
{
    public static class StoreDbContextSeed
    {
        public async static Task SeedAsync(StoreDbContext _context)
        {
            if (_context.Brands.Count() == 0 )
            {
                // Brand 
                // 1. Read DAta from json File
                // C:\Users\fagr\source\repos\StoreP\StoreP.Repsoitory\Data\DataSeed\brands.json

                var brandsData = await File.ReadAllTextAsync(@"..\StoreP.Repsoitory\Data\DataSeed\brands.json");

                // 2. Convert Json string to List<T>

                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);

                // 3. Seed Data To DB
                if (brands is not null && brands.Count() > 0)
                {
                    await _context.Brands.AddRangeAsync(brands);
                    await _context.SaveChangesAsync();
                }
            }
            if (_context.Types.Count() == 0)
            {
                // Brand 
                // 1. Read DAta from json File
                // C:\Users\fagr\source\repos\StoreP\StoreP.Repsoitory\Data\DataSeed\brands.json

                var typesData = await File.ReadAllTextAsync(@"..\StoreP.Repsoitory\Data\DataSeed\types.json");

                // 2. Convert Json string to List<T>

                var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);

                // 3. Seed Data To DB
                if (types is not null && types.Count() > 0)
                {
                    await _context.Types.AddRangeAsync(types);
                    await _context.SaveChangesAsync();
                }
            }
            if (_context.Products.Count() == 0)
            {
                // Brand 
                // 1. Read DAta from json File
                // C:\Users\fagr\source\repos\StoreP\StoreP.Repsoitory\Data\DataSeed\brands.json

                var productsData = await File.ReadAllTextAsync(@"..\StoreP.Repsoitory\Data\DataSeed\products.json");

                // 2. Convert Json string to List<T>

                var products = JsonSerializer.Deserialize<List<Product>>(productsData);

                // 3. Seed Data To DB
                if (products is not null && products.Count() > 0)
                {
                    await _context.Products.AddRangeAsync(products);
                    await _context.SaveChangesAsync();
                }
            }

        }
    }
}
