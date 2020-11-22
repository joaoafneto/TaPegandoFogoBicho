using Microsoft.Extensions.Configuration;
using TaPegandoFogoBicho.Shared.Configurations;

namespace TapegandoFogoBicho.Controllers.Extensions
{
    public static class ConfigurationExtensions
    {
        public static void LoadConfiguration(this IConfiguration source)
        {
            source.Get<ApplicationConfig>();
        }
    }
}
