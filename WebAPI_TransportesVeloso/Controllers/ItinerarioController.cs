using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class ItinerarioController : ApiController
    {
        ApplicationDbContext context;

        public ItinerarioController()
        {
            context = new ApplicationDbContext();
        }

        private static List<Itinerario> itinerario = new List<Itinerario>();

        public IHttpActionResult GetItinerario(string destinoInicial)
        {
            //Declaração de um obejeto Contrato
            Itinerario objItinerario = new Itinerario();

            //Pega um único objeto do tipo Contrato
            objItinerario = this.context.AspNetItinerario.Where(x => x.DestinoInicial == destinoInicial).FirstOrDefault();

            //Declara um lista de objetos do tipo Contrato
            List<Itinerario> lstItinerario = new List<Itinerario>();

            //Se o objContrato for diferente de nulo.
            if (objItinerario != null)
            {
                //Adiciona o objeto Numero à lista de Contrato
                lstItinerario.Add(objItinerario);

                //Retorno OK (Código 200)
                return Ok(lstItinerario);
            }
            else
                //Se objContrato for nulo, retorna BadRequest (código 500).
                return BadRequest("Numero não encontrada");

        }
    }
}
