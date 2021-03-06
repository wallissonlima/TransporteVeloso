using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class ContratoController : ApiController
    {
        ApplicationDBContext context;

        public ContratoController()
        {
            context = new ApplicationDBContext();
        }

        private static List<Contrato> contrato = new List<Contrato>();

        //GET
        public IHttpActionResult GetContrato(string numero)
        {
            //Declaração de um objeto Contrato
            Contrato objContrato = new Contrato();

            //Pega um único objeto do tipo Contrato
            objContrato = this.context.AspNetContrato.Where(x => x.Numero == numero).FirstOrDefault();

            //Declara um lista de objetos do tipo Contrato
            List<Contrato> lstContrato = new List<Contrato>();

            //Se o objContrato for diferente de nulo.
            if (objContrato != null)
            {
                //Adiciona o objeto Numero à lista de Contrato
                lstContrato.Add(objContrato);

                //Retorno OK (Código 200)
                return Ok(lstContrato);
            }
            else
                //Se objContrato for nulo, retorna BadRequest (código 500).
                return BadRequest("Numero não encontrada");

        }

        //POST
        public IHttpActionResult PostContrato(string numero, Decimal valor, DateTime dataAssinatura, DateTime dataTermino, string descricao, byte? arquivo)
        {
            try
            {
                Contrato objContrato = new Contrato();
                objContrato.Numero = numero;
                objContrato.Valor = valor;
                objContrato.DataAssinatura = dataAssinatura;
                objContrato.DataTermino = dataTermino;
                objContrato.Descricao = descricao;

                if (arquivo != null)
                    objContrato.Arquivo = arquivo;
                else
                    objContrato.Arquivo = null;

                context.AspNetContrato.Add(objContrato);
                context.SaveChanges();

                return Ok("Contrato cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar o Contrato, entre em contato com o administrador do sistema.");
            }
        }

        //PUT
        public IHttpActionResult PutContrato(string numero, Decimal valor, DateTime dataAssinatura, DateTime dataTermino, string descricao, byte? arquivo)
        {
            try
            {
                Contrato objContrato = new Contrato();
                objContrato = this.context.AspNetContrato.Where(x => x.Numero == numero).FirstOrDefault();

                if (objContrato != null)
                {
                    objContrato.Numero = numero;
                    objContrato.Valor = valor;
                    objContrato.DataAssinatura = dataAssinatura;
                    objContrato.DataTermino = dataTermino;
                    objContrato.Descricao = descricao;
                }
                    if (arquivo != null)
                        objContrato.Arquivo = arquivo;
                    else
                        objContrato.Arquivo = null;

                    context.SaveChanges();

                    return Ok("Contrato cadastrado com sucesso");
                }
            
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar o Contrato, entre em contato com o administrador do sistema.");
            }
        }

        //DELETE
        public IHttpActionResult DeleteContrato(string numero)
        {
            try
            {
                Contrato objContrato = new Contrato();
                objContrato = this.context.AspNetContrato.Where(x => x.Numero == numero).FirstOrDefault();

                if (objContrato != null)
                {
                    context.AspNetContrato.Remove(objContrato);
                    context.SaveChanges();
                    return Ok("Contrato removido com sucesso");
                }
                else
                {
                    return BadRequest("Contrato não encontrado.");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao excluir o Contrato, entre em contato com o administrador do sistema.");
            }
        }
    }
}
