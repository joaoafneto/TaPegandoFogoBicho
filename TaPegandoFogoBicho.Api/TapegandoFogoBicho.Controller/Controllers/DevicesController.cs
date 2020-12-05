using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaPegandoFogoBicho.Borders.Controllers.DevicesController;
using TaPegandoFogoBicho.Borders.Executors.Device;
using TaPegandoFogoBicho.Borders.Shared.Converters;

namespace TapegandoFogoBicho.Controllers.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IGetDeviceExecutor _getDeviceExecutor;

        public DevicesController(IGetDeviceExecutor getDeviceExecutor)
        {
            _getDeviceExecutor = getDeviceExecutor;
        }

        [HttpGet]
        [Route("{Cpf}/{Senha}")]
        [ProducesResponseType(200, Type = typeof(List<DeviceModel>))]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [ProducesResponseType(404, Type = typeof(NotFoundResult))]
        public async Task<IActionResult> GetDevice([FromRoute] string cpf, string senha)
        {
            try
            {
                var response = await _getDeviceExecutor.Execute(new GetDeviceRequest { Cpf = cpf, Senha = senha });

                if (response != null)
                {
                    return Ok(response.DeviceDto.Converter());
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
