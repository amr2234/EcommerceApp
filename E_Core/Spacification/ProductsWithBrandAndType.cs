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
        public ProductsWithBrandAndType()
        {
            AddInclude(x=>x.ProductType);
            AddInclude(x=>x.ProductBrand);

        }
        public ProductsWithBrandAndType(int id)
        :base(x=>x.id==id)
        {
            AddInclude(x => x.ProductType);
            AddInclude(x => x.ProductBrand);

        }
    }
}
