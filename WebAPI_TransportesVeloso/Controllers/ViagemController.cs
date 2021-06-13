using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class ViagemController : ApiController
    {
        ApplicationDbContext context;

        public ViagemController()
        {
            context = new ApplicationDbContext();
        }

        private static List<Viagem> viagem = new List<Viagem>();

        public IHttpActionResult GetViagem(DateTime dataInicio)
        {

            //Declaração de um objeto Viagem
            Viagem objViagem = new Viagem();

            //Pega um único objeto viagem pela datainicio
            objViagem = this.context.AspNetViagem.Where(x => x.DataInicio == dataInicio).FirstOrDefault();

            //Declara uma lista de objetos do tipo viagem
            List<Viagem> lstViagem = new List<Viagem>();

            //Se o objViagem for diferente de nulo.
            if (objViagem != null)
            {
                //Adiciona o objeto viagem à lista de viagem
                lstViagem.Add(objViagem);

                //Retorno ok (código 200)
                return Ok(lstViagem);
            }
            else
                //Se o objViagem for nulo, retorna BadRequest (código 500).
                return BadRequest("Viagem não encontrada");
        }
    }
}
