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
        public IHttpActionResult GetAll()
        {
            try { 
            //Declara um lista de objetos do tipo TipoVeiculo
            List<TipoVeiculo> lstTipoVeiculo = new List<TipoVeiculo>();

            //Pega um único objeto do tipo TipoVeiculo
            lstTipoVeiculo = this.context.AspNetTipoVeiculo.ToList();
            //Retorno OK (Código 200)
            return Ok(lstTipoVeiculo);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao pesquisar o tipo veículo. , entre em contato com o administrador do sistema.");
                throw;
            }
        }

        //GET
        public IHttpActionResult GetTipoVeiculo(string descricao = null, int idTipoVeiculo = 0)
        {
            try
            {
                //Declaração de um objeto Veículo
                TipoVeiculo objTipoVeiculo = new TipoVeiculo();

                //Pega um único objeto veículo pela placa
                if (!string.IsNullOrWhiteSpace(descricao))
                    objTipoVeiculo = this.context.AspNetTipoVeiculo.Where(x => x.Descricao == descricao).FirstOrDefault();
                else if (idTipoVeiculo != 0)
                    objTipoVeiculo = this.context.AspNetTipoVeiculo.Where(x => x.IdTipoVeiculo == idTipoVeiculo).FirstOrDefault();

                //Declara uma lista de objetos do tipo veículo
                List<TipoVeiculo> lstTipoVeiculo = new List<TipoVeiculo>();

                //Se o objTipoVeiculo for diferente de nulo.
                if (objTipoVeiculo != null)
                    //Adiciona o objeto veículo à lista de Tipo Veículos
                    lstTipoVeiculo.Add(objTipoVeiculo);

                return Ok(lstTipoVeiculo);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao pesquisar o tipo veículo. , entre em contato com o administrador do sistema.");
                throw;
            }
        }

        //POST
        public IHttpActionResult PutTipoVeiculo(string descricao)
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
        public IHttpActionResult PostTipoVeiculo(int idTipoVeiculo, string descricao)
        {
            try
            {
                TipoVeiculo objTipoVeiculo = new TipoVeiculo();
                objTipoVeiculo = this.context.AspNetTipoVeiculo.Where(x => x.IdTipoVeiculo == idTipoVeiculo).FirstOrDefault();

                if (objTipoVeiculo != null)
                {
                    objTipoVeiculo.IdTipoVeiculo = idTipoVeiculo;
                    objTipoVeiculo.Descricao = descricao;

                    context.SaveChanges();

                    return Ok("Tipo Veiculo alterado com sucesso.");
                }
                else
                {
                    return Ok("Tipo Veiculo não encontrado!");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao alterar o Tipo Veiculo, entre em contato com o administrador do sistema.");
            }
        }

        //DELETE
        public IHttpActionResult DeleteTipoVeiculo(string descricao = null, int idTipoVeiculo = 0)
        {
            try
            {
                TipoVeiculo objTipoVeiculo = new TipoVeiculo();

                if (!string.IsNullOrWhiteSpace(descricao))
                    objTipoVeiculo = this.context.AspNetTipoVeiculo.Where(x => x.Descricao == descricao).FirstOrDefault();
                else if (idTipoVeiculo != 0)
                    objTipoVeiculo = this.context.AspNetTipoVeiculo.Where(x => x.IdTipoVeiculo == idTipoVeiculo).FirstOrDefault();

                if (objTipoVeiculo != null)
                {
                    context.AspNetTipoVeiculo.Remove(objTipoVeiculo);
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
                return BadRequest("Erro ao excluir o tipo veículo, entre em contato com o administrador do sistema.");
            }
        }
    }
}
