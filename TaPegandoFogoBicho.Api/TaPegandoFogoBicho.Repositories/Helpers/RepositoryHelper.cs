using MySql.Data.MySqlClient;
using System.Data;
using TaPegandoFogoBicho.Borders.Repositories.Helpers;
using TaPegandoFogoBicho.Shared.Configurations;

namespace TaPegandoFogoBicho.Repositories.Helpers
{
    public class RepositoryHelper : IRepositoryHelper
    {
        public IDbConnection GetConnection()
        {
            return new MySqlConnection(ConnectionStrings.DefaultConnection);
        }
    }
}
