
using AutoMapper;
using E_Core.Entities;
using E_Core.Interfaces;
using E_Core.Spacification;
using EcommerceApp.Data_Transfer_Object;
using EcommerceApp.Helpers;
using EcommerceClasslib.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Controllers
{

    public class ProductsController : BaseApiController
    {
        
        private readonly IGenaricRepositiory<Product> _ProductRepo;
        private readonly IGenaricRepositiory<ProductBrand> _ProductBrandRepo;
        private  readonly IGenaricRepositiory<ProductType> _ProductTypeRepo;
        private readonly IMapper _mapper;
        public ProductsController(IGenaricRepositiory<Product>ProductRepo, 
            IGenaricRepositiory<ProductBrand> ProductBrandRepo, 
            IGenaricRepositiory<ProductType> ProductTypeRepo,IMapper mapper)
        {
            _mapper = mapper;
            _ProductRepo = ProductRepo;
            _ProductBrandRepo = ProductBrandRepo;
            _ProductTypeRepo = ProductTypeRepo;



        }
        
        [HttpGet]
        public async Task<ActionResult<Pagination<ProductReturnDTO>>> GetProducts([FromQuery]ProductSpecParms par)
        {
            var spac = new ProductsWithBrandAndType(par);
            var countSpec = new ProductswithFiltersCountSpac(par);
            var totalItems = await _ProductRepo.CountDataAsync(countSpec);
        
            var products = await _ProductRepo.ListAsync(spac);
            var data =_mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductReturnDTO>>(products);

            return Ok(new Pagination<ProductReturnDTO>(par.PageIndex, par.PageSize, totalItems, data));


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReturnDTO>> GetProduct(int id)
        {
            var spec = new ProductsWithBrandAndType(id);
            var product = await _ProductRepo.GetEntitywithSpacification(spec);
            return _mapper.Map<Product, ProductReturnDTO>(product);


        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return  Ok(await _ProductBrandRepo.GetItemsAsync());
        }
        [HttpGet("brands/{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductBrandbyId(int id)
        {
            return Ok(await _ProductBrandRepo.GetItemByIdAsync(id));
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProducttypes()
        {
            return Ok(await _ProductTypeRepo.GetItemsAsync());
        }
        [HttpGet("types/{id}")]
        public async Task<ActionResult<ProductBrand>> GetProductTypebyId(int id)
        {
            return Ok(await _ProductTypeRepo.GetItemByIdAsync(id));
        }

    }
}
