using Microsoft.Extensions.DependencyInjection;
using TaPegandoFogoBicho.Borders.Executors;
using TaPegandoFogoBicho.Borders.Executors.Device;
using TaPegandoFogoBicho.Executors;

namespace TapegandoFogoBicho.Controllers.Configuration
{
    public static class ExecutorConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGetDeviceExecutor, GetDeviceExecutor>();
            services.AddScoped<IMqttExecutor, MqttExecutor>();
            services.AddScoped<ICreateClientExecutor, CreateClientExecutor>();
        }
    }
}
