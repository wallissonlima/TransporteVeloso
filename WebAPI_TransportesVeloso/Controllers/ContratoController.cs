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
        ApplicationDBContext context;

        public ContratoController()
        {
            context = new ApplicationDBContext();
        }

        private static List<Contrato> contrato = new List<Contrato>();

        public IHttpActionResult GetContrato(string numero)
        {
            //Declaração de um objeto Contrato
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

        public IHttpActionResult PostContrato(int idContrato, string numero, Decimal valor, DateTime dataAssinatura, DateTime dataTermino, string descricao, Byte? arquivo = null)
        {

            return Ok("OK");
        }

        public IHttpActionResult PutContrato(int idContrato, string numero, Decimal valor, DateTime dataAssinatura, DateTime dataTermino, string descricao, Byte? arquivo = null)
        {

            return Ok("OK");
        }

        public IHttpActionResult DeleteContrato(string numero)
        {
            //Declaração de um objeto Contrato
            Contrato objContrato = new Contrato();

            //Pega um único objeto do tipo Contrato
            objContrato = this.context.AspNetContrato.Where(x => x.Numero == numero).FirstOrDefault();

            //Declara um lista de objetos do tipo Contrato
            List<Contrato> lstContrato = new List<Contrato>();

            //Se o objContrato for diferente de nulo.
            if (objContrato != null)
            {
                //Adiciona o objeto Numero à lista de Contrato
                lstContrato.Remove(objContrato);

                //Retorno OK (Código 200)
                return Ok(lstContrato);
            }
            else
                //Se objContrato for nulo, retorna BadRequest (código 500).
                return BadRequest("Numero não encontrada");
        }
    }
}
