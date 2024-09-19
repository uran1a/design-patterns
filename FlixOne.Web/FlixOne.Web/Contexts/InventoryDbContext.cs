using FlixOne.Web.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FlixOne.Web.Contexts
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext(DbContextOptions<InventoryDbContext> options):
            base(options)
        { }

        public InventoryDbContext() { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
