using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using App.InterViews.Report.Models;
using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;

namespace App.InterViews.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformationInterviewController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IInfomationInterviewReportService _iInformationService;

        public InformationInterviewController(IInfomationInterviewReportService iInformationService, IMapper mapper)
        {
            _mapper = mapper;
            _iInformationService = iInformationService;
        }

        [HttpGet("GetAllInformations")]
        public IActionResult GetAllInformations()
        {
            return Ok(_iInformationService.GetAll());
        }

        [HttpPost("AddInterviewInformation")]
        public IActionResult AddInterViewInformation(InformationInterviewModel interViewModel)
        {
            var informationInterView = _mapper.Map<ServiceInformationModel>(interViewModel);
            return Ok(_iInformationService.AddInterViewInformation(informationInterView));
        }

        [HttpPut("UpdateInterviewInformation")]
        public IActionResult UpdateInterViewInformation(InformationInterviewModel interViewModel)
        {
            var informationInterView = _mapper.Map<ServiceInformationModel>(interViewModel);
            return Ok(_iInformationService.UpdateInterViewInformation(informationInterView));
        }

        [HttpDelete("DeleteInformationInterview/{idInformation}")]
        public IActionResult DeleteInformationInterview(int idInformation)
        {
            return Ok(_iInformationService.DeleteInformation(idInformation));
        }
    }
}
