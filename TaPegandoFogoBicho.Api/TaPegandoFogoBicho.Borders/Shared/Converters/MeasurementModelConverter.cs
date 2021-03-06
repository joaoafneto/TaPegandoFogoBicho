﻿using System.Collections.Generic;
using TaPegandoFogoBicho.Borders.Controllers.DevicesController;
using TaPegandoFogoBicho.Borders.Dto;

namespace TaPegandoFogoBicho.Borders.Shared.Converters
{
    public static class MeasurementModelConverter
    {
        public static MeasurementModel Converter(this MeasurementDto measurementDto)
        {
            return measurementDto == null ? null : new MeasurementModel
            {
                Smoke = measurementDto.Fumaca,
                AirHumidity = measurementDto.UmidadeAr,
                Danger = measurementDto.Risco,
                Gas = measurementDto.Gas,
                IdDispositivo = measurementDto.DispositivoId,
                Temperature = measurementDto.Temperatura,
                UpdateDate = measurementDto.DataAtualizacao,
                IdMedicao = measurementDto.IdMedicao
            };
        }

        public static List<MeasurementModel> Converter(this ICollection<MeasurementDto> measurementsDto)
        {
            var response = new List<MeasurementModel>();

            if (measurementsDto == null)
                return response;

            foreach (MeasurementDto measurement in measurementsDto)
            {
                response.Add(measurement.Converter());
            }

            return response;
        }
    }
}
