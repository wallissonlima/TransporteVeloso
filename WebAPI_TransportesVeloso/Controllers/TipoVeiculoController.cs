using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class TipoVeiculoController : ApiController
    {
        ApplicationDBContext context;

        public TipoVeiculoController()
        {
            context = new ApplicationDBContext();
        }

        private static List<TipoVeiculo> tipoVeiculo = new List<TipoVeiculo>();

        //GET
        public IHttpActionResult GetTipoVeiculo(string descricao)
        {
            //Declaração de um objeto TipoVeiculo
            TipoVeiculo objTipoVeiculo = new TipoVeiculo();

            //Pega um único objeto do tipo TipoVeiculo
            objTipoVeiculo = this.context.AspNetTipoVeiculo.Where(x => x.Descricao == descricao).FirstOrDefault();

            //Declara um lista de objetos do tipo TipoVeiculo
            List<TipoVeiculo> lstTipoVeiculo = new List<TipoVeiculo>();

            //Se o objTipoVeiculo for diferente de nulo.
            if (objTipoVeiculo != null)
            {
                //Adiciona o objeto TipoVeiculo à lista de TipoVeiculo
                lstTipoVeiculo.Add(objTipoVeiculo);

                //Retorno OK (Código 200)
                return Ok(lstTipoVeiculo);
            }
            else
                //Se objContrato for nulo, retorna BadRequest (código 500).
                return BadRequest("Descrição não encontrada");
        }

        //POST
        public IHttpActionResult PostTipoVeiculo(string descricao)
        {
            try
            {
                TipoVeiculo objTipoVeiculo = new TipoVeiculo();
                objTipoVeiculo.Descricao = descricao;

                context.AspNetTipoVeiculo.Add(objTipoVeiculo);
                context.SaveChanges();

                return Ok("TipoVeiculo cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar o TipoVeiculo, entre em contato com o administrador do sistema.");
            }
        }

        //PUT
        public IHttpActionResult PutTipoVeiculo(string descricao)
        {
            try
            {
                TipoVeiculo objTipoVeiculo = new TipoVeiculo();
                objTipoVeiculo = this.context.AspNetTipoVeiculo.Where(x => x.Descricao == descricao).FirstOrDefault();

                if (objTipoVeiculo != null)
                {
                    objTipoVeiculo.Descricao = descricao;

                    context.SaveChanges();

                    return Ok("TipoVeiculo alterado com sucesso.");
                }
                else
                {
                    return Ok("TipoVeiculo não encontrado!");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao alterar o TipoVeiculo, entre em contato com o administrador do sistema.");
            }
        }

        //DELETE
        public IHttpActionResult DeleteTipoVeiculo(string descricao)
        {
            try
            {
                TipoVeiculo objTipoVeiculo = new TipoVeiculo();
                objTipoVeiculo = this.context.AspNetTipoVeiculo.Where(x => x.Descricao== descricao).FirstOrDefault();

                if (objTipoVeiculo != null)
                {
                    context.AspNetTipoVeiculo.Remove(objTipoVeiculo);
                    context.SaveChanges();
                    return Ok("TipoVeiculo removido com sucesso");
                }
                else
                {
                    return BadRequest("TipoVeiculo não encontrado.");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao excluir o TipoVeiculo, entre em contato com o administrador do sistema.");
            }
        }
    }
}
