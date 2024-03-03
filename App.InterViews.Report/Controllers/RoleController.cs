using App.InterViews.Report.Http;
using App.InterViews.Report.Models;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace App.InterViews.Report.Controllers;

[Route("api/[controller]")]
[ApiController]
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

    [HttpGet("All")]
    [ProducesResponseType(typeof(IEnumerable<RoleDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _iRoleReportService.GetAllAsync();
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(RoleDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> AddAsync([FromBody] RoleModel roleModel)
    {
        var role = _mapper.Map<RoleDto>(roleModel);
        var result = await _iRoleReportService.AddAsync(role);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpDelete("{roleId}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid roleId)
    {
        var result = await _iRoleReportService.DeleteAsync(roleId);
        return _iAutoMapperHttp.NoContent(result);
    }
}
