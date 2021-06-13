using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebAPI_TransportesVeloso.Models
{
    [Table("TB_Viagem")]
    public class Viagem
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdViagem { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public int QuilometragemInicial { get; set; }
        public int QuilometragemFinal { get; set; }
        public int IdItinerario { get; set; }
        public int IdVeiculo { get; set; }


        //TESTE DE MODEL
    }
}