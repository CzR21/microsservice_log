using Newtonsoft.Json;
using SimpleEnergy_Log_Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleEnergy_Log_Domain.Models
{
    public class LogModel
    {
        [JsonProperty("tipoLog")]
        public string TipoLog { get; set; }
        [JsonProperty("funcao")]
        public string Funcao { get; set; }
        [JsonProperty("descricao")]
        public string Descricao { get; set; }
        [JsonProperty("nomeUsuario")]
        public string NomeUsuario { get; set; }
    }
}
