using AutoMapper;
using E_Core.Entities;
using EcommerceApp.Data_Transfer_Object;

namespace EcommerceApp.Helpers
{
    public class AutoMapper:Profile
    {
        public AutoMapper()
        {
            CreateMap<Product, ProductReturnDTO>()
                .ForMember(x => x.ProductBrand,
                    a => a.MapFrom(s => s.ProductBrand.Name))
                .ForMember(x => x.ProductType,
                    a => a.MapFrom(s => s.ProductType.Name))
                .ForMember(x => x.PictureUrl,
                a => a.MapFrom<ProductUrlResolver>()).ReverseMap();
        }


        
    }
}
