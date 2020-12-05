using TaPegandoFogoBicho.Borders.Dto;

namespace TaPegandoFogoBicho.Borders.Repositories
{
    public interface IMeasurementRepository
    {
        void Insert(MqttRequest mqttRequest);
    }
}
