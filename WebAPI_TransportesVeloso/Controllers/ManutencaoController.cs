using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class ManutencaoController : ApiController
    {
        ApplicationDbContext context;

        public ManutencaoController()
        {
            context = new ApplicationDbContext();
        }

        private static List<Manutencao> manutencao = new List<Manutencao>();

        public IHttpActionResult GetManutencao(DateTime dataManutencao)
        {
            //Declaração de um obejeto Manutencao
            Manutencao objManutencao = new Manutencao();

            //Pega um único objeto do tipo Manutencao
            objManutencao = this.context.AspNetManutencao.Where(x => x.DataManutencao == dataManutencao).FirstOrDefault();

            //Declara um lista de objetos do tipo Manutencao
            List<Manutencao> lstManutencao = new List<Manutencao>();

            //Se o objManutencao for diferente de nulo.
            if (objManutencao != null)
            {
                //Adiciona o objeto Manutencao à lista de Manutencao
                lstManutencao.Add(objManutencao);

                //Retorno OK (Código 200)
                return Ok(lstManutencao);
            }
            else
                //Se objManutencao for nulo, retorna BadRequest (código 500).
                return BadRequest("Manutencao não encontrada");

        }
    }
}
