using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Core.Entities;

namespace E_Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductbyIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
        Task<ProductBrand> GetProductBrandbyIdAsync(int id);
        Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync();
        Task<ProductType> GetProductTypebyIdAsync(int id);
        Task<IReadOnlyList<ProductType>> GetProductTypessAsync();

    }
}
