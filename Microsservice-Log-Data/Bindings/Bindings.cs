using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleEnergy_Log_Application.Interfaces.Repositories;
using SimpleEnergy_Log_Application.Interfaces.Services;
using SimpleEnergy_Log_Application.Services;
using SimpleEnergy_Log_Data.Repositories;
using SimpleEnergy_Log_Domain.Helpers;
using SimpleEnergy_Log_Infrastructure.Context;
using System.Text;

namespace SimpleEnergy_Log_CrossCutting.Bindings
{
    public class Bindings
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            #region Options
            ConnectionString connectionStrings = configuration.GetSection("ConnectionStrings").Get<ConnectionString>();
            AWSConfiguration awsConfiguration = configuration.GetSection("AWSConfiguration").Get<AWSConfiguration>();

            services.AddSingleton(connectionStrings);
            services.AddSingleton(awsConfiguration);
            #endregion

            #region Injeção de dependencia
            //Services
            services.AddScoped<ILogService, LogService>();
            services.AddScoped<ICloudWatchService, CloudWatchService>();

            //Repositories
            services.AddScoped<ILogRepository, LogRepository>();

            #endregion

            #region Context
            services.AddDbContext<BaseDBContext>(options => options.UseMySql(connectionStrings.BaseConnection, ServerVersion.AutoDetect(connectionStrings.BaseConnection)));
            #endregion
        }
    }
}