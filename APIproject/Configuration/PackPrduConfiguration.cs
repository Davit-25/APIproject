using APIproject.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APIproject.Configuration
{
    public class PackPrduConfiguration : IEntityTypeConfiguration<PackageProduct>
    {
        public void Configure(EntityTypeBuilder<PackageProduct> builder)
        {
            builder.HasOne(e => e.Package). WithMany(p=>p.PackageProduct).HasForeignKey(e => e.PackageId);

                ;

        }
    }
}
