using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configurations
{
    public class DailyTaskConfiguration : IEntityTypeConfiguration<DailyTask>
    {
        public void Configure(EntityTypeBuilder<DailyTask> builder)
        {
            builder
                .HasOne(p => p.Challenge)
                .WithMany(p => p.DailyTasks)
                .HasForeignKey(p => p.ChallengeId);
            builder
                .Property(p => p.Date)
                .IsRequired();
            builder
                .Property(p => p.IsDone)
                .HasDefaultValue(false);
        }
    }
}
