using Newtonsoft.Json;
using System;

namespace TaPegandoFogoBicho.Borders.Controllers.DevicesController
{
    public class MeasurementModel
    {
        public int IdMedicao { get; set; }
        [JsonProperty("idDevice")]
        public int IdDispositivo { get; set; }
        [JsonProperty("temp")]
        public double Temperature { get; set; }
        [JsonProperty("cmonoxide")]
        public double Smoke { get; set; }
        [JsonProperty("gas")]
        public double Gas { get; set; }
        [JsonProperty("humidity")]
        public double AirHumidity { get; set; }
        public DateTime UpdateDate { get; set; }
        public double Danger { get; set; }
    }
}
