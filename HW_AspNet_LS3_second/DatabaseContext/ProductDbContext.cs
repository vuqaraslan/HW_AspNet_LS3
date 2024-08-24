using HW_AspNet_LS3_second.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HW_AspNet_LS3_second.DatabaseContext
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
    }
}
