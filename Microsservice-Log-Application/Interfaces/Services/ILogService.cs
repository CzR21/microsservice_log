using SimpleEnergy_Log_Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnergy_Log_Application.Interfaces.Services
{
    public interface ILogService
    {
        Task GravarLog(LogModel model);
    }
}
