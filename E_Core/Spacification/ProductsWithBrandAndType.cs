using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Core.Entities;

namespace E_Core.Spacification
{
    public class ProductsWithBrandAndType : BaseSpacification<Product>
    {
        public ProductsWithBrandAndType(ProductSpecParms pram)
        : base(x=>
            (string.IsNullOrEmpty(pram.Search) || x.Name.ToLower().Contains(pram.Search)
            )&&
            (!pram.BrandId.HasValue || x.ProductBrandId == pram.BrandId) &&
                  (!pram.TypeId.HasValue||x.ProductTypeId == pram.TypeId)
        )
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);
                //AddOrderByDes(x=>x.Price);
            AddOrderBy(x=>x.Name);
            ApplyPaging(pram.PageSize*(pram.PageIndex-1),pram.PageSize);

            if (!string.IsNullOrEmpty(pram.Sort))
            {
                switch (pram.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.Price);
                        break;
                    case "priceDesc":
                        AddOrderByDes(p => p.Price);
                        break;
                    default:
                        AddOrderBy(a => a.Name);
                        break;
                }
            }

        }
        public ProductsWithBrandAndType(int id)
        :base(x=>x.id==id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);

        }
    }
}
