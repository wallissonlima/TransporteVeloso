using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class ContratoVeiculoController : ApiController
    {
        ApplicationDBContext context;

        public ContratoVeiculoController()
        {
            context = new ApplicationDBContext();
        }

        private static List<ContratoVeiculo> contrato = new List<ContratoVeiculo>();

        //GET
        public IHttpActionResult GetContrato(int idContrato)
        {
            //Declaração de um obejeto ContratoVeiculo
            ContratoVeiculo objContratoVeiculo = new ContratoVeiculo();

            //Pega um único objeto do tipo ContratoVeiculo
            objContratoVeiculo = this.context.AspNetContratoVeiculo.Where(x => x.IdContrato == idContrato).FirstOrDefault();

            //Declara um lista de objetos do tipo ContratoVeiculo
            List<ContratoVeiculo> lstContratoVeiculo = new List<ContratoVeiculo>();

            //Se o objContratoVeiculo for diferente de nulo.
            if (objContratoVeiculo != null)
            {
                //Adiciona o objeto ContratoVeiculo à lista de ContratoVeiculo
                lstContratoVeiculo.Add(objContratoVeiculo);

                //Retorno OK (Código 200)
                return Ok(lstContratoVeiculo);
            }
            else
                //Se objContratoVeiculo for nulo, retorna BadRequest (código 500).
                return BadRequest("IdContrato não encontrada");
        }

        //POST
        public IHttpActionResult PostContratoVeiculo(int idContrato, int idVeiculo)
        {
            try
            {
                ContratoVeiculo objContratoVeiculo = new ContratoVeiculo();
                objContratoVeiculo.IdContrato = idContrato;
                objContratoVeiculo.IdVeiculo = idVeiculo;
               

                context.AspNetContratoVeiculo.Add(objContratoVeiculo);
                context.SaveChanges();

                return Ok("ContratoVeiculo cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar o ContratoVeiculo, entre em contato com o administrador do sistema.");
            }
        }

        //PUT
        public IHttpActionResult PutContratoVeiculo(int idContrato, int idVeiculo)
        {
            try
            {
                ContratoVeiculo objContratoVeiculo = new ContratoVeiculo();
                objContratoVeiculo = this.context.AspNetContratoVeiculo.Where(x => x.IdContrato == idContrato).FirstOrDefault();

                if (objContratoVeiculo != null)
                {
                objContratoVeiculo.IdContrato = idContrato;
                objContratoVeiculo.IdVeiculo = idVeiculo;

                    context.SaveChanges();

                    return Ok("ContratoVeiculo alterado com sucesso.");
                }
                else
                {
                    return Ok("ContratoVeiculo não encontrado!");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao alterar o ContratoVeiculo, entre em contato com o administrador do sistema.");
            }
        }

        //DELETE
        public IHttpActionResult DeleteContratoVeiculo(int idContrato)
        {
            try
            {
                ContratoVeiculo objContratoVeiculo = new ContratoVeiculo();
                objContratoVeiculo = this.context.AspNetContratoVeiculo.Where(x => x.IdContrato == idContrato).FirstOrDefault();

                if (objContratoVeiculo != null)
                {
                    context.AspNetContratoVeiculo.Remove(objContratoVeiculo);
                    context.SaveChanges();
                    return Ok("ContratoVeiculo removido com sucesso");
                }
                else
                {
                    return BadRequest("ContratoVeiculo não encontrado.");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao excluir o ContratoVeiculo, entre em contato com o administrador do sistema.");
            }
        }
    }
}
