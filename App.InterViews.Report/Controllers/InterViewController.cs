using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using App.InterViews.Report.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using FluentValidation.Results;
using App.InterViews.Report.Contract.Service.Dtos;
using App.InterViews.Report.Library.Entities;

namespace App.InterViews.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IInterViewReportService<InterView, ValidationResult> _iInterviewService;

        public InterviewController(IInterViewReportService<InterView, ValidationResult> iInterviewService, IMapper mapper)
        {
            _mapper = mapper;
            _iInterviewService = iInterviewService;
        }

        [HttpGet("GetInterviews")]
        public IActionResult GetInterviews()
        {
            return Ok(_iInterviewService.GetAllInterViews());
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

        //[HttpPost("AddInterview")]
        //public IActionResult AddInterview(InterviewModel interviewModel)
        //{
        //    var interviewServiceModel = _mapper.Map<ServiceInterviewDto>(interviewModel);
        //    return Ok(_iInterviewService.AddInterview(interviewServiceModel));
        //}

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
