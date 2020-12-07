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
                    var cpfCnpj = _clientRepository.Exist(request.ClientDto).Result;

                    if (!String.IsNullOrEmpty(cpfCnpj))
                    {
                        throw new Exception($"Cpf/Cnpj already exist: {JsonConvert.SerializeObject(cpfCnpj)}");
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
