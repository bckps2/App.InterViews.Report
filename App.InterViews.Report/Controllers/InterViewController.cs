using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using App.InterViews.Report.Models;
using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;

namespace App.InterViews.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IInterViewReportService _iInterviewService;

        public InterviewController(IInterViewReportService iInterviewService, IMapper mapper)
        {
            _mapper = mapper;
            _iInterviewService = iInterviewService;
        }

        [HttpGet("GetInterviews")]
        public IActionResult GetInterviews()
        {
            return Ok(_iInterviewService.GetAllInterViews());
        }

        [HttpGet("GetByIdProcess/{idInterview}")]
        public IActionResult GetByIdProcess(int idInterview)
        {
            return Ok(_iInterviewService.GetAllInterViewsByIdProcess(idInterview));
        }

        [HttpPost("AddInterview")]
        public IActionResult AddInterview(InterviewModel interviewModel)
        {
            var interview = _mapper.Map<ServiceInterviewModel>(interviewModel);
            return Ok(_iInterviewService.AddInterview(interview));
        }

        [HttpPut("UpdateInterview")]
        public IActionResult UpdateInterview(InterviewModel interviewModel)
        {
            var interview = _mapper.Map<ServiceInterviewModel>(interviewModel);
            return Ok(_iInterviewService.UpdateInterview(interview));
        }

        [HttpDelete("DeleteInterview/{idInformation}")]
        public IActionResult DeleteInterview(int idProcess)
        {
            return Ok(_iInterviewService.DeleteInterview(idProcess));
        }
    }
}
