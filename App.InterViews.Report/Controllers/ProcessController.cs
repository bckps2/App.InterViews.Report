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
    public class ProcessController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAutoMapperHttp _iAutoMapperHttp;
        private readonly IProcessReportService _iProcessService;

        public ProcessController(IProcessReportService iProcessService, IMapper mapper, IAutoMapperHttp iAutoMapperHttp)
        {
            _mapper = mapper;
            _iProcessService = iProcessService;
            _iAutoMapperHttp = iAutoMapperHttp;
        }

        [HttpGet("GetAllProcess")]
        public IResult GetAllProcess()
        {
            return _iAutoMapperHttp.Ok(_iProcessService.GetAll());
        }

        [HttpGet("GetProcessesByIdCompany/{idCompany}")]
        public Task<IResult> GetProcessesByIdCompany(int idCompany)
        {
            var result = _iProcessService.GetProcessesByIdCompany(idCompany);
            return Task.FromResult(_iAutoMapperHttp.Ok(result));
        }

        [HttpPost("AddProcess")]
        public async Task<IResult> AddProcess(ProcessModel processModel)
        {
            var process = _mapper.Map<ProcessDto>(processModel);
            var result = await _iProcessService.Add(process);
            return _iAutoMapperHttp.Ok(result);
        }

        [HttpDelete("DeleteProcess/{idProcess}")]
        public async Task<IResult> DeleteProcess(int idProcess)
        {
            var result = await _iProcessService.Delete(idProcess);
            return _iAutoMapperHttp.Ok(result);
        }
    }
}
