using LojaAPi.Entites;
using LojaAPi.Entites.DTO;
using LojaAPi.Repositores;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            if (usuarioCriacaoDto.Password.IsNullOrEmpty())
            {
                throw new ArgumentException("Password não pode ser vazio.");
            }

            if (usuarioCriacaoDto.Email.IsNullOrEmpty())
            {
                throw new ArgumentException("Email não pode ser vazio.");
            }

            if (usuarioCriacaoDto.Tipo == null)       // Interessante: O null é importante pq o usuario poderia passar um valor esaço espaço espaço ou comentar // e burlar o sistema pq o sistema acha que por a variavel ser int o usuario não poderia passar um valor diferente.
            {
                throw new ArgumentException("Tipo não pode ser vazio.");
            }

            if (_repository.VerificarSeJaExisteEmail(usuarioCriacaoDto.Email))
            {
                throw new ArgumentException("Email já existe.");  // validar email é com o frontand
            }


            Usuario novoUsuario = MapearParaEntidade(usuarioCriacaoDto);
            _repository.Adicionar(novoUsuario);
        }

        public UsuarioCriacaoDto? BuscarDadoPorId(int idProcurado)
        { 
            var usuarioEncontrado = _repository.BuscarDadoPorId(idProcurado);
            var transformadoEmDto = MapearParaDto(usuarioEncontrado);
            return transformadoEmDto;
        }

        private UsuarioCriacaoDto MapearParaDto(Usuario usuario)
        {
            UsuarioCriacaoDto entidade = new UsuarioCriacaoDto();
            entidade.Password = usuario.Password;
            entidade.Email = usuario.Email;
            entidade.Tipo = usuario.Tipo;
            entidade.Id = usuario.Id; 

            return entidade;
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

        public void AtualizarUsuario(UsuarioCriacaoDto usuarioCriacaoDto) 
        {
            if (usuarioCriacaoDto.Password.IsNullOrEmpty())
            {
                throw new ArgumentException("Password não pode ser vazio.");
            }

            if (usuarioCriacaoDto.Email.IsNullOrEmpty())
            {
                throw new ArgumentException("Email não pode ser vazio.");
            }

            if (usuarioCriacaoDto.Tipo == null)                                     // Interessante: O null é importante pq o usuario poderia passar um valor esaço espaço espaço ou comentar // e burlar o sistema pq o sistema acha que por a variavel ser int o usuario não poderia passar um valor diferente.
            {
                throw new ArgumentException("Tipo não pode ser vazio.");
            }

            Usuario novoUsuario = MapearParaEntidade(usuarioCriacaoDto);
            _repository.Atualizar(novoUsuario);

        }

        public void Deletar(int idDeletar)
        {
            var usuarioGenerico = _repository.BuscarDadoPorId(idDeletar);
            _repository.Deletar(usuarioGenerico);
        }

    }
}
