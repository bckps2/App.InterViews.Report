using App.InterViews.Report.Http;
using App.InterViews.Report.Models;
using App.InterViews.Report.Service.Dtos.User;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.InterViews.Report.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController
{
    private readonly IMapper _mapper;
    private readonly IAutoMapperHttp _iAutoMapperHttp;
    private readonly IUserReportService _iuserReportService;

    public UserController(IUserReportService iuserReportService, IAutoMapperHttp iAutoMapperHttp, IMapper mapper)
    {
        _mapper = mapper;
        _iAutoMapperHttp = iAutoMapperHttp;
        _iuserReportService = iuserReportService;
    }

    [HttpGet("{userId}")]
    [ProducesResponseType(typeof(UserCompanyDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetUserById([FromQuery] Guid userId)
    {
        var result = await _iuserReportService.GetByIdAsync(userId);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("CompanyId/{companyId}")]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllByCompanyIdAsync([FromQuery] Guid companyId)
    {
        var result = await _iuserReportService.GetAllByCompanyIdAsync(companyId);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("All")]
    [ProducesResponseType(typeof(IEnumerable<UserCompanyDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _iuserReportService.GetAllAsync();
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> AddAsync([FromBody] UserModel usermodel)
    {
        var user = _mapper.Map<UserDto>(usermodel);
        var result = await _iuserReportService.AddAsync(user);
        return _iAutoMapperHttp.Created(result);
    }

    [HttpPut()]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateAsync([FromBody] UpdateUserModel userModel)
    {
        var user = _mapper.Map<UserDto>(userModel);
        var result = await _iuserReportService.UpdateAsync(user);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpDelete("{userId}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid userId)
    {
        var result = await _iuserReportService.DeleteAsync(userId);
        return _iAutoMapperHttp.NoContent(result);
    }
}
