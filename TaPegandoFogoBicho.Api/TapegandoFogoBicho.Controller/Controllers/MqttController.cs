using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace TapegandoFogoBicho.Controllers.Controllers
{
    public class MqttController
    {
        private readonly ICreateMeasurementExecutor _createMeasurementExecutor;

        public MqttController(ICreateMeasurementExecutor createMeasurementExecutor)
        {
            _createMeasurementExecutor = createMeasurementExecutor;
        }
        
        public void CreateMeasurement()
        {

        }
    }
}
