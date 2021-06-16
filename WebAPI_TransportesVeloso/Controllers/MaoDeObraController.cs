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
        public IHttpActionResult GetMaoDeObra(string descricao)
        {
            //Declaração de um objeto MaoDeObra
            MaoDeObra objMaoDeObra = new MaoDeObra();

            //Pega um único objeto do tipo Contrato
            objMaoDeObra = this.context.AspNetMaoDeObra.Where(x => x.Descricao == descricao).FirstOrDefault();

            //Declara um lista de objetos do tipo MaoDeObra
            List<MaoDeObra> lstMaoDeObra = new List<MaoDeObra>();

            //Se o objContrato for diferente de nulo.
            if (objMaoDeObra != null)
            {
                //Adiciona o objeto MaoDeObra à lista de MaoDeObra
                lstMaoDeObra.Add(objMaoDeObra);

                //Retorno OK (Código 200)
                return Ok(lstMaoDeObra);
            }
            else
                //Se objMaoDeObra for nulo, retorna BadRequest (código 500).
                return BadRequest("Descriçao não encontrada");

        }

        //POST
        public IHttpActionResult PostMaoDeObra(string descricao, decimal valor)
        {
            try
            {
                MaoDeObra objMaoDeObra = new MaoDeObra();
                objMaoDeObra.Descricao = descricao;
                objMaoDeObra.Valor = valor;

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

        //PUT
        public IHttpActionResult PutMaoDeObra(string descricao, decimal valor)
        {
            try
            {
                MaoDeObra objMaoDeObra = new MaoDeObra();
                objMaoDeObra = this.context.AspNetMaoDeObra.Where(x => x.Descricao == descricao).FirstOrDefault();

                if (objMaoDeObra != null)
                {
                    objMaoDeObra.Descricao = descricao;
                    objMaoDeObra.Valor = valor;

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
        public IHttpActionResult DeleteMaoDeObra(string descricao)
        {
            try
            {
                MaoDeObra objMaoDeObra = new MaoDeObra();
                objMaoDeObra = this.context.AspNetMaoDeObra.Where(x => x.Descricao == descricao).FirstOrDefault();

                if (objMaoDeObra != null)
                {
                    context.AspNetMaoDeObra.Remove(objMaoDeObra);
                    context.SaveChanges();
                    return Ok("MaoDeObra removido com sucesso");
                }
                else
                {
                    return BadRequest("MaoDeObra não encontrado.");
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
