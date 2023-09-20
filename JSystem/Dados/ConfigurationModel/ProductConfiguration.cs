using JSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSystem.Dados.ConfigurationModel
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder
                .Property(e => e.Id)
                .IsRequired();
            builder
                .Property(e => e.Quantity)
                .HasColumnType("INT");
            builder
                .Property(e => e.Description)
                .HasColumnType("VARCHAR(30)");
            builder
                .Property(e => e.UnitPrice)
                .HasColumnType("FLOAT");
        }
    }
}
