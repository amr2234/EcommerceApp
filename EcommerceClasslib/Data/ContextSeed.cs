using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using E_Core.Entities;
using EcommerceClasslib.DBContext;

namespace EcommerceClasslib.Data
{
    public class ContextSeed 
    {
        public static async Task SeedAsync(EContext context)
        {
            if (context.ProductBrands.Any())
            {
                var brandsData =
                    File.ReadAllText("../EcommerceClasslib/Data/SeedData/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                context.ProductBrands.AddRange(brands);
            }
  

               if (context.ProductTypes.Any()) 

               {
                   var typesData =
                       File.ReadAllText("../EcommerceClasslib/Data/SeedData/types.json");
                   var types = JsonSerializer.Deserialize<List<ProductType>>(typesData);
                   context.ProductTypes.AddRange(types);
               }
            if (context.Products.Any())
            {
                var productsData =
                    File.ReadAllText("../EcommerceClasslib/Data/SeedData/products.json");
                var products = JsonSerializer.Deserialize<List<Product>>(productsData);
                context.Products.AddRange(products);
            }

           // if (context.ChangeTracker.HasChanges()) await context.SaveChangesAsync();
        }
    }
}
