using TaPegandoFogoBicho.Borders.Controllers.DevicesController;
using TaPegandoFogoBicho.Borders.Dto.GetDeviceExecutor;

namespace TaPegandoFogoBicho.Borders.Shared.Converters
{
    public static class DeviceModelConverter
    {
        public static DeviceModel Converter(this GetDeviceResponse getDeviceResponse)
        {
            return getDeviceResponse == null ? null : new DeviceModel
            {
                IdClient = getDeviceResponse.DeviceDto.IdClient,
                IdDevice = getDeviceResponse.DeviceDto.IdDevice,
                Latidude = getDeviceResponse.DeviceDto.Latidude,
                Longitude = getDeviceResponse.DeviceDto.Longitude,
                Measurements = getDeviceResponse.DeviceDto.Measurements.Converter(),
                Nick = getDeviceResponse.DeviceDto.Nick
            };
        }
    }
}
