using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class PecaController : ApiController
    {
        ApplicationDBContext context;

        public PecaController()
        {
            context = new ApplicationDBContext();
        }

        private static List<Peca> peca = new List<Peca>();

        public IHttpActionResult GetPeca(string nome)
        {
            //Declaração de um objeto Peça
            Peca objPeca = new Peca();

            //Pega um único objeto do tipo Peça
            objPeca = this.context.AspNetPeca.Where(x => x.Nome == nome).FirstOrDefault();

            //Declara um lista de objetos do tipo Peça
            List<Peca> lstPeca = new List<Peca>();

            //Se o objPeca for diferente de nulo.
            if (objPeca != null)
            {
                //Adiciona o objeto Peca à lista de Peça
                lstPeca.Add(objPeca);

                //Retorno OK (Código 200)
                return Ok(lstPeca);
            }
            else
                //Se objContrato for nulo, retorna BadRequest (código 500).
                return BadRequest("Nome não encontrada");

        }
    }
}
