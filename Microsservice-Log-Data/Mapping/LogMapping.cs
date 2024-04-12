using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleEnergy_Log_Domain.Entities;
using SimpleEnergy_Log_Domain.Enum;

namespace SimpleEnergy_Log_Data.Mapping
{
    public class LogMapping : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("tb_log");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
              .IsRequired()
              .ValueGeneratedOnAdd();

            builder.Property(c => c.TipoLog).HasConversion(
                    v => v.ToString(),
                    v => (TipoLog)Enum.Parse(typeof(TipoLog), v))
                .IsRequired()
                .HasColumnType("varchar(255)");

            builder.Property(x => x.Funcao);
            builder.Property(x => x.Descricao);
            builder.Property(x => x.DataOcorrencia);
            builder.Property(x => x.NomeUsuario);
        }
    }
}
