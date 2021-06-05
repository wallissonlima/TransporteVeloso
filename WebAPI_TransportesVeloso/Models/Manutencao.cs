using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI_TransportesVeloso.Models
{
    public class Manutencao
    {
        public int IdManutencao { get; set}
        public DateTime DataManutencao { get; set; } 
        public Decimal ValorManutencao { get; set; }
        public string Descricao { get; set; }
        public int IdTipoManutencao { get; set; }
        public int IdPeca { get; set; }
        public int IdMaoDeObra { get; set; }
        public int IdVeiculo { get; set; }
    }
}