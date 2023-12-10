
using System.Reflection;
using E_Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceClasslib.DBContext
{
    public class EContext :DbContext
    {
        public EContext() : base()
        {
            
        }
        public EContext(DbContextOptions<EContext> options)
            : base(options)
        {
        }

       
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
