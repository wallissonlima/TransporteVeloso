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
    [Table("TB_Itinerario")]
    public class Itinerario
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdItinerario { get; set; }
        public string DestinoInicial { get; set; }
        public string DestinoFinal { get; set; }
        public string CaminhoPercorrido { get; set; }
        public string Periodicidade { get; set; }

        #region[Relacionamento 1:N]
        /*Indica ao Entity Framework que existe um relacionamento de 
         1: N entre a entidade Filial e as demais classes abaixo*/
        [JsonIgnore]
        public virtual List<Viagem> Viagem{ get; set; }
        #endregion
    }
}