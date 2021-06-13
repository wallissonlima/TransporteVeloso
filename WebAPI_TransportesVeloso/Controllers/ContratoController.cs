using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class ContratoController : ApiController
    {
        ApplicationDbContext context;

        public ContratoController()
        {
            context = new ApplicationDbContext();
        }

        private static List<Contrato> contrato = new List<Contrato>();

        public IHttpActionResult GetContrato(string numero)
        {
            //Declaração de um obejeto Contrato
            Contrato objContrato = new Contrato();

            //Pega um único objeto do tipo Contrato
            objContrato = this.context.AspNetContrato.Where(x => x.Numero == numero).FirstOrDefault();

            //Declara um lista de objetos do tipo Contrato
            List<Contrato> lstContrato = new List<Contrato>();

            //Se o objContrato for diferente de nulo.
            if (objContrato != null)
            {
                //Adiciona o objeto Numero à lista de Contrato
                lstContrato.Add(objContrato);

                //Retorno OK (Código 200)
                return Ok(lstContrato);
            }
            else
                //Se objContrato for nulo, retorna BadRequest (código 500).
                return BadRequest("Numero não encontrada");

        }
    }
}
