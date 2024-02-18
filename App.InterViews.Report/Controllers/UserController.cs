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

    [HttpGet("GetUserById/{userId}")]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        var result = await _iuserReportService.GetById(userId);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("GetAllUsersByCompany/{companyId}")]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllUsersByCompanyId(Guid companyId)
    {
        var result = await _iuserReportService.GetAllUsersByCompanyId(companyId);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("GetAllUsers")]
    [ProducesResponseType(typeof(IEnumerable<UserDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllUsers()
    {
        var result = await _iuserReportService.GetAll();
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpPost("AddUser")]
    [ProducesResponseType(typeof(UserDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> AddUser(UserModel usermodel)
    {
        var user = _mapper.Map<UserDto>(usermodel);
        var result = await _iuserReportService.Add(user);
        return _iAutoMapperHttp.Created(result);
    }

    [HttpPut("UpudateUser")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateUser(UpdateUserModel userModel)
    {
        var user = _mapper.Map<UserDto>(userModel);
        var result = await _iuserReportService.Update(user);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpDelete("DeleteUser/{userId}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        var result = await _iuserReportService.Delete(userId);
        return _iAutoMapperHttp.Ok(result);
    }
}
