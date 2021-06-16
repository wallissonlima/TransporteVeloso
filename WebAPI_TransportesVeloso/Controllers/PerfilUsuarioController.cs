using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class PerfilUsuarioController : ApiController
    {
        ApplicationDBContext context;

        public PerfilUsuarioController()
        {
            context = new ApplicationDBContext();
        }

        private static List<PerfilUsuario> perfilUsuario = new List<PerfilUsuario>();

        //GET
        public IHttpActionResult GetPerfilUsuario(string descricao)
        {
            //Declaração de um objeto PerfilUsuario
            PerfilUsuario objPerfilUsuario = new PerfilUsuario();

            //Pega um único objeto do tipo PerfilUsuario
            objPerfilUsuario = this.context.AspNetPerfilUsuario.Where(x => x.Descricao == descricao).FirstOrDefault();

            //Declara um lista de objetos do tipo PerfilUsuario
            List<PerfilUsuario> lstPerfilUsuario = new List<PerfilUsuario>();

            //Se o objPerfilUsuario for diferente de nulo.
            if (objPerfilUsuario != null)
            {
                //Adiciona o objeto PerfilUsuario à lista de PerfilUsuario
                lstPerfilUsuario.Add(objPerfilUsuario);

                //Retorno OK (Código 200)
                return Ok(lstPerfilUsuario);
            }
            else
                //Se objContrato for nulo, retorna BadRequest (código 500).
                return BadRequest("Numero não encontrada");
        }

        //POST
        public IHttpActionResult PostPerfilUsuario(string descricao)
        {
            try
            {
                PerfilUsuario objPerfilUsuario = new PerfilUsuario();
                objPerfilUsuario.Descricao = descricao;

                context.AspNetPerfilUsuario.Add(objPerfilUsuario);
                context.SaveChanges();

                return Ok("PerfilUsuario cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar o PerfilUsuario, entre em contato com o administrador do sistema.");
            }
        }

        //PUT
        public IHttpActionResult PutPerfilUsuario(string descricao)
        {           
            try
            {
                PerfilUsuario objPerfilUsuario = new PerfilUsuario();
                objPerfilUsuario = this.context.AspNetPerfilUsuario.Where(x => x.Descricao == descricao).FirstOrDefault();

                if (objPerfilUsuario != null)
                {
                    objPerfilUsuario.Descricao = descricao;

                    context.SaveChanges();

                    return Ok("PerfilUsuario alterado com sucesso.");
                }
                else
                {
                    return Ok("PerfilUsuario não encontrado!");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao alterar o PerfilUsuario, entre em contato com o administrador do sistema.");
            }
        }

        //DELETE
        public IHttpActionResult DeletePerfilUsuario(string descricao)
        {
            try
            {
                PerfilUsuario objPerfilUsuario = new PerfilUsuario();
                objPerfilUsuario = this.context.AspNetPerfilUsuario.Where(x => x.Descricao == descricao).FirstOrDefault();

                if (objPerfilUsuario != null)
                {
                    context.AspNetPerfilUsuario.Remove(objPerfilUsuario);
                    context.SaveChanges();
                    return Ok("PerfilUsuario removido com sucesso");
                }
                else
                {
                    return BadRequest("PerfilUsuario não encontrado.");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao excluir o PerfilUsuario, entre em contato com o administrador do sistema.");
            }
        }
    }
}
