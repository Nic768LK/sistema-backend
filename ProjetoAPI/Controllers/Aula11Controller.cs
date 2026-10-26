using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Models;

namespace ProjetoAPI.Controllers
{
    [Route("api/aula11")]
    [ApiController]
    public class Aula11Controller : ControllerBase
    {
        [Route("obterVeiculo")]
        [HttpGet]

        public veiculo obterVeiculo()
        {
            var meuVeiculo = new veiculo();

            meuVeiculo.Cor = "Cinza";
            meuVeiculo.Placa = "GEU7H87";
            meuVeiculo.Marca = "Chery";
            meuVeiculo.Modelo = "Tiggo 5X";

            meuVeiculo.Acelerar();

            return meuVeiculo;
        }


        [Route("obterCarro")]
        [HttpGet]

        public carro obterCarro()
        {
            var meuCarro = new carro();

            meuCarro.Cor = "Cinza";
            meuCarro.Placa = "COD-9423";
            meuCarro.Marca = "Volkswagen";
            meuCarro.Modelo = "Gol";

            meuCarro.Acelerar();

            return meuCarro;


        }
    }
}
