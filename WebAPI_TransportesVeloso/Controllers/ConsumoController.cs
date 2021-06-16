using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class ConsumoController : ApiController
    {
        ApplicationDBContext context;

        public ConsumoController()
        {
            context = new ApplicationDBContext();
        }

        private static List<Consumo> consumo = new List<Consumo>();

        //GET
        public IHttpActionResult GetConsumo(int quilometragem)
        {
            //Declaração de um objeto consumo
            Consumo objConsumo = new Consumo();

            //Pega um único objeto do tipo consumo
            objConsumo = this.context.AspNetConsumo.Where(x => x.Quilometragem == quilometragem).FirstOrDefault();

            //Declara um lista de objetos do tipo consumo
            List<Consumo> lstConsumo = new List<Consumo>();

            //Se o objConsumo for diferente de nulo.
            if (objConsumo != null)
            {
                //Adiciona o objeto veículo à lista de consumo
                lstConsumo.Add(objConsumo);

                //Retorno OK (ódigo 200)
                return Ok(lstConsumo);
            }
            else
                //Se objConsumo for nulo, retorna BadRequest (código 500).
                return BadRequest("Quilometragem não encontrada");
        }

        //POST
        public IHttpActionResult PostConsumo(int quilometragem, DateTime dataAbastecimento, decimal valorLitroCombustivel, decimal valorAbastecido, int idVeiculo)
        {
            try
            {
                Consumo objConsumo = new Consumo();
                objConsumo.Quilometragem = quilometragem;
                objConsumo.DataAbastecimento = dataAbastecimento;
                objConsumo.ValorLitroCombustivel = valorLitroCombustivel;
                objConsumo.ValorAbastecido = valorAbastecido;
                objConsumo.IdVeiculo = idVeiculo;

                context.AspNetConsumo.Add(objConsumo);
                context.SaveChanges();

                return Ok("Consumo cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar o Consumo, entre em contato com o administrador do sistema.");
            }
        }

        //PUT
        public IHttpActionResult PutConsumo(int quilometragem, DateTime dataAbastecimento, decimal valorLitroCombustivel, decimal valorAbastecido, int idVeiculo)
        {
            try
            {
                Consumo objConsumo = new Consumo();
                objConsumo = this.context.AspNetConsumo.Where(x => x.Quilometragem == quilometragem).FirstOrDefault();

                if (objConsumo != null)
                { 
                objConsumo.Quilometragem = quilometragem;
                objConsumo.DataAbastecimento = dataAbastecimento;
                objConsumo.ValorLitroCombustivel = valorLitroCombustivel;
                objConsumo.ValorAbastecido = valorAbastecido;
                objConsumo.IdVeiculo = idVeiculo;

                context.SaveChanges();

                return Ok("Consumo alterado com sucesso");
                }
                else
                {
                    return Ok("Veículo não encontrado!");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar o Consumo, entre em contato com o administrador do sistema.");
            }
        }

        //DELETE
        public IHttpActionResult DeleteConsumo(int quilometragem)
        {
            try
            {
                Consumo objConsumo = new Consumo();
                objConsumo = this.context.AspNetConsumo.Where(x => x.Quilometragem == quilometragem).FirstOrDefault();

                if (objConsumo != null)
                {
                    context.AspNetConsumo.Remove(objConsumo);
                    context.SaveChanges();
                    return Ok("Consumo removido com sucesso");
                }
                else
                {
                    return BadRequest("Consumo não encontrado.");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao excluir o Consumo, entre em contato com o administrador do sistema.");
            }
        }
    }
}
