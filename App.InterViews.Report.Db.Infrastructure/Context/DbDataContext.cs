using App.InterViews.Report.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.InterViews.Report.Db.Infrastructure.Context
{
    public class DbDataContext : DbContext
    {
        public DbDataContext(DbContextOptions<DbDataContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<InterView>? InterViews { get; set; }
        public DbSet<Process>? Process { get; set; }
        public DbSet<Company>? Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .Navigation(e => e.Process)
                .AutoInclude();

            modelBuilder.Entity<Company>()
                .HasMany(c => c.Process)
                .WithOne(c => c.Company);

            modelBuilder.Entity<Company>()
              .HasIndex(c => new { c.CompanyName })
              .IsUnique();

            modelBuilder.Entity<Process>()
                .HasMany(p => p.Interviews)
                .WithOne(i => i.Process);

            modelBuilder.Entity<Process>()
               .Navigation(e => e.Interviews)
               .AutoInclude();

            modelBuilder.Entity<InterView>()
                .HasOne(c => c.Process);
        }
    }
}
