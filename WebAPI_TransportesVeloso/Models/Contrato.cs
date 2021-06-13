using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WebAPI_TransportesVeloso.Models
{
    [Table("TB_Contrato")]
    public class Contrato
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContrato { get; set; }
        public string Numero { get; set; }
        public Decimal Valor { get; set; }
        public DateTime DataAssinatura { get; set; }
        public DateTime DataTermino { get; set; }
        public string Descricao { get; set; }
        public Byte Arquivo { get; set; }

        //[ForeignKey("Hidrometro")]
        //public int IdContratoVeiculo { get; set; }

        #region[Relacionamento 1:N]
        /*Indica ao Entity Framework que existe um relacionamento de 
         1: N entre a entidade Filial e as demais classes abaixo*/
        [JsonIgnore]
        public virtual List<ContratoVeiculo> ContratoVeiculo { get; set; }
        #endregion
    }
}
