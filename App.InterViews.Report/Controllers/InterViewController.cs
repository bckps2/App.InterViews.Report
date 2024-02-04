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
public class InterviewController : Controller
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
    public IResult GetInterviews()
    {
        return _iAutoMapperHttp.Ok(_iInterviewService.GetAll());
    }

    [HttpGet("GetByIdProcess/{idProcess}")]
    [ProducesResponseType(typeof(IEnumerable<InterviewDto>), (int)HttpStatusCode.OK)]
    public IResult GetByIdProcess(Guid idProcess)
    {
        return _iAutoMapperHttp.Ok(_iInterviewService.GetAllByIdProcess(idProcess));
    }

    [HttpGet("GetInterviewById/{idInterview}")]
    [ProducesResponseType(typeof(InterviewDto), (int)HttpStatusCode.OK)]
    public async Task<IResult> GetInterviewById(int idInterview)
    {
        var result = await _iInterviewService.GetById(idInterview);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpPost("AddInterview")]
    [ProducesResponseType(typeof(InterviewDto), (int)HttpStatusCode.Created)]
    public async Task<IResult> AddInterview(InterviewModel interviewModel)
    {
        var interview = _mapper.Map<InterviewDto>(interviewModel);
        var result = await _iInterviewService.Add(interview);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpPut("UpdateInterview")]
    [ProducesResponseType(typeof(InterviewDto), (int)HttpStatusCode.OK)]
    public async Task<IResult> UpdateInterview(InterviewModel interviewModel)
    {
        var interview = _mapper.Map<InterviewDto>(interviewModel);
        var result = await _iInterviewService.Update(interview);
        return _iAutoMapperHttp.Ok(result);
    }

    [HttpDelete("DeleteInterview/{idInterview}")]
    [ProducesResponseType(typeof(InterviewDto), (int)HttpStatusCode.OK)]
    public async Task<IResult> DeleteInterview(int idInterview)
    {
        var result = await _iInterviewService.Delete(idInterview);
        return _iAutoMapperHttp.Ok(result);
    }
}
