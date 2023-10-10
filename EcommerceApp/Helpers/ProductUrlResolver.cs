using AutoMapper;
using AutoMapper.Execution;
using AutoMapper.Internal;
using System.Linq.Expressions;
using System.Reflection;
using E_Core.Entities;
using EcommerceApp.Data_Transfer_Object;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

namespace EcommerceApp.Helpers
{
    public class ProductUrlResolver : IValueResolver<Product, ProductReturnDTO, string>
    {
        private readonly IConfiguration _config;
        public ProductUrlResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(Product source, ProductReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                return _config["ApiUrl"] + source.PictureUrl;
            }

            return null;
        }
    }
}
