using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Models;

namespace OnlineShop.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<productCategory>? productCategories { get; set; } 
        public DbSet<product>? products { get; set; }
        public DbSet<order>? orders { get; set; }
        public DbSet<orderDetail>? orderDetails { get; set; }
        public DbSet<user>? users { get; set; }
    }
}