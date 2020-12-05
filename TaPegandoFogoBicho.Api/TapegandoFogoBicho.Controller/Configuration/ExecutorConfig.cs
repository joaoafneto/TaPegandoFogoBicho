using Microsoft.Extensions.DependencyInjection;
using TaPegandoFogoBicho.Borders.Executors;
using TaPegandoFogoBicho.Borders.Executors.Device;
using TaPegandoFogoBicho.Executors.DeviceExecutor;
using TaPegandoFogoBicho.Executors.MqttExecutor;

namespace TapegandoFogoBicho.Controllers.Configuration
{
    public static class ExecutorConfig
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IGetDeviceExecutor, DeviceExecutor>();
            services.AddScoped<IMqttExecutor, MqttExecutor>();
        }
    }
}
