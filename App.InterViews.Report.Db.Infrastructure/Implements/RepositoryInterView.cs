using Microsoft.EntityFrameworkCore;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;

namespace App.InterViews.Report.Db.Infrastructure.Implements
{
    public class RepositoryInterView : RepositoryBase<InterView>, IRepositoryInterView
    {
        public DbDataContext _context;
        public RepositoryInterView(DbDataContext context) : base(context)
        {
            _context = context;
        }

        public List<InterView> GetAll() 
        { 
            return _context.InterViews.Include(c => c.InformationInterViews).ToList();
        }
    }
}
