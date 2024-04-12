using SimpleEnergy_Log_Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnergy_Log_Domain.Entities
{
    public class Log
    {
        [Column("id_log")]
        public int Id { get; set; }
        [Column("tp_log")]
        public TipoLog TipoLog { get; set; }
        [Column("funcao")]
        public string Funcao { get; set; }
        [Column("descr")]
        public string Descricao { get; set; }
        [Column("dh_ocr")]
        public DateTime DataOcorrencia { get; set; }
        [Column("nm_usu")]
        public string NomeUsuario { get; set; }
    }
}
