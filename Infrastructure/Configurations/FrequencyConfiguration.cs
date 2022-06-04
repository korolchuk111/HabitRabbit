using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class FrequencyConfiguration : IEntityTypeConfiguration<Frequency>
    {
        public void Configure(EntityTypeBuilder<Frequency> builder)
        {
            builder
                .Property(p => p.Type)
                .IsRequired();
            builder
                .HasMany(p => p.Challenges)
                .WithOne(p => p.Frequency)
                .HasForeignKey(p => p.FrequencyId);
        }
    }
}
