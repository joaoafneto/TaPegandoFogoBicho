using Dapper;
using System.Data;
using System.Threading.Tasks;
using TaPegandoFogoBicho.Borders.Repositories;
using TaPegandoFogoBicho.Borders.Repositories.Helpers;

namespace TaPegandoFogoBicho.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IRepositoryHelper _helper;

        public ClientRepository(IRepositoryHelper helper)
        {
            _helper = helper;
        }

        public Task<int> Login(string cpf, string senha)
        {
            string sql = @"SELECT
                                IdCliente
                           FROM Cliente
                           WHERE
                                CpfCnpj = @CpfCnpj
                           AND 
                                Senha = @Senha";


            var param = new DynamicParameters();

            param.Add("@CpfCnpj", cpf.Replace(".", "").Replace("-", "").Replace("/", ""), DbType.String);
            param.Add("@Senha", senha, DbType.String);

            using var connection = _helper.GetConnection();
            return connection.QueryFirstOrDefaultAsync<int>(sql, param);
        }
    }
}
