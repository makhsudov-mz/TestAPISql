using Microsoft.EntityFrameworkCore;

using TestAPISql.Modules.Users.Entity;
using TestAPISql.Modules.Users.EntityConfig;

namespace TestAPISql
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {}

        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration { });
        }

    }
}
