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
        ApplicationDBContext context;

        public VeiculoController()
        {
            context = new ApplicationDBContext();
        }

        private static List<Veiculo> veiculo = new List<Veiculo>();

        public IHttpActionResult GetAll()
        {
            try
            {
                //ConsultaModelo
                //https://localhost:44324/api/Veiculo/GetVeiculo?placa=FSK3F56

                //Declaração de um objeto Veículo
                List<Veiculo> lstVeiculo = new List<Veiculo>();
                lstVeiculo = context.AspNetVeiculo.ToList();

               
                    //Retorno ok (código 200)
                    return Ok(lstVeiculo);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao pesquisar o veículo. , entre em contato com o administrador do sistema.");
                throw;
            }
        }
        
        //GET
        public IHttpActionResult GetVeiculo(string placa = null, int idVeiculo = 0)
        {
            try
            {
                //ConsultaModelo
                //https://localhost:44324/api/Veiculo/GetVeiculo?placa=FSK3F56

                //Declaração de um objeto Veículo
                Veiculo objVeiculo = new Veiculo();

                //Pega um único objeto veículo pela placa
                if (!string.IsNullOrWhiteSpace(placa))
                    objVeiculo = this.context.AspNetVeiculo.Where(x => x.Placa == placa).FirstOrDefault();
                else if (idVeiculo != 0)
                    objVeiculo = this.context.AspNetVeiculo.Where(x => x.IdVeiculo == idVeiculo).FirstOrDefault();

                //Declara uma lista de objetos do tipo veículo
                List<Veiculo> lstVeiculo = new List<Veiculo>();

                //Se o objVeiculo for diferente de nulo.
                if (objVeiculo != null)
                    //Adiciona o objeto veículo à lista de Veículos
                    lstVeiculo.Add(objVeiculo);

                return Ok(lstVeiculo);
            }
            catch (Exception ex)
            {
                return BadRequest("Erro ao pesquisar o veículo. , entre em contato com o administrador do sistema.");
                throw;
            }
        }
        
        //PUT
        public IHttpActionResult PutVeiculo(int idTipoVeiculo, string placa, string renavam, string chassi, string descricao, bool zeroQuilometro)
        {
            //https://localhost:44324/api/Veiculo/PostVeiculo?idTipoVeiculo=1&placa=TTT0T12&renavam=AAA423D5870&chassi=RRRRGH5412OPL6394&descricao=TESTE_DE_PUT&zeroQuilometro=false
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

                return Ok("Veículo cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao cadastrar o veículo, entre em contato com o administrador do sistema.");
            }
        }

        //POST
        public IHttpActionResult PostVeiculo(int idVeiculo, int idTipoVeiculo, string placa, string renavam, string chassi, string descricao, bool zeroQuilometro)
        {
            //https://localhost:44324/api/Veiculo/PostVeiculo?idTipoVeiculo=1&placa=TTT0T12&renavam=AAA423D5870&chassi=RRRRGH5412OPL6394&descricao=TESTE_DE_PUT&zeroQuilometro=false
            try
            {
                Veiculo objVeiculo = new Veiculo();
                objVeiculo = this.context.AspNetVeiculo.Where(x => x.IdVeiculo == idVeiculo).FirstOrDefault();
                //objVeiculo = this.context.AspNetVeiculo.Where(x => x.Placa == placa).FirstOrDefault();


                if (objVeiculo != null)
                {
                    objVeiculo.IdVeiculo = idVeiculo;
                    objVeiculo.IdTipoVeiculo = idTipoVeiculo;
                    objVeiculo.Placa = placa;
                    objVeiculo.Renavam = renavam;
                    objVeiculo.Chassi = chassi;
                    objVeiculo.Descricao = descricao;
                    objVeiculo.ZeroQuilometro = zeroQuilometro;

                    context.SaveChanges();

                    return Ok("Veículo alterado com sucesso.");
                }
                else 
                {
                    return Ok("Veículo não encontrado!");
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao alterar o veículo, entre em contato com o administrador do sistema.");
            }
        }

        //DELETE
        public IHttpActionResult DeleteVeiculo(string placa = null, int idVeiculo = 0)
        {
            //https://localhost:44324/api/Veiculo/DeleteVeiculo?placa=FSK3G56
            try
            {
                Veiculo objVeiculo = new Veiculo();
                
                if(!string.IsNullOrWhiteSpace(placa))
                    objVeiculo = this.context.AspNetVeiculo.Where(x => x.Placa == placa).FirstOrDefault();
                else if (idVeiculo != 0)
                    objVeiculo = this.context.AspNetVeiculo.Where(x => x.IdVeiculo == idVeiculo).FirstOrDefault();

                if (objVeiculo != null)
                {
                    context.AspNetVeiculo.Remove(objVeiculo);
                    context.SaveChanges();
                    return Ok(true);
                }
                else {
                    return Ok(false);
                }
            }
            catch (Exception ex)
            {
                string vErro = ex.Message;
                return BadRequest("Erro ao excluir o veículo, entre em contato com o administrador do sistema.");
            }
        }
    }
}
