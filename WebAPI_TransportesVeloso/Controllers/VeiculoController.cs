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

            //Declaração de um objeto Veículo
            Veiculo objVeiculo = new Veiculo();

            //Pega um único objeto veículo pela placa
            objVeiculo = this.context.AspNetVeiculo.Where(x => x.Placa == placa).FirstOrDefault();

            //Declara uma lista de objetos do tipo veículo
            List<Veiculo> lstVeiculo = new List<Veiculo>();

            //Se o objVeiculo for diferente de nulo.
            if (objVeiculo != null)
            {
                //Adiciona o objeto veículo à lista de Veículos
                lstVeiculo.Add(objVeiculo);

                //Retorno ok (código 200)
                return Ok(lstVeiculo);
            }
            else
                //Se o objVeículo for nulo, retorna BadRequest (código 500).
                return BadRequest("Placa não encontrada");
        }
        
        public Veiculo PostVeiculo(int idTipoVeiculo, string placa, string renavam, string chassi, string descricao, bool zeroQuilometro)
        {
            try
            {
                Veiculo objVeiculo = new Veiculo();
                objVeiculo.IdTipoVeiculo = idTipoVeiculo;
                objVeiculo.Placa = placa;
                objVeiculo.Renavam = renavam;
                objVeiculo.Chassi = chassi;
                objVeiculo.Descricao = descricao;
                objVeiculo.ZeroQuilometro = zeroQuilometro;

                context.AspNetVeiculo.Add(objVeiculo);
                context.SaveChanges();

                return objVeiculo;
                //return Ok("Veículo cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                //return BadRequest("Erro ao cadastrar o veículo, entre em contato com o administrador do sistema.");
                return null;
            }
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
