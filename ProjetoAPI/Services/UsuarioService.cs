using ProjetoAPI.Common;
using ProjetoAPI.Entities;
using ProjetoAPI.Models;
using ProjetoAPI.Repositories;

namespace ProjetoAPI.Services
{
    public class UsuarioService
    {
        private string _connectionString;
        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.obterUsuarioPorEmail(email);

            if(usuario != null)
            {
                //Usuário existe.
                if(usuario.Senha == senha)
                {
                    //senha válida
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else
                {
                    //senha inválida
                    result.sucesso = false;
                    result.mensagem = "Usuário ou senha inválidos";
                }
            }

            else //Usuário não existe
            {
                result.sucesso = false;
                result.mensagem = "Email ou senha inválidos";
            }

            return result;
        }

        public CadastroResult Cadastro(string nome, string sobrenome, string telefone, string email, string genero, string senha)
        {
            var result = new CadastroResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.obterUsuarioPorEmail(email);

            if(usuario != null)
            {
                //Usuário já existe
                result.sucesso = false;
                result.mensagem = "Usuário já existe";
            }

            else
            {
                //Usuário não existe
                usuario = new Usuario();
                usuario.Nome = nome;
                usuario.Sobrenome = sobrenome;
                usuario.Senha = senha;
                usuario.Genero = genero;
                usuario.Email = email;
                usuario.Telefone = telefone;
                usuario.UsuarioGuid = Guid.NewGuid();

                var affectedRows = usuarioRepository.Inserir(usuario);

                if(affectedRows > 0)
                {
                    result.sucesso = true;
                    result.usuarioGuid = usuario.UsuarioGuid;
                }
                else 
                { 
                    result.sucesso = false;
                    result.mensagem = "Erro ao inserir usuário. Tente novamente.";
                }
            }

            return result;
        }

        public esqueceuSenhaResult EsqueceuSenha(string email)
        {
            var result = new esqueceuSenhaResult();

            var usuarioRepository = new UsuarioRepository(_connectionString);

            var usuario = usuarioRepository.obterUsuarioPorEmail(email);

            if(usuario == null)
            {
                //usuário não existe
                result.sucesso = false;
                result.mensagem = "Usuário não existe.";
            }

            else
            {
                //usuario existe
                var emailSender = new EmailSender();

                var assunto = "Recuperação de Senha";
                var corpo = "Sua senha é: " + usuario.Senha;
                emailSender.Enviar(assunto, corpo, usuario.Email);


            }

            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterPorGuid(usuarioGuid);

            return usuario;
        }
    }
}
