using Collision.Platform.Domain;
using Microsoft.EntityFrameworkCore;

namespace Collision.Platform.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(
                u =>
                {
                    u.Property("Id");
                    u.HasKey("Id");
                });
        }
    }
}
