using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceClasslib.Data.Config
{
    //public class ProductConfig : IEntityTypeConfiguration<Product>
    //{
    //    public void Configure(EntityTypeBuilder<Product> builder)
    //    {
    //        builder.Property(e=>e.Name).IsRequired().HasMaxLength(100);
    //       // builder.Property(e=>e.Description).IsRequired().HasMaxLength(100);
    //        builder.Property(e => e.Price).IsRequired().HasColumnType("decimal(18,2)");
    //        builder.Property(e => e.PictureUrl).IsRequired();
    //        builder.HasOne(b => b.ProductBrand).WithMany().HasForeignKey(e => e.ProductBrandId);
    //    }
    //}
}
