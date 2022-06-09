using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using App.InterViews.Report.Library.Entities;

namespace App.InterViews.Report.Db.Infrastructure.Context
{
    public class DbDataContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbDataContext(IConfiguration configuration, DbContextOptions<DbDataContext> options) : base(options)
        {
            Configuration = configuration;
            Database.EnsureCreated();
        }

        public DbSet<InterView> InterViews {get;set;}
        public DbSet<InformationInterView> InformationInterViews {get;set;}
    }
}
