using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleEnergy_Log_Application.Interfaces.Services;
using SimpleEnergy_Log_Domain.Models;
using System.Security.Claims;

namespace SimpleEnergy_Log_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        [Route("gravar")]
        public async Task<IActionResult> GravarLog(LogModel model)
        {
            try
            {
                await _logService.GravarLog(model);

                return Ok("Log gravado com sucesso");
            }
            catch (Exception e)
            {
                return BadRequest("Erro ao gravar log. " + e.Message);
            }
        }
    }
}
