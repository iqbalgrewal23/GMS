using Microsoft.EntityFrameworkCore;

namespace Gym.Models
{
    public class GymContext : DbContext
    {
        public GymContext(DbContextOptions<GymContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<GymClass> GymClasses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Optional: Fluent API examples
            modelBuilder.Entity<Member>().ToTable("Members");
            modelBuilder.Entity<Trainer>().ToTable("Trainers");
            modelBuilder.Entity<GymClass>().ToTable("GymClasses");
        }
    }
}
