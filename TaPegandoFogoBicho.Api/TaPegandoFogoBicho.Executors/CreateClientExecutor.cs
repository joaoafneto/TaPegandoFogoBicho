using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TaPegandoFogoBicho.Borders.Executors;
using TaPegandoFogoBicho.Borders.Executors.Client;
using TaPegandoFogoBicho.Borders.Repositories;

namespace TaPegandoFogoBicho.Executors
{
    public class CreateClientExecutor : ICreateClientExecutor
    {
        private readonly IClientRepository _clientRepository;

        public CreateClientExecutor(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<CreateClientResponse> Execute(CreateClientRequest request)
        {
            try
            {
                if (request != null)
                {
                    var result = _clientRepository.Exist(request.ClientDto).Result;

                    if (result != null)
                    {
                        throw new Exception($"Cpf/Cnpj or Email already exist: {JsonConvert.SerializeObject(result)}");
                    }

                    if (await _clientRepository.Create(request.ClientDto))
                        return new CreateClientResponse { Created = true };

                    throw new Exception(message: $"It was not possible to create client: {JsonConvert.SerializeObject(request)}");
                }

                return new CreateClientResponse { Created = false };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
