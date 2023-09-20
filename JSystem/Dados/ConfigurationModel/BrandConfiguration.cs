using JSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSystem.Dados.ConfigurationModel
{
    public class BrandConfiguration : IEntityTypeConfiguration<BrandModel>
    {
        public void Configure(EntityTypeBuilder<BrandModel> builder)
        {
            builder.HasOne(b => b.Product)
           .WithOne(p => p.Brand)
           .HasForeignKey<ProductModel>(p => p.BrandId);
        }
    }
}
