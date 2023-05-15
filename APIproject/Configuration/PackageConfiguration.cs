using System.Reflection.Emit;
using APIproject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIproject.Configuration
{
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure(EntityTypeBuilder<Package> builder)
        {
          builder.HasMany(e => e.PackageProduct);
        }
    }
}
