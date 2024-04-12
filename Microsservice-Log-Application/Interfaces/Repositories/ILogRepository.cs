using SimpleEnergy_Log_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnergy_Log_Application.Interfaces.Repositories
{
    public interface ILogRepository
    {
        void GravarLog(Log log);
    }
}
