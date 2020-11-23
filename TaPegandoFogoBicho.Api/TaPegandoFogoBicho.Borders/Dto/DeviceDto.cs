using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaPegandoFogoBicho.Borders.Dto
{
    public class DeviceDto
    {
        public int IdDispositivo { get; set; }
        public int IdCliente { get; set; }
        public string Latidude { get; set; }
        public string Longitude { get; set; }
        public string Apelido { get; set; }
        public List<MeasurementDto> Measurements { get; set; }
    }
}
