using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class TipoManutencaoController : ApiController
    {
        ApplicationDBContext context;

        public TipoManutencaoController()
        {
            context = new ApplicationDBContext();
        }

        private static List<TipoManutencao> tipoManutencao = new List<TipoManutencao>();

        //GET
        public IHttpActionResult GetTipoManutencao(string descricao)
        {
            //Declaração de um objeto TipoManutencao
            TipoManutencao objTipoManutencao = new TipoManutencao();

            //Pega um único objeto do tipo Contrato
            objTipoManutencao = this.context.AspNetTipoManutencao.Where(x => x.Descricao == descricao).FirstOrDefault();

            //Declara um lista de objetos do tipo TipoManutencao
            List<TipoManutencao> lstTipoManutencao = new List<TipoManutencao>();

            //Se o objTipoManutencao for diferente de nulo.
            if (objTipoManutencao != null)
            {
                //Adiciona o objeto TipoManutencao à lista de TipoManutencao
                lstTipoManutencao.Add(objTipoManutencao);

                //Retorno OK (Código 200)
                return Ok(lstTipoManutencao);
            }
            else
                //Se objContrato for nulo, retorna BadRequest (código 500).
                return BadRequest("descriçcao não encontrada");
        }

        //POST
        public IHttpActionResult PostTipoManutencao(string descricao)
        {
            try
            {
                TipoManutencao objTipoManutencao = new TipoManutencao();
                objTipoManutencao.Descricao = descricao;

                context.AspNetTipoManutencao.Add(objTipoManutencao);
                context.SaveChanges();

                return Ok("TipoManutencao cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar o TipoManutencao, entre em contato com o administrador do sistema.");
            }
        }

        //PUT
        public IHttpActionResult PutTipoManutencao(string descricao)
        {
            try
            {
                TipoManutencao objTipoManutencao = new TipoManutencao();
                objTipoManutencao = this.context.AspNetTipoManutencao.Where(x => x.Descricao == descricao).FirstOrDefault();

                if (objTipoManutencao != null)
                {
                    objTipoManutencao.Descricao = descricao;

                    context.SaveChanges();

                    return Ok("TipoManutencao alterado com sucesso.");
                }
                else
                {
                    return Ok("TipoManutencaoo não encontrado!");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao alterar o TipoManutencao, entre em contato com o administrador do sistema.");
            }
        }

        //DELETE
        public IHttpActionResult DeleteTipoManutencao(string descricao)
        {
            try
            {
                TipoManutencao objTipoManutencao = new TipoManutencao();
                objTipoManutencao = this.context.AspNetTipoManutencao.Where(x => x.Descricao == descricao).FirstOrDefault();

                if (objTipoManutencao != null)
                {
                    context.AspNetTipoManutencao.Remove(objTipoManutencao);
                    context.SaveChanges();
                    return Ok("TipoManutencao removido com sucesso");
                }
                else
                {
                    return BadRequest("TipoManutencao não encontrado.");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao excluir o TipoManutencao, entre em contato com o administrador do sistema.");
            }
        }
    }
}
