using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using App.InterViews.Report.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using FluentValidation.Results;
using App.InterViews.Report.Contract.Service.Dtos;
using App.InterViews.Report.Library.Entities;
using App.InterViews.Report.Http;

namespace App.InterViews.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAutoMapperHttp _iAutoMapperHttp;
        private readonly IInterViewReportService<InterView, ValidationResult> _iInterviewService;

        public InterviewController(IInterViewReportService<InterView, ValidationResult> iInterviewService, IAutoMapperHttp iAutoMapperHttp, IMapper mapper)
        {
            _mapper = mapper;
            _iAutoMapperHttp = iAutoMapperHttp;
            _iInterviewService = iInterviewService;
        }

        [HttpGet("GetInterviews")]
        public  IResult GetInterviews()
        {
            return _iAutoMapperHttp.Ok(_iInterviewService.GetAllInterViews());
        }

        //[HttpGet("GetByIdProcess/{idProcess}")]
        //public IActionResult GetByIdProcess(int idProcess)
        //{
        //    return Ok(_iInterviewService.GetAllInterViewsByIdProcess(idProcess));
        //}

        //[HttpGet("GetInterviewById/{idInterview}")]
        //public IActionResult GetInterviewById(int idInterview)
        //{
        //    return Ok(_iInterviewService.GetInterviewById(idInterview));
        //}

        [HttpPost("AddInterview")]
        public async Task<IResult> AddInterview(InterviewModel interviewModel)
        {
            var interview = _mapper.Map<ServiceInterviewDto>(interviewModel);
            var result = await _iInterviewService.AddInterview(interview);
            return _iAutoMapperHttp.Ok(result);
        }

        //[HttpPut("UpdateInterview")]
        //public IActionResult UpdateInterview(InterviewModel interviewModel)
        //{
        //    var interview = _mapper.Map<ServiceInterviewDto>(interviewModel);
        //    return Ok(_iInterviewService.UpdateInterview(interview));
        //}

        //[HttpDelete("DeleteInterview/{idInterview}")]
        //public IActionResult DeleteInterview(int idInterview)
        //{
        //    return Ok(_iInterviewService.DeleteInterview(idInterview));
        //}
    }
}
