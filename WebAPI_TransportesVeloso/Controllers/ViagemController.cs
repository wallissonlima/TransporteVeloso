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
        ApplicationDBContext context;

        public ViagemController()
        {
            context = new ApplicationDBContext();
        }

        private static List<Viagem> viagem = new List<Viagem>();

        //GET
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

        //POST

        public IHttpActionResult PostViagem(DateTime dataInicio, DateTime dataFim, int quilometragemInicial, int quilometragemFinal, int idItinerario, int idVeiculo)
        {
            try
            {
                Viagem objViagem = new Viagem();
                objViagem.DataInicio = dataInicio;
                objViagem.DataFim = dataFim;
                objViagem.QuilometragemInicial = quilometragemInicial;
                objViagem.QuilometragemFinal = quilometragemFinal;
                objViagem.IdItinerario = idItinerario;
                objViagem.IdVeiculo = idVeiculo;

                context.AspNetViagem.Add(objViagem);
                context.SaveChanges();

                return Ok("Viagem cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar a Viagem, entre em contato com o administrador do sistema.");
            }
        }

        //PUT
        public IHttpActionResult PutViagem(DateTime dataInicio, DateTime dataFim, int quilometragemInicial, int quilometragemFinal, int idItinerario, int idVeiculo)
        {
            try
            {
                Viagem objViagem = new Viagem();
                objViagem = this.context.AspNetViagem.Where(x => x.DataInicio == dataInicio).FirstOrDefault();

                if (objViagem != null)
                { 
                objViagem.DataInicio = dataInicio;
                objViagem.DataFim = dataFim;
                objViagem.QuilometragemInicial = quilometragemInicial;
                objViagem.QuilometragemFinal = quilometragemFinal;
                objViagem.IdItinerario = idItinerario;
                objViagem.IdVeiculo = idVeiculo;

                context.SaveChanges();

                return Ok("Viagem alterado com sucesso.");
            }
                else
            {
                return Ok("Viagem não encontrado!");
            }
        }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao alterar ao Viagem, entre em contato com o administrador do sistema.");
            }
        }

        //DELETE
        public IHttpActionResult DeleteViagem(DateTime dataInicio)
        {
            try
            {
                Viagem objViagem = new Viagem();
                objViagem = this.context.AspNetViagem.Where(x => x.DataInicio == dataInicio).FirstOrDefault();

                if (objViagem != null)
                {
                    context.AspNetViagem.Remove(objViagem);
                    context.SaveChanges();
                    return Ok("Viagem removida com sucesso");
                }
                else
                {
                    return BadRequest("Viagem não encontrado.");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao excluir ao Viagem, entre em contato com o administrador do sistema.");
            }
        }
    }
}
