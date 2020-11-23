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
                    device.Apelido
                FROM 
                    Dispositivo device
                WHERE
                    device.IdCliente = @IdCliente";

            var param = new DynamicParameters();

            param.Add("@IdCliente", idClient, DbType.Int32);

            var deviceDtoDictionary = new Dictionary<int, DeviceDto>();

            using var connection = _helper.GetConnection();
            return (await connection.QueryAsync<DeviceDto>(sql,param)).ToList();
        }
    }
}
