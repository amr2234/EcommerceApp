using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Core.Entities;
using E_Core.Interfaces;
using EcommerceClasslib.DBContext;
using Microsoft.EntityFrameworkCore;

namespace EcommerceClasslib.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly EContext _context;

        public ProductRepository(EContext context)
        {
            _context = context;
        }

        public async Task<ProductBrand> GetProductBrandbyIdAsync(int id)
        {
            return await _context.ProductBrands.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProductBrand>> GetProductBrandsAsync()
        {
            return await _context.ProductBrands.ToListAsync();
        }

        public async Task<Product> GetProductbyIdAsync(int id)
        {
            return _context.Products
                .Include(e => e.ProductType)
                .Include(e => e.ProductBrand)
                .FirstOrDefault(e=>e.id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await _context.Products
                .Include(e => e.ProductType)
                .Include(e => e.ProductBrand)
                .ToListAsync();
        }

        public async Task<ProductType> GetProductTypebyIdAsync(int id)
        {
            return await _context.ProductTypes.FindAsync(id);
        }

        public async Task<IReadOnlyList<ProductType>> GetProductTypessAsync()
        {
            return await _context.ProductTypes.ToListAsync();
        }
    }
}
