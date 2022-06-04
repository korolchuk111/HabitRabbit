using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Points)
                .HasDefaultValue(0);
            builder
                .HasOne(p => p.Status)
                .WithMany(p => p.Users)
                .HasForeignKey(p => p.StatusId);
            builder
                .HasMany(p => p.AuthoredChallenges)
                .WithOne(p => p.Author)
                .HasForeignKey(p => p.AuthorId);
            builder
                .HasMany(p => p.Challenges)
                .WithMany(p => p.Users);
        }
    }
}
