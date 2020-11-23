using System.Collections.Generic;
using System.Threading.Tasks;
using TaPegandoFogoBicho.Borders.Dto;

namespace TaPegandoFogoBicho.Borders.Repositories
{
    public interface IDeviceRepository
    {
        Task<List<DeviceDto>> GetDevice(int idClient);
    }
}
