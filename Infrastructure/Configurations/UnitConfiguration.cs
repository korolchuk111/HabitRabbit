using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UnitConfiguration : IEntityTypeConfiguration<Unit>
    {
        public void Configure(EntityTypeBuilder<Unit> builder)
        {
            builder.Property(p => p.Type)
                .IsRequired();
            builder
                .HasMany(p => p.Challenges)
                .WithOne(p => p.Unit)
                .HasForeignKey(p => p.UnitId);
        }
    }
}
