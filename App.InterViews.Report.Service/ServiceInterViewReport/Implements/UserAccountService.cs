using App.InterViews.Report.CrossCutting.Helper;
using App.InterViews.Report.Db.Infrastructure.Contracts;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using CSharpFunctionalExtensions;
using Sodium;

namespace App.InterViews.Report.Service.ServiceInterViewReport.Implements;

public class UserAccountService : BaseReportService<UserAccount, UserAccountDto>, IUserAccountService
{
    public UserAccountService(IRepositoryBase<UserAccount> iRepositoryBase, IMapper mapper) : base(iRepositoryBase, mapper)
    {
    }

    public override async Task<Result<UserAccountDto, ErrorResult>> AddAsync(UserAccountDto userAccountDto) 
    {
        var encryptedPassword = PasswordHash.ArgonHashString(userAccountDto.Password);
        userAccountDto.Password = encryptedPassword;

        return await base.AddAsync(userAccountDto);
    }
}
