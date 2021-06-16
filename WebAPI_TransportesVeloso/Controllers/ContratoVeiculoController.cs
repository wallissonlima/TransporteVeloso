using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

// Teste

namespace WebAPI_TransportesVeloso.Controllers
{
    public class ContratoVeiculoController : ApiController
    {
        ApplicationDbContext context;

        public ContratoVeiculoController()
        {
            context = new ApplicationDbContext();
        }

        private static List<ContratoVeiculo> contrato = new List<ContratoVeiculo>();

        public IHttpActionResult GetContrato(int idContrato)
        {
            //Declaração de um obejeto ContratoVeiculo
            ContratoVeiculo objContratoVeiculo = new ContratoVeiculo();

            //Pega um único objeto do tipo ContratoVeiculo
            objContratoVeiculo = this.context.AspNetContratoVeiculo.Where(x => x.IdContrato == idContrato).FirstOrDefault();

            //Declara um lista de objetos do tipo ContratoVeiculo
            List<ContratoVeiculo> lstContratoVeiculo = new List<ContratoVeiculo>();

            //Se o objContratoVeiculo for diferente de nulo.
            if (objContratoVeiculo != null)
            {
                //Adiciona o objeto ContratoVeiculo à lista de ContratoVeiculo
                lstContratoVeiculo.Add(objContratoVeiculo);

                //Retorno OK (Código 200)
                return Ok(lstContratoVeiculo);
            }
            else
                //Se objContratoVeiculo for nulo, retorna BadRequest (código 500).
                return BadRequest("IdContrato não encontrada");

        }
    }
}
