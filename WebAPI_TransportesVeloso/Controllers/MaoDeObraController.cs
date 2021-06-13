using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class MaoDeObraController : ApiController
    {
        ApplicationDbContext context;

        public MaoDeObraController()
        {
            context = new ApplicationDbContext();
        }

        private static List<MaoDeObra> maoDeObra = new List<MaoDeObra>();

        public IHttpActionResult GetMaoDeObra(string descricao)
        {
            //Declaração de um obejeto MaoDeObra
            MaoDeObra objMaoDeObra = new MaoDeObra();

            //Pega um único objeto do tipo Contrato
            objMaoDeObra = this.context.AspNetMaoDeObra.Where(x => x.Descricao == descricao).FirstOrDefault();

            //Declara um lista de objetos do tipo MaoDeObra
            List<MaoDeObra> lstMaoDeObra = new List<MaoDeObra>();

            //Se o objContrato for diferente de nulo.
            if (objMaoDeObra != null)
            {
                //Adiciona o objeto MaoDeObra à lista de MaoDeObra
                lstMaoDeObra.Add(objMaoDeObra);

                //Retorno OK (Código 200)
                return Ok(lstMaoDeObra);
            }
            else
                //Se objMaoDeObra for nulo, retorna BadRequest (código 500).
                return BadRequest("Descriçao não encontrada");

        }
    }
}
