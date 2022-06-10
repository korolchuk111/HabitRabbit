using System.Reflection;
using Core.Entities;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options) {}
        public DbSet<Challenge> Challenges { get; set; }
        public DbSet<DailyTask> DailyTasks { get; set; }
        public DbSet<Frequency> Frequencies { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Unit> Units { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(UserConfiguration)));
            builder.Seed();
            base.OnModelCreating(builder);
        }
    }
}
