using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class TipoManutencaoController : ApiController
    {
        ApplicationDBContext context;

        public TipoManutencaoController()
        {
            context = new ApplicationDBContext();
        }

        private static List<TipoManutencao> tipoManutencao = new List<TipoManutencao>();

        public IHttpActionResult GetTipoManutencao(string descricao)
        {
            //Declaração de um objeto TipoManutencao
            TipoManutencao objTipoManutencao = new TipoManutencao();

            //Pega um único objeto do tipo Contrato
            objTipoManutencao = this.context.AspNetTipoManutencao.Where(x => x.Descricao == descricao).FirstOrDefault();

            //Declara um lista de objetos do tipo TipoManutencao
            List<TipoManutencao> lstTipoManutencao = new List<TipoManutencao>();

            //Se o objTipoManutencao for diferente de nulo.
            if (objTipoManutencao != null)
            {
                //Adiciona o objeto TipoManutencao à lista de TipoManutencao
                lstTipoManutencao.Add(objTipoManutencao);

                //Retorno OK (Código 200)
                return Ok(lstTipoManutencao);
            }
            else
                //Se objContrato for nulo, retorna BadRequest (código 500).
                return BadRequest("descriçcao não encontrada");

        }
    }
}
