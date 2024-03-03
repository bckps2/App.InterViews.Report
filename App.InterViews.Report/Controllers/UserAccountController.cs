using App.InterViews.Report.Http;
using App.InterViews.Report.Models;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.InterViews.Report.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserAccountController
{
    private readonly IMapper _mapper;
    private readonly IAutoMapperHttp _iAutoMapperHttp;
    private readonly IUserAccountService _userAccountService;

    public UserAccountController(IAutoMapperHttp iAutoMapperHttp, IMapper mapper, IUserAccountService userAccountService)
    {
        _mapper = mapper;
        _iAutoMapperHttp = iAutoMapperHttp;
        _userAccountService = userAccountService;
    }

    [HttpGet("All")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _userAccountService.GetAllAsync();
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("{userAccountId}")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] Guid userAccountId)
    {
        var result = await _userAccountService.GetByIdAsync(userAccountId);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync([FromBody] UserAccountModel userAccountModel)
    {
        var userAccount = _mapper.Map<UserAccountDto>(userAccountModel);
        var result = await _userAccountService.AddAsync(userAccount);

        return _iAutoMapperHttp.Created(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync([FromBody] UserAccountModel userAccountModel)
    {
        var userAccount = _mapper.Map<UserAccountDto>(userAccountModel);
        var result = await _userAccountService.UpdateAsync(userAccount);

        return _iAutoMapperHttp.Ok(result);
    }
    
    [HttpDelete("{userAccountId}")]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid userAccountId)
    {
        var result = await _userAccountService.DeleteAsync(userAccountId);
        return _iAutoMapperHttp.Ok(result);
    }
}
