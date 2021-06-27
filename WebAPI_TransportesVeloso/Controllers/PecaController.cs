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
        public IHttpActionResult GetAll()
        {
            try
            {

                //Declaração de um objeto Peça
                List<Peca> lstPeca = new List<Peca>();
                lstPeca = context.AspNetPeca.ToList();


                //Retorno ok (código 200)
                return Ok(lstPeca);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao pesquisar o peca. , entre em contato com o administrador do sistema.");
                throw;
            }
        }

        //GET
        public IHttpActionResult GetPeca(string nome = null, int idPeca = 0)
        {
            try { 
            //Declaração de um objeto Peça
            Peca objPeca = new Peca();

                //Pega um único objeto do tipo Peça
                if (!string.IsNullOrWhiteSpace(nome))
                    objPeca = this.context.AspNetPeca.Where(x => x.Nome == nome).FirstOrDefault();
                else if (idPeca != 0)
                    objPeca = this.context.AspNetPeca.Where(x => x.IdPeca == idPeca).FirstOrDefault();

                //Declara uma lista de objetos do tipo Peca
                List<Peca> lstPeca = new List<Peca>();

                //Se o objPeca for diferente de nulo.
                if (objPeca != null)
                    //Adiciona o objeto veículo à lista de Peca
                    lstPeca.Add(objPeca);

                return Ok(lstPeca);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao pesquisar o peça. , entre em contato com o administrador do sistema.");
                throw;
            }
        }

        //POST
        public IHttpActionResult PutPeca(string nome, int quantidade, decimal valor)
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
        public IHttpActionResult PostPeca(int idPeca, string nome, int quantidade, decimal valor)
        {
            try
            {
                Peca objPeca = new Peca();
                objPeca = this.context.AspNetPeca.Where(x => x.IdPeca == idPeca).FirstOrDefault();

                if (objPeca != null)
                {
                objPeca.IdPeca = idPeca;
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
        public IHttpActionResult DeletePeca(string nome = null, int idPeca = 0)
        {
            try
            {
                Peca objPeca = new Peca();

                if (!string.IsNullOrWhiteSpace(nome))
                    objPeca = this.context.AspNetPeca.Where(x => x.Nome == nome).FirstOrDefault();
                else if (idPeca != 0)
                    objPeca = this.context.AspNetPeca.Where(x => x.IdPeca == idPeca).FirstOrDefault();

                if (objPeca != null)
                {
                    context.AspNetPeca.Remove(objPeca);
                    context.SaveChanges();
                    return Ok(true);
                }
                else
                {
                    return Ok(false);
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao excluir o peça, entre em contato com o administrador do sistema.");
            }
        }
    }
}
