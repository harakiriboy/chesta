using Chesta.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Chesta.Infrastructure.Persistence
{
    public class ChestaDbContext : DbContext
    {
        public ChestaDbContext(DbContextOptions<ChestaDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Subscription>()
                .HasOne(x => x.User)
                .WithMany(x => x.Subscriptions)
                .OnDelete(DeleteBehavior.Restrict);
            
            modelBuilder.Entity<Publication>()
                .HasOne(x => x.Author)
                .WithMany(x => x.Publications)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(x => x.Subscription)
                .WithMany(x => x.Payments)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(x => x.User)
                .WithMany(x => x.Payments)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Comment>()
                .HasOne(x => x.User)
                .WithMany(x => x.Comments)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Subscription> Subscriptions { get; set; } = null!;
        public DbSet<Payment> Payments { get; set; } = null!;
        public DbSet<Address> Address { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;
        public DbSet<Publication> Publications { get; set; } = null!;
        public DbSet<AuthorPlan> AuthorPlans { get; set; } = null!;
    }
}