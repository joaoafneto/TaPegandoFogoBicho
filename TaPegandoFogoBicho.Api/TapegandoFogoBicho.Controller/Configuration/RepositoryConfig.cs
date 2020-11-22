using Microsoft.Extensions.DependencyInjection;
using TaPegandoFogoBicho.Borders.Repositories;
using TaPegandoFogoBicho.Borders.Repositories.Helpers;
using TaPegandoFogoBicho.Repositories;
using TaPegandoFogoBicho.Repositories.Helpers;

namespace TapegandoFogoBicho.Controllers.Configuration
{
    public static class RepositoryConfig
    {
        public static void ConfigureRepository(IServiceCollection services)
        {
            services.AddScoped<IRepositoryHelper, RepositoryHelper>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
        }
    }
}
