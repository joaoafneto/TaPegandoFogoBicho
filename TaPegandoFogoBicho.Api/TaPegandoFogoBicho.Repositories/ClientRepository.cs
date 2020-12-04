using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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


    }
}
