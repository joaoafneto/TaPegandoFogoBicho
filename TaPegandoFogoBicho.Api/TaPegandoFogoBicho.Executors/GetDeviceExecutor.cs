using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using TaPegandoFogoBicho.Borders.Executors.Device;
using TaPegandoFogoBicho.Borders.Repositories;

namespace TaPegandoFogoBicho.Executors
{
    public class GetDeviceExecutor : IGetDeviceExecutor
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IClientRepository _clientRepository;

        public GetDeviceExecutor(IDeviceRepository deviceRepository, IClientRepository clientRepository)
        {
            _deviceRepository = deviceRepository;
            _clientRepository = clientRepository;
        }

        public async Task<GetDeviceResponse> Execute(GetDeviceRequest request)
        {
            try
            {
                int idClient = await _clientRepository.Login(request.Cpf, request.Senha);

                if (idClient == 0)
                    throw new Exception($"Error login: {JsonConvert.SerializeObject(request)}");

                return new GetDeviceResponse { DeviceDto = await _deviceRepository.GetDevice(idClient) };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
