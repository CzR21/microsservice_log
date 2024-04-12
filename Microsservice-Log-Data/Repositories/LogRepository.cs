using SimpleEnergy_Log_Application.Interfaces.Repositories;
using SimpleEnergy_Log_Domain.Entities;
using SimpleEnergy_Log_Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnergy_Log_Data.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly BaseDBContext _dbContext;

        public LogRepository(BaseDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void GravarLog(Log log)
        {
            _dbContext.Logs.Add(log);
            _dbContext.SaveChanges();
        }
    }
}
