using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI_TransportesVeloso.Controllers
{
    public class ConsumoController : ApiController
    {
        ApplicationDbContext context;

        public ConsumoController()
        {
            context = new ApplicationDbContext();
        }

        private static List<Consumo> consumo = new List<Consumo>();

        public IHttpActionResult GetConsumo(int quilometragem)
        {
            //Declaração de um obejeto consumo
            Consumo objConsumo = new Consumo();

            //Pega um único objeto do tipo consumo
            objConsumo = this.context.AspNetConsumo.Where(x => x.Quilometragem == quilometragem).FirstOrDefault();

            //Declara um lista de objetos do tipo consumo
            List<Consumo> lstConsumo = new List<Consumo>();

            //Se o objConsumo for diferente de nulo.
            if (objConsumo != null)
            {
                //Adiciona o objeto veículo à lista de consumo
                lstConsumo.Add(objConsumo);

                //Retorno OK (ódigo 200)
                return Ok(lstConsumo);
            }
            else
                //Se objConsumo for nulo, retorna BadRequest (código 500).
                return BadRequest("Quilometragem não encontrada");

        }
    }
}
