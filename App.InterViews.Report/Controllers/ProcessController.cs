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
public class ProcessController
{
    private readonly IMapper _mapper;
    private readonly IAutoMapperHttp _iAutoMapperHttp;
    private readonly IProcessReportService _iProcessService;

    public ProcessController(IProcessReportService iProcessService, IMapper mapper, IAutoMapperHttp iAutoMapperHttp)
    {
        _mapper = mapper;
        _iProcessService = iProcessService;
        _iAutoMapperHttp = iAutoMapperHttp;
    }

    [HttpGet("All")]
    [ProducesResponseType(typeof(ProcessDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByIdAsync(Guid processId)
    {
        var result = await _iProcessService.GetByIdAsync(processId);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("All")]
    [ProducesResponseType(typeof(IEnumerable<ProcessDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _iProcessService.GetAllAsync();
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("companyId/{companyId}")]
    [ProducesResponseType(typeof(IEnumerable<ProcessDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllByCompanyIdAsync(Guid companyId)
    {
        var result = await _iProcessService.GetAllByCompanyIdAsync(companyId);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(ProcessDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> AddAsync(ProcessModel processModel)
    {
        var process = _mapper.Map<ProcessDto>(processModel);
        var result = await _iProcessService.AddAsync(process);
        return _iAutoMapperHttp.Created(result);
    }

    [HttpDelete("{processId}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteAsync(Guid processId)
    {
        var result = await _iProcessService.DeleteAsync(processId);
        return _iAutoMapperHttp.NoContent(result);
    }
}
