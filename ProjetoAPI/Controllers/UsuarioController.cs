using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI.Models;
using LoginRequest = ProjetoAPI.Models.LoginRequest;
using CadastroRequest = ProjetoAPI.Models.CadastroRequest;
using esqueceuSenhaRequest = ProjetoAPI.Models.esqueceuSenhaRequest;
using ProjetoAPI.Services;
using ProjetoAPI.Repositories;

namespace ProjetoAPI.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
       private IConfiguration _configuration;
        
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Route("login")]
        [HttpPost]
        public LoginResult Login(LoginRequest request)
        {
            var result = new LoginResult();

            if (request == null)
            {
                result.sucesso = false;
                result.mensagem = "Parâmetro veio null.";
            }
            else if (request.email == "")
            {
                result.sucesso = false;
                result.mensagem = "É necessário informar o email.";
            }
            else if (request.senha == "")
            {
                result.sucesso = false;
                result.mensagem = "É necessário informar a senha.";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");


                var UsuarioService = new UsuarioService(connectionString);

                result = UsuarioService.Login(request.email, request.senha);
            }

            return result;
        }

        [Route("cadastro")]
        [HttpPost]
        public CadastroResult Cadastro(CadastroRequest request)
        {
            var result = new CadastroResult();

            if (request == null ||
                string.IsNullOrWhiteSpace(request.nome) ||
                string.IsNullOrWhiteSpace(request.sobrenome) ||
                string.IsNullOrWhiteSpace(request.telefone) ||
                string.IsNullOrWhiteSpace(request.genero) ||
                string.IsNullOrWhiteSpace(request.email) ||
                string.IsNullOrWhiteSpace(request.senha))
            {
                result.sucesso = false;
                result.mensagem = "Os campos acima são obrigatórios";

                return result;
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");
                
                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.Cadastro(request.nome, request.sobrenome, request.telefone, request.email, request.genero, request.senha);
            }

            return result;
        }

        [Route("esqueceuSenha")]
        [HttpPost]
        public esqueceuSenhaResult esqueceuSenha(esqueceuSenhaRequest request)
        {
            var result = new esqueceuSenhaResult();

            

            if (request == null ||
                string.IsNullOrEmpty(request.email))
            {

                result.sucesso = false;
                result.mensagem = "E-mail obrigatório";

                return result;
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");


                var usuarioService = new UsuarioService(connectionString);

                result = usuarioService.EsqueceuSenha(request.email);


            }
            return result;
        }


        [HttpGet]
        [Route("obterUsuario")]
        public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
        {
            var result = new ObterUsuarioResult();

            if(usuarioGuid == null) 
            { 
                result.mensagem = "Guid vazio";
            }
            else
            {
                var connectionString = _configuration.GetConnectionString("programacaoDoZeroDb");
                
                var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);

                if(usuario == null)
                {
                    result.mensagem = "Usuário não existe";
                }
                else
                {
                    result.sucesso=true;
                    result.nome = usuario.Nome;
                }
            }
            return result;
        }
    
    }
}