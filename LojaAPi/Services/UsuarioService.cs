using LojaAPi.Entites;
using LojaAPi.Repositores;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPi.Services
{
    public class UsuarioService
    {
        private readonly UsuarioRepository _repository;
        public UsuarioService(UsuarioRepository usuarioRepository) 
        {
            _repository = usuarioRepository;
        }

        public List<Usuario> ListarUsuarios()
        {
            return _repository.ListarTodosUsuarios();
        }

       
         public void AdicionarNovoUsuario(string password,string email,int tipo)
        {
            Usuario novoUsuario = new Usuario();
            novoUsuario.Password = password;
            novoUsuario.Email = email;
            novoUsuario.Tipo = tipo;
            novoUsuario.DataCadastro = new DateTime();

            _repository.Adicionar(novoUsuario);
        }
    }
}
