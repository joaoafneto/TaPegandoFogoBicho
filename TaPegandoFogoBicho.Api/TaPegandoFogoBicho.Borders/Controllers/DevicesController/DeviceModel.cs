using System.Collections.Generic;

namespace TaPegandoFogoBicho.Borders.Controllers.DevicesController
{
    public class DeviceModel
    {
        public int IdDevice { get; set; }
        public int IdClient { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Nick { get; set; }
        public List<MeasurementModel> Measurements { get; set; }
    }
}
