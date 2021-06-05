using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_TransportesVeloso.Models
{
    public class Consumo
    {
        public int IdConsumo { get; set; }
        public int Quilometragem { get; set; }
        public DateTime DatAbastecimento { get; set; }
        public Decimal ValorLitroCombustivel { get; set; }
        public Decimal ValorAbastecido { get; set; }
        public int IdVeiculo { get; set; }
    }
}