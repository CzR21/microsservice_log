using Microsoft.EntityFrameworkCore;
using SimpleEnergy_Log_Data.Mapping;
using SimpleEnergy_Log_Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnergy_Log_Infrastructure.Context
{
    public class BaseDBContext : DbContext
    {
        public BaseDBContext(DbContextOptions<BaseDBContext> options) : base(options) { }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LogMapping());
        }
    }
}
