using System.Threading.Tasks;
using TaPegandoFogoBicho.Borders.Dto;

namespace TaPegandoFogoBicho.Borders.Repositories
{
    public interface IClientRepository
    {
        Task<int> Login(string cpf, string senha);
        Task<bool> Create(ClientDto clientDto);
        Task<string> Exist(ClientDto clientDto);
    }
}
