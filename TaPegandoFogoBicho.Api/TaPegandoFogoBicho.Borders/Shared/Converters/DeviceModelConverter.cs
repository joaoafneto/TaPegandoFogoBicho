using System.Collections.Generic;
using TaPegandoFogoBicho.Borders.Controllers.DevicesController;
using TaPegandoFogoBicho.Borders.Dto;
using TaPegandoFogoBicho.Borders.Dto.GetDeviceExecutor;

namespace TaPegandoFogoBicho.Borders.Shared.Converters
{
    public static class DeviceModelConverter
    {
        public static DeviceModel Converter(this DeviceDto deviceDto)
        {
            return deviceDto == null ? null : new DeviceModel
            {
                IdClient = deviceDto.IdCliente,
                IdDevice = deviceDto.IdDispositivo,
                Latidude = deviceDto.Latidude,
                Longitude = deviceDto.Longitude,
                Measurements = deviceDto.Measurements.Converter(),
                Nick = deviceDto.Apelido
            };
        }

        public static List<DeviceModel> Converter(this ICollection<DeviceDto> devicesDto)
        {
            var response = new List<DeviceModel>();

            if (devicesDto == null)
                return response;

            foreach (DeviceDto measurement in devicesDto)
            {
                response.Add(measurement.Converter());
            }

            return response;
        }
    }
}
