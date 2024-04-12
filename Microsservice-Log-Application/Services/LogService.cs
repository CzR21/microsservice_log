using SimpleEnergy_Log_Application.Interfaces.Repositories;
using SimpleEnergy_Log_Application.Interfaces.Services;
using SimpleEnergy_Log_CrossCutting.Utils;
using SimpleEnergy_Log_Domain.Entities;
using SimpleEnergy_Log_Domain.Enum;
using SimpleEnergy_Log_Domain.Helpers;
using SimpleEnergy_Log_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnergy_Log_Application.Services
{
    public class LogService : ILogService
    {
        private readonly ILogRepository _logRepository;
        private readonly ICloudWatchService _cloudWatchService;

        public LogService(ILogRepository logRepository, AWSConfiguration awsConfiguration, ICloudWatchService cloudWatchService)
        {
            _logRepository = logRepository;
            _cloudWatchService = cloudWatchService;
        }

        public async Task GravarLog(LogModel model)
        {
            var log = new Log()
            {
                TipoLog = (TipoLog)Enum.Parse(typeof(TipoLog), model.TipoLog),
                Funcao = model.Funcao,
                Descricao = model.Descricao,
                DataOcorrencia = DataUtils.GetDateTimeBrasil(),
                NomeUsuario = model.NomeUsuario,
            };

            //Gravar na base
            _logRepository.GravarLog(log);

            //Gravar no CloudWatch
            await _cloudWatchService.SendLog($"Tipo: {log.TipoLog} \nFunção: {log.Funcao}" + $"\nDescrição: {log.Descricao}" + $"\nUsuário: {log.NomeUsuario}", log.DataOcorrencia);
            //await _cloudWatchService.SendLog(model);
        }
    }
}
