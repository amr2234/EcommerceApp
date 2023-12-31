﻿


using System.Diagnostics.CodeAnalysis;

namespace E_Core.Entities
{
    public class Product:BaseClass
    {
        public string Name { get; set; }
        public string Description { get; set; }
      
        public decimal Price { get; set; }
        [AllowNull]
        public string PictureUrl { get; set; }
        public ProductType ProductType { get; set;}
        public  int ProductTypeId { get; set; }

        public ProductBrand ProductBrand { get; set; }
        public int ProductBrandId { get; set;}
      
            

    }
}
