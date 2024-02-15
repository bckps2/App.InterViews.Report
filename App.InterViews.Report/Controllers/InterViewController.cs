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
public class InterviewController
{
    private readonly IMapper _mapper;
    private readonly IAutoMapperHttp _iAutoMapperHttp;
    private readonly IInterViewReportService _iInterviewService;

    public InterviewController(IInterViewReportService iInterviewService, IAutoMapperHttp iAutoMapperHttp, IMapper mapper)
    {
        _mapper = mapper;
        _iAutoMapperHttp = iAutoMapperHttp;
        _iInterviewService = iInterviewService;
    }

    [HttpGet("GetInterviews")]
    [ProducesResponseType(typeof(IEnumerable<InterviewDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetInterviews()
    {
        var result = await _iInterviewService.GetAll();
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("GetByIdProcess/{idProcess}")]
    [ProducesResponseType(typeof(IEnumerable<InterviewDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByIdProcess(Guid idProcess)
    {
        var result = await _iInterviewService.GetAllByIdProcess(idProcess);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("GetInterviewById/{idInterview}")]
    [ProducesResponseType(typeof(InterviewDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetInterviewById(Guid idInterview)
    {
        var result = await _iInterviewService.GetById(idInterview);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpPost("AddInterview")]
    [ProducesResponseType(typeof(InterviewDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> AddInterview(InterviewModel interviewModel)
    {
        var interview = _mapper.Map<InterviewDto>(interviewModel);
        var result = await _iInterviewService.Add(interview);
        return _iAutoMapperHttp.Created(result);
    }

    [HttpPut("UpdateInterview")]
    [ProducesResponseType(typeof(InterviewDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateInterview(InterviewModel interviewModel)
    {
        var interview = _mapper.Map<InterviewDto>(interviewModel);
        var result = await _iInterviewService.Update(interview);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpDelete("DeleteInterview/{idInterview}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteInterview(Guid idInterview)
    {
        var result = await _iInterviewService.Delete(idInterview);
        return _iAutoMapperHttp.NoContent(result);
    }
}
