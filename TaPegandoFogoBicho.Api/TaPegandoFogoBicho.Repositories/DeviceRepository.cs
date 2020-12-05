using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TaPegandoFogoBicho.Borders.Dto;
using TaPegandoFogoBicho.Borders.Repositories;
using TaPegandoFogoBicho.Borders.Repositories.Helpers;

namespace TaPegandoFogoBicho.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly IRepositoryHelper _helper;
        public DeviceRepository(IRepositoryHelper helper)
        {
            _helper = helper;
        }

        public async Task<List<DeviceDto>> GetDevice(int idClient)
        {
            const string sql = @"SELECT 
                    device.IdDispositivo,
                    device.IdCliente,
                    device.Latitude,
                    device.Longitude,
                    device.Apelido,
                    m.DispositivoId,
                    m.Temperatura,
                    m.Fumaca,
                    m.Gas,
                    m.UmidadeAr,
                    m.DataAtualizacao,
                    m.Risco
                FROM
                    Dispositivo device
                        JOIN
                    Medicao m ON device.IdDispositivo = m.DispositivoId
                WHERE
                    device.IdCliente = @IdCliente";

            var param = new DynamicParameters();

            param.Add("@IdCliente", idClient, DbType.Int32);


            var deviceDtoDictionary = new Dictionary<int, DeviceDto>();

            using var connection = _helper.GetConnection();
            return (await connection.QueryAsync<DeviceDto, MeasurementDto, DeviceDto>(sql,
                map: (deviceDto, measurementDto) =>
                {
                    if (deviceDtoDictionary.TryGetValue(deviceDto.IdDispositivo, out DeviceDto device))
                    {
                        deviceDto = device;
                    }
                    else
                    {
                        if (deviceDto.Measurements == null)
                        {
                            deviceDto.Measurements = new List<MeasurementDto>();
                        }

                        deviceDtoDictionary.Add(deviceDto.IdDispositivo, deviceDto);
                    }

                    if(measurementDto != null)
                    {
                        var measurementList = deviceDto.Measurements.Find(x => x.DispositivoId == measurementDto.DispositivoId);
                    
                        if(measurementList == null)
                        {
                            deviceDto.Measurements.Add(measurementDto);
                        }
                    }

                    return deviceDto;
                },
                param,
                null,
                true,
                splitOn: "IdDispositivo,DispositivoId")).ToList();
        }
    }
}
