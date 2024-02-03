﻿using App.InterViews.Report.CrossCutting.Helper;
using CSharpFunctionalExtensions;
using System.Linq.Expressions;

namespace App.InterViews.Report.Db.Infrastructure.Contracts;

public interface IRepositoryBase<TEntry>
{
    Task<Result<TEntry, ErrorResult>> AddAsync(TEntry item);
    Task<Result<TEntry, ErrorResult>> GetByIdAsync(int id);
    Result<IEnumerable<TEntry>, ErrorResult> GetAll();
    Result<TEntry, ErrorResult> Update(TEntry item);
    Result<TEntry, ErrorResult> Delete(TEntry item);
    Result<IEnumerable<TEntry>, ErrorResult> GetEntitiesByFilter(Expression<Func<TEntry, bool>> expression);
}