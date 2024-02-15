﻿using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Library.Entities;
using CSharpFunctionalExtensions;

namespace App.InterViews.Report.Db.Infrastructure.Contracts;

public interface IUserRepository : IRepositoryBase<User>
{
    Task<Result<IEnumerable<User>, ErrorResult>> GetAllUserByCompanyByIdAsync(Guid companyId);
}