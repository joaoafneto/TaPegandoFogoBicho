using System.Threading.Tasks;

namespace TaPegandoFogoBicho.Borders.Repositories
{
    public interface IClientRepository
    {
        Task<int> Login(string cpf, string senha);
    }
}
