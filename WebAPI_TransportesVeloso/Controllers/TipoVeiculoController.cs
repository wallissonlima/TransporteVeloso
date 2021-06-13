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
        ApplicationDbContext context;

        public TipoVeiculoController()
        {
            context = new ApplicationDbContext();
        }

        private static List<TipoVeiculo> tipoVeiculo = new List<TipoVeiculo>();

        public IHttpActionResult GetTipoVeiculo(string descricao)
        {
            //Declaração de um obejeto TipoVeiculo
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
    }
}
