using Dapper;
using System.Data;
using System.Threading.Tasks;
using TaPegandoFogoBicho.Borders.Dto;
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

        public async Task<bool> Create(ClientDto clientDto)
        {
            string sql = @"INSERT 
	                INTO ta_pegando_fogo.Cliente
			                (IdCliente,
                            Nome,
			                Email,
			                Logradouro,
			                Bairro,
			                Numero,
			                Cidade,
			                Estado,
			                Telefone,
			                CpfCnpj,
			                Senha)
	                VALUES
			                (@IdCliente,
                            @Nome,
			                @Email,
			                @Logradouro,
			                @Bairro,
			                @Numero,
			                @Cidade,
			                @Estado,
			                @Telefone,
			                @CpfCnpj,
			                @Senha);
                            ";

            var param = new DynamicParameters();

            param.Add("@IdCliente", clientDto.IdClient, DbType.Int32);
            param.Add("@Nome", clientDto.Nome, DbType.String);
            param.Add("@Email", clientDto.Email, DbType.String);
            param.Add("@Logradouro", clientDto.Logradouro, DbType.String);
            param.Add("@Bairro", clientDto.Bairro, DbType.String);
            param.Add("@Numero", clientDto.Numero, DbType.Int32);
            param.Add("@Cidade", clientDto.Cidade, DbType.String);
            param.Add("@Estado", clientDto.Estado, DbType.String);
            param.Add("@Telefone", clientDto.Telefone, DbType.String);
            param.Add("@CpfCnpj", clientDto.CpfCnpj.Replace(".", "").Replace("-", "").Replace("/", ""), DbType.String);
            param.Add("@Senha", clientDto.Senha, DbType.String);

            using var connection = _helper.GetConnection();
            return await connection.ExecuteAsync(sql, param) > 0;
        }

        public async Task<ClientDto> Exist(ClientDto clientDto)
        {
            string sql = @"SELECT 
	                        c.CpfCnpj,
                            c.Email
                        FROM 
	                        Cliente c 
                        WHERE
	                        c.CpfCnpj = @CpfCnpj
                        OR 
                            c.Email = @Email";

            var param = new DynamicParameters();

            param.Add("@CpfCnpj", clientDto.CpfCnpj.Replace(".", "").Replace("-", "").Replace("/", ""), DbType.String);
            param.Add("@Email", clientDto.Email, DbType.String);

            using var connection = _helper.GetConnection();
            return await connection.QueryFirstOrDefaultAsync<ClientDto>(sql, param);
        }
    }
}
