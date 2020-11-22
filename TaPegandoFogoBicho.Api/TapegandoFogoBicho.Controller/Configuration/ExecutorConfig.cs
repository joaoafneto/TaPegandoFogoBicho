using Microsoft.Extensions.DependencyInjection;
using TaPegandoFogoBicho.Borders.Executors;
using TaPegandoFogoBicho.Executors.DeviceExecutor;

namespace TapegandoFogoBicho.Controllers.Configuration
{
    public static class ExecutorConfig
    {
        public static void ConfigureExecutor(IServiceCollection services)
        {
            services.AddScoped<IGetDeviceExecutor, DeviceExecutor>();
        }
    }
}
