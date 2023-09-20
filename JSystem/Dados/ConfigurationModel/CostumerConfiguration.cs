using JSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace JSystem.Dados.ConfigurationModel
{
    public class CostumerConfiguration : IEntityTypeConfiguration<CostumerModel>
    {
        public void Configure(EntityTypeBuilder<CostumerModel> builder)
        {
            builder
                .Property(x => x.Id)
                .IsRequired();
            builder
                .Property(x => x.Name)
                .HasColumnType("VARCHAR(50)");
            builder
                .Property(x => x.Email)
                .HasColumnType("VARCHAR(50)");
            builder
                .Property(x => x.Password)
                .HasColumnType("VARCHAR(60)");
        }
    }
}
