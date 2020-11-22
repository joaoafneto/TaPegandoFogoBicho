using System.Threading.Tasks;

namespace TaPegandoFogoBicho.Shared.Configurations
{
    public interface IExecutor<TRequest, TResponse>
    {
        Task<TResponse> Execute(TRequest request);
    }
}
