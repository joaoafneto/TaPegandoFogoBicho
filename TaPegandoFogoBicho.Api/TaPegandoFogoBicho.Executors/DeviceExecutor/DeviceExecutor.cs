using System;
using System.Threading.Tasks;
using TaPegandoFogoBicho.Borders.Dto.GetDeviceExecutor;
using TaPegandoFogoBicho.Borders.Executors;
using TaPegandoFogoBicho.Borders.Repositories;

namespace TaPegandoFogoBicho.Executors.DeviceExecutor
{
    public class DeviceExecutor : IGetDeviceExecutor
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceExecutor(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<GetDeviceResponse> Execute(GetDeviceRequest request)
        {
            try
            {
                return new GetDeviceResponse { DeviceDto = (await _deviceRepository.GetDevice(request.IdClient)) };
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
