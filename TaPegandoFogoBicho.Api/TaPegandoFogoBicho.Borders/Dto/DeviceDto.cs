using System.Collections.Generic;

namespace TaPegandoFogoBicho.Borders.Dto
{
    public class DeviceDto
    {
        public int IdDevice { get; set; }
        public string Nick { get; set; }
        public string Latidude { get; set; }
        public string Longitude { get; set; }
        public int IdClient { get; set; }
        public List<MeasurementDto> Measurements { get; set; }
    }
}
