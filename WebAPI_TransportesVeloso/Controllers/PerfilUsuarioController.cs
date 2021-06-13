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
        ApplicationDbContext context;

        public PerfilUsuarioController()
        {
            context = new ApplicationDbContext();
        }

        private static List<PerfilUsuario> perfilUsuario = new List<PerfilUsuario>();

        public IHttpActionResult GetPerfilUsuario(string descricao)
        {
            //Declaração de um obejeto PerfilUsuario
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
    }
}
