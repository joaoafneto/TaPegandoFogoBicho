using TaPegandoFogoBicho.Borders.Controllers.ClientController;
using TaPegandoFogoBicho.Borders.Dto;

namespace TaPegandoFogoBicho.Borders.Shared.Converters
{
    public static class ClientModelConverter
    {
        public static ClientDto ConverterToDto(this ClientModel clientModel)
        {
            return clientModel == null ? null : new ClientDto
            {
                Bairro = clientModel.Bairro,
                Cidade = clientModel.Cidade,
                Senha = clientModel.Senha,
                CpfCnpj = clientModel.CpfCnpj,
                Email = clientModel.Email,
                Estado = clientModel.Estado,
                IdClient = clientModel.IdClient ?? 0,
                Logradouro = clientModel.Logradouro,
                Nome = clientModel.Nome,
                Numero = clientModel.Numero,
                Telefone = clientModel.Telefone
            };
        }

        public static ClientModel Converter(this ClientDto clientDto)
        {
            return clientDto == null ? null : new ClientModel
            {
                Bairro = clientDto.Bairro,
                Cidade = clientDto.Cidade,
                Senha = clientDto.Senha,
                CpfCnpj = clientDto.CpfCnpj,
                Email = clientDto.Email,
                Estado = clientDto.Estado,
                IdClient = clientDto.IdClient,
                Logradouro = clientDto.Logradouro,
                Nome = clientDto.Nome,
                Numero = clientDto.Numero,
                Telefone = clientDto.Telefone
            };
        }
    }
}
