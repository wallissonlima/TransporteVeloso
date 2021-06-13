using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI_TransportesVeloso.Models
{
    [Table("TB_Consumo")]
    public class Consumo
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdConsumo { get; set; }
        public int Quilometragem { get; set; }
        public DateTime DataAbastecimento { get; set; }
        public Decimal ValorLitroCombustivel { get; set; }
        public Decimal ValorAbastecido { get; set; }
        public int IdVeiculo { get; set; }
    }
}