using WebAPI_TransportesVeloso.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebAPI_TransportesVeloso.Controllers
{
    public class VeiculoController : ApiController
    {
        ApplicationDbContext context;

        public VeiculoController()
        {
            context = new ApplicationDbContext();
        }

        private static List<Veiculo> veiculo = new List<Veiculo>();
        
        public IHttpActionResult GetVeiculo(string placa)
        {
            //ConsultaModelo
            //https://localhost:44324/api/Veiculo/GetVeiculo?placa=FSK3F56

            Veiculo objVeiculo = new Veiculo();
            objVeiculo = this.context.AspNetVeiculo.Where(x => x.Placa == placa).FirstOrDefault();


            List<Veiculo> lstVeiculo = new List<Veiculo>();
            if (objVeiculo != null)
            {
                lstVeiculo.Add(objVeiculo);
                return Ok(lstVeiculo);
            }
            else
                return BadRequest("Usuário ou senha inválidos");
        }

        [HttpPost]
        public void Post(string placa)
        {
         //   if (!string.IsNullOrEmpty(placa))
            //    veiculo.Add(new Veiculo(placa));
        }

        [HttpDelete]
        public void Delete(string placa)
        {
            //1 pegar o veiculo e amarzenar no obejeto veiculo
            Veiculo objVeiculo = new Veiculo();
            objVeiculo = this.context.AspNetVeiculo.Where(x => x.Placa == placa).FirstOrDefault();
            //2 enviar o objeto veiculo para exclusão 
            if (objVeiculo != null)
            { 
            context.AspNetVeiculo.Remove(objVeiculo);
                context.SaveChanges();
            }


            //veiculo.RemoveAt(veiculo.IndexOf(veiculo.First(x => x.Placa.Equals(placa))));
        }
    }
}
