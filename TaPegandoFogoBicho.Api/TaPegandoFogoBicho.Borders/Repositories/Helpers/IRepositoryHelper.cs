using System.Data;

namespace TaPegandoFogoBicho.Borders.Repositories.Helpers
{
    public interface IRepositoryHelper
    {
        IDbConnection GetConnection();
    }
}
