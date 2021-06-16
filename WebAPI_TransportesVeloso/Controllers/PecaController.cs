using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class PecaController : ApiController
    {
        ApplicationDBContext context;

        public PecaController()
        {
            context = new ApplicationDBContext();
        }

        private static List<Peca> peca = new List<Peca>();

        //GET
        public IHttpActionResult GetPeca(string nome)
        {
            //Declaração de um objeto Peça
            Peca objPeca = new Peca();

            //Pega um único objeto do tipo Peça
            objPeca = this.context.AspNetPeca.Where(x => x.Nome == nome).FirstOrDefault();

            //Declara um lista de objetos do tipo Peça
            List<Peca> lstPeca = new List<Peca>();

            //Se o objPeca for diferente de nulo.
            if (objPeca != null)
            {
                //Adiciona o objeto Peca à lista de Peça
                lstPeca.Add(objPeca);

                //Retorno OK (Código 200)
                return Ok(lstPeca);
            }
            else
                //Se objContrato for nulo, retorna BadRequest (código 500).
                return BadRequest("Nome não encontrada");
        }

        //POST
        public IHttpActionResult PostPeca(string nome, int quantidade, decimal valor)
        {
            try
            {
                Peca objPeca = new Peca();
                objPeca.Nome = nome;
                objPeca.Quantidade = quantidade;
                objPeca.Valor = valor;

                context.AspNetPeca.Add(objPeca);
                context.SaveChanges();

                return Ok("Peça cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar o Peça, entre em contato com o administrador do sistema.");
            }
        }

        //PUT
        public IHttpActionResult PutPeca(string nome, int quantidade, decimal valor)
        {
            try
            {
                Peca objPeca = new Peca();
                objPeca = this.context.AspNetPeca.Where(x => x.Nome == nome).FirstOrDefault();

                if (objPeca != null)
                {
                objPeca.Nome = nome;
                objPeca.Quantidade = quantidade;
                objPeca.Valor = valor;

                    context.SaveChanges();

                    return Ok("Peça alterado com sucesso.");
                }
                else
                {
                    return Ok("Peça não encontrado!");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao alterar a Peça, entre em contato com o administrador do sistema.");
            }
        }

        //DELETE
        public IHttpActionResult DeletePeca(string nome)
        {
            try
            {
                Peca objPeca = new Peca();
                objPeca = this.context.AspNetPeca.Where(x => x.Nome == nome).FirstOrDefault();

                if (objPeca != null)
                {
                    context.AspNetPeca.Remove(objPeca);
                    context.SaveChanges();
                    return Ok("Peça removido com sucesso");
                }
                else
                {
                    return BadRequest("Peça não encontrado.");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao excluir o Peça, entre em contato com o administrador do sistema.");
            }
        }
    }
}
