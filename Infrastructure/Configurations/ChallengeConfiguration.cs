using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class ChallengeConfiguration : IEntityTypeConfiguration<Challenge>
    {
        public void Configure(EntityTypeBuilder<Challenge> builder)
        {
            builder
                .HasOne(p => p.Author)
                .WithMany(p => p.AuthoredChallenges)
                .HasForeignKey(p => p.AuthorId);
            builder
                .Property(p => p.Title)
                .IsRequired();
            builder
                .Property(p => p.CountOfUnits)
                .IsRequired();
            builder
                .HasOne(p => p.Unit)
                .WithMany(p => p.Challenges)
                .HasForeignKey(p => p.UnitId);
            builder
                .HasOne(p => p.Frequency)
                .WithMany(p => p.Challenges)
                .HasForeignKey(p => p.FrequencyId);
            builder
                .Property(p => p.IsCompleted)
                .HasDefaultValue(false);
            builder
                .Property(p => p.IsRegistrationOpened)
                .HasDefaultValue(true);
            builder
                .HasMany(p => p.DailyTasks)
                .WithOne(p => p.Challenge)
                .HasForeignKey(p => p.ChallengeId);
            builder
                .HasMany(p => p.Users)
                .WithMany(p => p.Challenges);
        }
    }
}
