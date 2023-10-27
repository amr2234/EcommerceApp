using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Core.Entities;

namespace E_Core.Spacification
{
    public class ProductswithFiltersCountSpac : BaseSpacification<Product>
    {
        public ProductswithFiltersCountSpac(ProductSpecParms pram)
            : base(x =>
                (string.IsNullOrEmpty(pram.Search) || x.Name.ToLower().Contains(pram.Search)
                ) &&
                (!pram.BrandId.HasValue || x.ProductBrandId == pram.BrandId) &&
                (!pram.TypeId.HasValue || x.ProductTypeId == pram.TypeId)
            )
        {



        }
    }
}
