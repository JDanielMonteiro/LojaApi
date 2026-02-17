using LojaAPi.Entites;
using LojaAPi.Entites.DTO;
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

       
         public void AdicionarNovoUsuario(UsuarioCriacaoDto usuarioCriacaoDto)  // Assim era o parametro (string password,string email,int tipo) antes de ser colocado o UsuarioCriacaoDto usuarioCriacaoDto
        {
            Usuario novoUsuario = MapearParaEntidade(usuarioCriacaoDto);
            _repository.Adicionar(novoUsuario);
        }

        private Usuario MapearParaEntidade(UsuarioCriacaoDto dto)
        {
            Usuario entidade = new Usuario();
            entidade.Password = dto.Password;
            entidade.Email = dto.Email;
            entidade.Tipo = dto.Tipo;
            if (dto.Id.HasValue)                  // essa função alé de ser pra criação também vai servir pra atualização, por isso foi colocado os hasvalue, pq ele verifica se o id tem valor ou não automaticamente, pq no ato de criação o id ainda não tem valor pq é o banco quem cria o id, mas no ato de atuzlização id já vai ter valor, por isso o hasvalue
            {
                entidade.Id = dto.Id.Value;
            }
            else
            { 
                entidade.DataCadastro = DateTime.UtcNow;
            }
                return entidade;
         
        }


    }
}
