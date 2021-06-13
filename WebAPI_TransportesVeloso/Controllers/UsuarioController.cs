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
        ApplicationDbContext context;

        public UsuarioController()
        {
            context = new ApplicationDbContext();
        }

        private static List<Usuario> usuario = new List<Usuario>();

        public IHttpActionResult GetUsuario(string nome)
        {
            //Declaração de um obejeto Usuario
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
    }
}
