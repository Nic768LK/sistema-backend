using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjetoAPI.Controllers
{
    [Route("api/aula8")]
    [ApiController]
    public class Aula8Controller : ControllerBase
    {
        [Route("olaMundo")]
        [HttpGet]
        
        public string OlaMundo()
        {
            var mensagem = "Olá mundo via API";

            return mensagem;
        }

        [Route("olaMundoPersonalizado")]
        [HttpGet]
        
        public string OlaMundoPersonalizado(string nome)
        {
            var mensagem = "Olá Mundo via API " + nome;

            return mensagem;
        }

        [Route("calculadora")]
        [HttpGet]

        public string Calculadora(int num1, int num2)
        {
            var soma = num1 + num2;
            
            var mensagem = "A soma é " + soma;

            return mensagem;
        }


    }
}
