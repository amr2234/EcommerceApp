
using E_Core.Entities;
using E_Core.Interfaces;
using EcommerceClasslib.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;
        public ProductsController(IProductRepository repo)
        {
           _repo = repo;
        }
        
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _repo.GetProductsAsync();
            return Ok(products);


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {

            return await _repo.GetProductbyIdAsync(id);


        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return  Ok(await _repo.GetProductBrandsAsync());
        }
        [HttpGet("brands/{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductBrandbyId(int id)
        {
            return Ok(await _repo.GetProductBrandbyIdAsync(id));
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProducttypes()
        {
            return Ok(await _repo.GetProductTypessAsync());
        }
        [HttpGet("types/{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductTypebyId(int id)
        {
            return Ok(await _repo.GetProductTypebyIdAsync(id));
        }

    }
}
