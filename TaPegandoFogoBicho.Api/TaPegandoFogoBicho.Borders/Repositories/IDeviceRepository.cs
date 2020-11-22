using System.Threading.Tasks;
using TaPegandoFogoBicho.Borders.Dto;

namespace TaPegandoFogoBicho.Borders.Repositories
{
    public interface IDeviceRepository
    {
        Task<DeviceDto> GetDevice(int idClient);
    }
}
