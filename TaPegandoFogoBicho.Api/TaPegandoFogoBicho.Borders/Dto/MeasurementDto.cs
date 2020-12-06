using System;

namespace TaPegandoFogoBicho.Borders.Dto
{
    public class MeasurementDto
    {
        public int IdMedicao { get; set; }
        public int DispositivoId { get; set; }
        public double Temperatura { get; set; }
        public double Fumaca { get; set; }
        public double Gas { get; set; }
        public double UmidadeAr { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public double Risco { get; set; }
    }
}
