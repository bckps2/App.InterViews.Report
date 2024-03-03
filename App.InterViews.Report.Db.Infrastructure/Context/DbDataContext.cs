using App.InterViews.Report.Library.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace App.InterViews.Report.Db.Infrastructure.Context;

public class DbDataContext : DbContext
{
    public DbDataContext(DbContextOptions<DbDataContext> options) : base(options)
    {
        Database.Migrate();
    }

    public DbSet<Interview>? InterViews { get; set; }
    public DbSet<Process>? Process { get; set; }
    public DbSet<Company>? Companies { get; set; }
    public DbSet<UserCompany>? UserCompanies { get; set; }
    public DbSet<UserAccount>? UsersAccount { get; set; }
    public DbSet<UserInfo>? UsersInfo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
