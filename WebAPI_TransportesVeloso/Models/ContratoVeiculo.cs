using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI_TransportesVeloso.Models
{
    [Table("RL_Contrato_Veiculo")]
    public class ContratoVeiculo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdContratoVeiculo { get; set; }
        public int IdContrato { get; set; }
        public int IdVeiculo { get; set; }

    }
}