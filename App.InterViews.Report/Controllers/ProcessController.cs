using App.InterViews.Report.Contract.Service.Models;
using App.InterViews.Report.Contract.Service.ServiceInterviewReport;
using App.InterViews.Report.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace App.InterViews.Report.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProcessReportService _iProcessService;
        public ProcessController(IProcessReportService iProcessService, IMapper mapper)
        {
            _iProcessService = iProcessService;
            _mapper = mapper;
        }

        [HttpGet("GetProcess")]
        public IActionResult GetProcess()
        {
            return Ok(_iProcessService.GetAll());
        }

        [HttpGet("GetByIdCompany/{idCompany}")]
        public IActionResult GetByIdCompany(int idCompany)
        {
            return Ok(_iProcessService.GetAllByIdCompany(idCompany));
        }

        [HttpPost("AddProcess")]
        public IActionResult AddProcess(ProcessModel processModel)
        {
            var process = _mapper.Map<ServiceProcessModel>(processModel);
            return Ok(_iProcessService.AddProcess(process));
        }

        [HttpDelete("DeleteProcess/{idProcess}")]
        public IActionResult DeleteProcess(int idProcess)
        {
            return Ok(_iProcessService.DeleteProcess(idProcess));
        }
    }
}
