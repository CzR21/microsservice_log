using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnergy_Log_Application.Interfaces.Services
{
    public interface ICloudWatchService
    {
        Task SendLog(string messagem, DateTime data);
    }
}
