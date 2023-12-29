using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using App.InterViews.Report.Http;
using App.InterViews.Report.Models;
using App.InterViews.Report.Service.Dtos;
using App.InterViews.Report.Service.ServiceInterViewReport.Contracts;

namespace App.InterViews.Report.Controllers
{
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
        public  IResult GetInterviews()
        {
            return _iAutoMapperHttp.Ok(_iInterviewService.GetAll());
        }

        [HttpGet("GetByIdProcess/{idProcess}")]
        public IResult GetByIdProcess(int idProcess)
        {
            return _iAutoMapperHttp.Ok(_iInterviewService.GetAllByIdProcess(idProcess));
        }

        [HttpGet("GetInterviewById/{idInterview}")]
        public async Task<IResult> GetInterviewById(int idInterview)
        {
            var result = await _iInterviewService.GetById(idInterview);
            return _iAutoMapperHttp.Ok(result);
        }

        [HttpPost("AddInterview")]
        public async Task<IResult> AddInterview(InterviewModel interviewModel)
        {
            var interview = _mapper.Map<InterviewDto>(interviewModel);
            var result = await _iInterviewService.Add(interview);
            return _iAutoMapperHttp.Ok(result);
        }

        [HttpPut("UpdateInterview")]
        public async Task<IResult> UpdateInterview(InterviewModel interviewModel)
        {
            var interview = _mapper.Map<InterviewDto>(interviewModel);
            var result = await _iInterviewService.Update(interview);
            return _iAutoMapperHttp.Ok(result);
        }

        [HttpDelete("DeleteInterview/{idInterview}")]
        public async Task<IResult> DeleteInterview(int idInterview)
        {
            var result = await _iInterviewService.Delete(idInterview);
            return _iAutoMapperHttp.Ok(result);
        }
    }
}
