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
    public class Peca
    {
        public int IdPeca { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public Decimal Valor { get; set; }

        #region[Relacionamento 1:N]
        /*Indica ao Entity Framework que existe um relacionamento de 
         1: N entre a entidade Filial e as demais classes abaixo*/
        [JsonIgnore]
        public virtual List<Manutencao> Manutencao { get; set; }
        #endregion

    }
}