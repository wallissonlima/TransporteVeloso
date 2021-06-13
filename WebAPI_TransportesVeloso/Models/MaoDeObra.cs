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
    [Table("TB_Mao_De_Obra")]
    public class MaoDeObra
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMaoDeObra { get; set; }
        public string Descricao { get; set; }
        public Decimal Valor { get; set; }

        #region[Relacionamento 1:N]
        /*Indica ao Entity Framework que existe um relacionamento de 
         1: N entre a entidade Filial e as demais classes abaixo*/
        [JsonIgnore]
        public virtual List<Manutencao> Manutencao { get; set; }
        #endregion
    }
}