using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TaPegandoFogoBicho.Borders.Controllers.ClientController;
using TaPegandoFogoBicho.Borders.Dto;
using TaPegandoFogoBicho.Borders.Executors;
using TaPegandoFogoBicho.Borders.Executors.Client;

namespace TapegandoFogoBicho.Controllers.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ICreateClientExecutor _createClientExecutor;

        public ClientController(ICreateClientExecutor createClientExecutor)
        {
            _createClientExecutor = createClientExecutor;
        }

        [HttpPut]
        [ProducesResponseType(201, Type = typeof(CreatedResult))]
        public async Task<IActionResult> Create([FromQuery] ClientModel request)
        {
            try
            {
                var response = await _createClientExecutor.Execute(new CreateClientRequest { ClientDto = ConverterToDto(request) });

                return Created(String.Empty, response.Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private ClientDto ConverterToDto(ClientModel clientModel)
        {
            return clientModel == null ? null : new ClientDto
            {
                Bairro = clientModel.Bairro,
                Cidade = clientModel.Cidade,
                Senha = clientModel.Senha,
                CpfCnpj = clientModel.CpfCnpj,
                Email = clientModel.Email,
                Estado = clientModel.Estado,
                IdClient = clientModel.IdClient ?? 0,
                Logradouro = clientModel.Logradouro,
                Nome = clientModel.Nome,
                Numero = clientModel.Numero,
                Telefone = clientModel.Telefone
            };
        }
    }
}
