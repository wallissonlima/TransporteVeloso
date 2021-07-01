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
        ApplicationDBContext context;

        public ManutencaoController()
        {
            context = new ApplicationDBContext();
        }

        private static List<Manutencao> manutencao = new List<Manutencao>();

        //GETAll
        public IHttpActionResult GetAll()
        {
            try
            {
                //Declaração de um objeto Veículo
                List<Manutencao> lstManutencao = new List<Manutencao>();
                lstManutencao = context.AspNetManutencao.ToList();


                //Retorno ok (código 200)
                return Ok(lstManutencao);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao pesquisar o manutencão. , entre em contato com o administrador do sistema.");
                throw;
            }
        }

        //GET
        public IHttpActionResult GetManutencao(DateTime dataManutencao, int idManutencao = 0)
        {
            try { 
            //Declaração de um objeto Manutencao
            Manutencao objManutencao = new Manutencao();

            //Pega um único objeto do tipo Manutencao
            if (!string.ConvertToDateTime(dataManutencao))
               objManutencao = this.context.AspNetManutencao.Where(x => x.DataManutencao == dataManutencao).FirstOrDefault();
            else if (idManutencao != 0)
               objManutencao = this.context.AspNetManutencao.Where(x => x.IdManutencao == idManutencao).FirstOrDefault();

                //Declara uma lista de objetos do tipo Manutencao
                List<Manutencao> lstManutencao = new List<Manutencao>();

            //Se o objVeiculo for diferente de nulo.
            if (objManutencao != null)
                    //Adiciona o objeto veículo à lista de Manutencao
                    lstManutencao.Add(objManutencao);

            return Ok(lstManutencao);
        }
            catch (Exception ex)
            {
                return BadRequest("Erro ao pesquisar o manutenção. , entre em contato com o administrador do sistema.");
                throw;
            }
        }

//PUT
public IHttpActionResult PutManutencao(DateTime dataManutencao, decimal valorManutencao, string descricao, int idTipoManutencao, int idPeca, int idMaoDeObra, int idVeiculo )
        {
            try
            {
                Manutencao objManutencao = new Manutencao();
                objManutencao.DataManutencao = dataManutencao;
                objManutencao.ValorManutencao = valorManutencao;
                objManutencao.Descricao = descricao;
                objManutencao.IdTipoManutencao = idTipoManutencao;
                objManutencao.IdPeca = idPeca;
                objManutencao.IdMaoDeObra = idMaoDeObra;
                objManutencao.IdVeiculo = idVeiculo;

                context.AspNetManutencao.Add(objManutencao);
                context.SaveChanges();

                return Ok("Manutencao cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar o Manutencao, entre em contato com o administrador do sistema.");
            }
        }

        //POST
        public IHttpActionResult PostManutencao(DateTime dataManutencao, decimal valorManutencao, string descricao, int idTipoManutencao, int idPeca, int idMaoDeObra, int idVeiculo)
        {
            try
            {
                Manutencao objManutencao = new Manutencao();
                objManutencao = this.context.AspNetManutencao.Where(x => x.DataManutencao == dataManutencao).FirstOrDefault();

                if (objManutencao != null)
                {
                objManutencao.DataManutencao = dataManutencao;
                objManutencao.ValorManutencao = valorManutencao;
                objManutencao.Descricao = descricao;
                objManutencao.IdTipoManutencao = idTipoManutencao;
                objManutencao.IdPeca = idPeca;
                objManutencao.IdMaoDeObra = idMaoDeObra;
                objManutencao.IdVeiculo = idVeiculo;

                    context.SaveChanges();

                    return Ok("Manutencao alterado com sucesso.");
                }
                else
                {
                    return Ok("Manutencao não encontrado!");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao alterar a Manutencao, entre em contato com o administrador do sistema.");
            }
        }

        //DELETE
        public IHttpActionResult DeleteManutencao(DateTime dataManutencao)
        {
            try
            {
                Manutencao objManutencao = new Manutencao();
                objManutencao = this.context.AspNetManutencao.Where(x => x.DataManutencao == dataManutencao).FirstOrDefault();

                if (objManutencao != null)
                {
                    context.AspNetManutencao.Remove(objManutencao);
                    context.SaveChanges();
                    return Ok("Manutençao removido com sucesso");
                }
                else
                {
                    return BadRequest("Manutençao não encontrado.");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao excluir a Manutençao, entre em contato com o administrador do sistema.");
            }
        }
    }
}
