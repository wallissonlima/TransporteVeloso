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
        ApplicationDBContext context;

        public ItinerarioController()
        {
            context = new ApplicationDBContext();
        }

        private static List<Itinerario> itinerario = new List<Itinerario>();

        //GET
        public IHttpActionResult GetItinerario(string destinoInicial)
        {
            //Declaração de um objeto Contrato
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

        //POST
        public IHttpActionResult PostItinerario(string destinoInicial, string destinoFinal, string caminhoPercorrido, string periodicidade)
        {
            try
            {
                Itinerario objItinerario = new Itinerario();
                objItinerario.DestinoInicial = destinoInicial;
                objItinerario.DestinoFinal = destinoFinal;
                objItinerario.CaminhoPercorrido = caminhoPercorrido;
                objItinerario.Periodicidade = periodicidade;

                context.AspNetItinerario.Add(objItinerario);
                context.SaveChanges();

                return Ok("Itinerario cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar o Itinerario, entre em contato com o administrador do sistema.");
            }
        }

        //PUT
        public IHttpActionResult PutItinerario(string destinoInicial, string destinoFinal, string caminhoPercorrido, string periodicidade)
        {
            try
            {
                Itinerario objItinerario = new Itinerario();
                objItinerario = this.context.AspNetItinerario.Where(x => x.DestinoInicial == destinoInicial).FirstOrDefault();

                if (objItinerario != null)
                {
                objItinerario.DestinoInicial = destinoInicial;
                objItinerario.DestinoFinal = destinoFinal;
                objItinerario.CaminhoPercorrido = caminhoPercorrido;
                objItinerario.Periodicidade = periodicidade;

                    context.SaveChanges();

                    return Ok("Itinerario alterado com sucesso.");
                }
                else
                {
                    return Ok("Itinerario não encontrado!");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao alterar o Itinerario, entre em contato com o administrador do sistema.");
            }
        }

        //DELETE
        public IHttpActionResult DeleteItinerario(string destinoInicial)
        {
            try
            {
                Itinerario objItinerario = new Itinerario();
                objItinerario = this.context.AspNetItinerario.Where(x => x.DestinoInicial == destinoInicial).FirstOrDefault();

                if (objItinerario != null)
                {
                    context.AspNetItinerario.Remove(objItinerario);
                    context.SaveChanges();
                    return Ok("Itinerario removido com sucesso");
                }
                else
                {
                    return BadRequest("Itinerario não encontrado.");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao excluir o Itinerario, entre em contato com o administrador do sistema.");
            }
        }
    }
}
