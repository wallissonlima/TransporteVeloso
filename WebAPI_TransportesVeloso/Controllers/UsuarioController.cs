using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class UsuarioController : ApiController
    {
        ApplicationDBContext context;

        public UsuarioController()
        {
            context = new ApplicationDBContext();
        }

        private static List<Usuario> usuario = new List<Usuario>();

        //GET
        public IHttpActionResult GetUsuario(string nome)
        {
            //Declaração de um objeto Usuario
            Usuario objUsuario = new Usuario();

                //Pega um único objeto do tipo Usuario
                objUsuario = this.context.AspNetUsuario.Where(x => x.Nome == nome).FirstOrDefault();

                //Declara um lista de objetos do tipo Usuario
                List<Usuario> lstUsuario = new List<Usuario>();

                //Se o objUsuario for diferente de nulo.
                if (objUsuario != null)
            {
                    //Adiciona o objeto Usuario à lista de Usuario
                    lstUsuario.Add(objUsuario);

                //Retorno OK (Código 200)
                return Ok(lstUsuario);
            }
            else
                    //Se objUsuario for nulo, retorna BadRequest (código 500).
                    return BadRequest("Numero não encontrada");
        }

        //POST
        public IHttpActionResult PostUsuario(string nome, string email, string telefone, string endereco, string senha, int idPerfilUsuario)
        {
            try
            {
                Usuario objUsuario = new Usuario();
                objUsuario.Nome = nome;
                objUsuario.Email = email;
                objUsuario.Telefone = telefone;
                objUsuario.Endereco = endereco;
                objUsuario.Senha = senha;
                objUsuario.IdPerfilUsuario = idPerfilUsuario;

                context.AspNetUsuario.Add(objUsuario);
                context.SaveChanges();

                return Ok("Usuario cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar o Usuario, entre em contato com o administrador do sistema.");
            }
        }

        //PUT
        public IHttpActionResult PutUsuario(string nome, string email, string telefone, string endereco, string senha, int idPerfilUsuario)
        {
            try
            {
                Usuario objUsuario = new Usuario();
                objUsuario = this.context.AspNetUsuario.Where(x => x.Nome == nome).FirstOrDefault();

                if (objUsuario != null)
                {
                objUsuario.Nome = nome;
                objUsuario.Email = email;
                objUsuario.Telefone = telefone;
                objUsuario.Endereco = endereco;
                objUsuario.Senha = senha;
                objUsuario.IdPerfilUsuario = idPerfilUsuario;

                    context.SaveChanges();

                    return Ok("Usuario alterado com sucesso.");
                }
                else
                {
                    return Ok("Usuario não encontrado!");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao alterar o Usuario, entre em contato com o administrador do sistema.");
            }
        }

        //DELETE
        public IHttpActionResult DeleteUsuario(string nome)
        {
            try
            {
                Usuario objUsuario = new Usuario();
                objUsuario = this.context.AspNetUsuario.Where(x => x.Nome == nome).FirstOrDefault();

                if (objUsuario != null)
                {
                    context.AspNetUsuario.Remove(objUsuario);
                    context.SaveChanges();
                    return Ok("Usuario removido com sucesso");
                }
                else
                {
                    return BadRequest("Usuario não encontrado.");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao excluir o Usuario, entre em contato com o administrador do sistema.");
            }
        }
    }
}
