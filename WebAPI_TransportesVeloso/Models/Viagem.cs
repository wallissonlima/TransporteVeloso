using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_TransportesVeloso.Models
{
    public class Viagem
    {
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