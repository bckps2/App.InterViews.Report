using App.InterViews.Report.Http;
using App.InterViews.Report.Models.Interview;
using App.InterViews.Report.Service.Dtos.Interview;
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

    [HttpGet("All")]
    [ProducesResponseType(typeof(IEnumerable<InterviewInterviewerDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await _iInterviewService.GetAllAsync();
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("processId/{processId}")]
    [ProducesResponseType(typeof(IEnumerable<InterviewInterviewerDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllByProcessIdAsync(Guid processId)
    {
        var result = await _iInterviewService.GetAllByProcessIdAsync(processId);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpGet("{interviewId}")]
    [ProducesResponseType(typeof(InterviewDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetByIdAsync(Guid interviewId)
    {
        var result = await _iInterviewService.GetByIdAsync(interviewId);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpPost()]
    [ProducesResponseType(typeof(InterviewDto), (int)HttpStatusCode.Created)]
    public async Task<IActionResult> AddAsync([FromBody] InterviewModel interviewModel)
    {
        var interview = _mapper.Map<InterviewDto>(interviewModel);
        var result = await _iInterviewService.AddAsync(interview);
        return _iAutoMapperHttp.Created(result);
    }

    [HttpPut()]
    [ProducesResponseType(typeof(InterviewDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> UpdateAsync([FromBody] InterviewUpdateModel interviewModel)
    {
        var interview = _mapper.Map<InterviewDto>(interviewModel);
        var result = await _iInterviewService.UpdateAsync(interview);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpDelete("{interviewId}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    public async Task<IActionResult> DeleteAsync(Guid interviewId)
    {
        var result = await _iInterviewService.DeleteAsync(interviewId);
        return _iAutoMapperHttp.NoContent(result);
    }
}
