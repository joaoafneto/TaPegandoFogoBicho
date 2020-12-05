using Dapper;
using System;
using System.Data;
using TaPegandoFogoBicho.Borders.Dto;
using TaPegandoFogoBicho.Borders.Repositories;
using TaPegandoFogoBicho.Borders.Repositories.Helpers;

namespace TaPegandoFogoBicho.Repositories
{
    public class MeasurementRepository : IMeasurementRepository
    {
        private readonly IRepositoryHelper _helper;

        public MeasurementRepository(IRepositoryHelper helper)
        {
            _helper = helper;
        }

        public void Insert(MqttRequest mqttRequest)
        {
            string sql = @"INSERT
                    INTO ta_pegando_fogo.Medicao
                        (IdDispositivo,
                        Temperatura, 
                        Fumaca,
                        Gas,
                        UmidadeAr,
                        DataAtualizacao,
                        Risco)
                    VALUES
                        (3,
                        @Temperatura,
                        @Fumaca,
                        @Gas, 
                        @Umidade, 
                        @DataAtualizacao, 
                        @Risco)";


            var param = new DynamicParameters();

            param.Add("@Temperatura", mqttRequest.measurement.Temperature, DbType.Double);
            param.Add("@Fumaca", mqttRequest.measurement.Smoke, DbType.Double);
            param.Add("@Gas", mqttRequest.measurement.Gas, DbType.Double);
            param.Add("@Umidade", mqttRequest.measurement.AirHumidity, DbType.Double);
            param.Add("@DataAtualizacao", DateTime.Now, DbType.DateTime);
            param.Add("@Risco", 0, DbType.Double);

            using var connection = _helper.GetConnection();

            connection.Execute(sql, param);
        }
    }
}
