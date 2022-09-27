using Microsoft.EntityFrameworkCore;
using App.InterViews.Report.Library.Entities;

namespace App.InterViews.Report.Db.Infrastructure.Context
{
    public class DbDataContext : DbContext
    {

        public DbDataContext(DbContextOptions<DbDataContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<InterView>? InterViews {get;set;}
        public DbSet<Process>? Process {get;set;}
        public DbSet<Company>? Companies {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .HasIndex(c => new { c.CompanyName})
                .IsUnique();

            modelBuilder.Entity<Process>()
                .HasMany(p => p.Interviews)
                .WithOne(i => i.Process);
        }
    }
}
