using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using App.InterViews.Report.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.InterViews.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterviewController : ControllerBase
    {
        private readonly IInterViewReportService _iInterViewReport;
        private readonly IMapper _mapper;

        public InterviewController(IInterViewReportService iInterViewReport, IMapper mapper)
        {
            _iInterViewReport = iInterViewReport;
            _mapper = mapper;
        }

        [HttpGet("GetAllInterviews")]
        public IActionResult GetAllInterviews()
        {
            return Ok(_iInterViewReport.GetAllInterViews());
        }

        [HttpPost("AddInterview")]
        public IActionResult AddInterview(InterviewModel interviewModel)
        {
            var interview = _mapper.Map<ServiceInterviewModel>(interviewModel);
            return Ok(_iInterViewReport.AddInterview(interview));
        }

        [HttpDelete("DeleteInterview/{idInterview}")]
        public IActionResult DeleteInterview(int idInterview)
        {
            return Ok(_iInterViewReport.DeleteInterview(idInterview));
        }
    }
}
