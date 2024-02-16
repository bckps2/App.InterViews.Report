using App.InterViews.Report.Http;
using App.InterViews.Report.Models;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.InterViews.Report.Controllers;

public class RoleController
{
    private readonly IMapper _mapper;
    private readonly IAutoMapperHttp _iAutoMapperHttp;
    private readonly IRoleReportService _iRoleReportService;

    public RoleController(IAutoMapperHttp iAutoMapperHttp, IRoleReportService iRoleReportService, IMapper mapper)
    {
        _mapper = mapper;
        _iAutoMapperHttp = iAutoMapperHttp;
        _iRoleReportService = iRoleReportService;
    }

    [HttpGet("GetRoles")]
    [ProducesResponseType(typeof(IEnumerable<RoleDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetRoles()
    {
        var result = await _iRoleReportService.GetAll();
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpPost("AddRole")]
    [ProducesResponseType(typeof(RoleDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddRole(RoleModel roleModel)
    {
        var role = _mapper.Map<RoleDto>(roleModel);
        var result = await _iRoleReportService.Add(role);
        return _iAutoMapperHttp.Ok(result);
    }
}
