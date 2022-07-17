using Microsoft.EntityFrameworkCore;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Db.Infrastructure.Context;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;

namespace App.InterViews.Report.Db.Infrastructure.Implements
{
    public class RepositoryCompany : RepositoryBase<Company>, IRepositoryCompany
    {
        public DbDataContext _context;
        public RepositoryCompany(DbDataContext context) : base(context)
        {
            _context = context;
        }

        public override IEnumerable<Company> GetAll() 
        { 
            return _context.Companies
                .Include(company => company.InterViews)
                .ThenInclude(interview => interview.InformationInterViews).AsEnumerable();
        }
    }
}
