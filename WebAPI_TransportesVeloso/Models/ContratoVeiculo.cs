using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_TransportesVeloso.Models
{
    public class ContratoVeiculo
    {
        public int IdContratoVeiculo { get; set; }
        public int IdContrato { get; set; }
        public int IdVeiculo { get; set; }

    }
}