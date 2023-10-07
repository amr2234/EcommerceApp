
using E_Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EcommerceClasslib.DBContext
{
    public class EContext :DbContext
    {
       
        public EContext(DbContextOptions<EContext> options)
            : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
    }
}
