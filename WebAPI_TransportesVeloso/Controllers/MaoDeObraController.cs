using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class MaoDeObraController : ApiController
    {
        ApplicationDBContext context;

        public MaoDeObraController()
        {
            context = new ApplicationDBContext();
        }

        private static List<MaoDeObra> maoDeObra = new List<MaoDeObra>();

        //GET
        public IHttpActionResult GetAll()
        {
            try { 
            //Declaração de um objeto MaoDeObra
            List<MaoDeObra> lstMaoDeObra = new List<MaoDeObra>();
            lstMaoDeObra = context.AspNetMaoDeObra.ToList();


            //Retorno ok (código 200)
            return Ok(lstMaoDeObra);
        }
            catch (Exception ex)
            {
                return BadRequest("Erro ao pesquisar o veículo. , entre em contato com o administrador do sistema.");
                throw;
            }
        }

        //GET
        public IHttpActionResult GetMaoDeObra(string descricao = null, int idMaoDeObra = 0)
        {
            try
            {
                //Declaração de um objeto MaoDeObra
                MaoDeObra objMaoDeObra = new MaoDeObra();

                //Pega um único objeto MaoDeObra pela descrição
                if (!string.IsNullOrWhiteSpace(descricao))
                    objMaoDeObra = this.context.AspNetMaoDeObra.Where(x => x.Descricao == descricao).FirstOrDefault();


                else if (idMaoDeObra != 0)
                    objMaoDeObra = this.context.AspNetMaoDeObra.Where(x => x.IdMaoDeObra == idMaoDeObra).FirstOrDefault();

                //Declara uma lista de objetos da MaoDeObra
                List<MaoDeObra> lstMaoDeObra = new List<MaoDeObra>();

                //Se o objMaoDeObra for diferente de nulo.
                if (objMaoDeObra != null)
                    //Adiciona o objeto veículo à lista de Tipo Veículos
                    lstMaoDeObra.Add(objMaoDeObra);

                return Ok(lstMaoDeObra);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao pesquisar o MaoDeObra. , entre em contato com o administrador do sistema.");
                throw;
            }

        }

        //PUT
        public IHttpActionResult PutMaoDeObra(string descricao, string valor)
        {
            try
            {
                MaoDeObra objMaoDeObra = new MaoDeObra();
                objMaoDeObra.Descricao = descricao;
                objMaoDeObra.Valor = decimal.Parse(valor);

                context.AspNetMaoDeObra.Add(objMaoDeObra);
                context.SaveChanges();

                return Ok("MaoDeObra cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar o MaoDeObra, entre em contato com o administrador do sistema.");
            }
        }

        //POST
        public IHttpActionResult PostMaoDeObra(int idMaoDeObra, string descricao, string valor)
        {
            try
            {
                MaoDeObra objMaoDeObra = new MaoDeObra();
                objMaoDeObra = this.context.AspNetMaoDeObra.Where(x => x.IdMaoDeObra == idMaoDeObra).FirstOrDefault();

                if (objMaoDeObra != null)
                {
                    objMaoDeObra.IdMaoDeObra = idMaoDeObra;
                    objMaoDeObra.Descricao = descricao;
                    objMaoDeObra.Valor = decimal.Parse(valor);

                    context.SaveChanges();

                    return Ok("MaoDeObra alterado com sucesso.");
                }
                else
                {
                    return Ok("MaoDeObra não encontrado!");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao alterar o MaoDeObra, entre em contato com o administrador do sistema.");
            }
        }

        //DELETE
        public IHttpActionResult DeleteMaoDeObra(string descricao = null, int idMaoDeObra = 0)
        {
            try
            {
                MaoDeObra objMaoDeObra = new MaoDeObra();

                if (!string.IsNullOrWhiteSpace(descricao))
                    objMaoDeObra = this.context.AspNetMaoDeObra.Where(x => x.Descricao == descricao).FirstOrDefault();
                else if (idMaoDeObra != 0)
                    objMaoDeObra = this.context.AspNetMaoDeObra.Where(x => x.IdMaoDeObra == idMaoDeObra).FirstOrDefault();

                if (objMaoDeObra != null)
                {
                    context.AspNetMaoDeObra.Remove(objMaoDeObra);
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
                return BadRequest("Erro ao excluir o MaoDeObra, entre em contato com o administrador do sistema.");
            }
        }
    }
}
