using TaPegandoFogoBicho.Borders.Dto;
using TaPegandoFogoBicho.Borders.Executors;
using TaPegandoFogoBicho.Borders.Repositories;

namespace TaPegandoFogoBicho.Executors
{
    public class MqttExecutor : IMqttExecutor
    {
        private readonly IMeasurementRepository _measurementRepository;

        public MqttExecutor(IMeasurementRepository measurementRepository)
        {
            _measurementRepository = measurementRepository;
        }

        public void Execute(MqttRequest request)
        {
            if (request == null)
                return;

            _measurementRepository.Insert(request);
        }
    }
}
