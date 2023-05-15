using APIproject.Configuration;
using APIproject.Entity;
using Microsoft.EntityFrameworkCore;

namespace APIproject
{
    public class ProductManagmentContext:DbContext
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Package> packages { get; set; }
        public DbSet<PackageProduct> PackageProduct { get; set; }


        public ProductManagmentContext()
        {
            
        }

        public ProductManagmentContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new PackageConfiguration());
            modelBuilder.ApplyConfiguration(new PackPrduConfiguration());
        }


    }
}
