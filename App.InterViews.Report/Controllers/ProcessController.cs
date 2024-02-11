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

    [HttpGet("GetAllProcess")]
    [ProducesResponseType(typeof(IEnumerable<ProcessDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllProcess()
    {
        var result = await _iProcessService.GetAll();
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("GetProcessesByIdCompany/{idCompany}")]
    [ProducesResponseType(typeof(IEnumerable<ProcessDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetProcessesByIdCompany(Guid idCompany)
    {
        var result = await _iProcessService.GetProcessesByIdCompany(idCompany);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpPost("AddProcess")]
    [ProducesResponseType(typeof(ProcessDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> AddProcess(ProcessModel processModel)
    {
        var process = _mapper.Map<ProcessDto>(processModel);
        var result = await _iProcessService.Add(process);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpDelete("DeleteProcess/{idProcess}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    public async Task<IActionResult> DeleteProcess(Guid idProcess)
    {
        var result = await _iProcessService.Delete(idProcess);
        return _iAutoMapperHttp.Ok(result);
    }
}
