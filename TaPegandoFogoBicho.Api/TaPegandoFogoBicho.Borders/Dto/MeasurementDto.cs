using System;

namespace TaPegandoFogoBicho.Borders.Dto
{
    public class MeasurementDto
    {
        public int DispositivoId { get; set; }
        public double Temperature { get; set; }
        public double Smoke { get; set; }
        public double Gas { get; set; }
        public double AirHumidity { get; set; }
        public DateTime UpdateDate { get; set; }
        public bool Danger { get; set; }
    }
}
