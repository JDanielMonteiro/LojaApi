using LojaAPi.Entites;
using LojaAPi.Entites.DTO;
using LojaAPi.Services;
using Microsoft.AspNetCore.Mvc;

namespace LojaAPi.Controllers
{
    [ApiController]
    [Route("Usuario")]
    public class UsuarioController : ControllerBase
    {
        
        private readonly UsuarioService _usuarioService; // o anderline é padrão para definir uma variavel global
        public UsuarioController(UsuarioService usuarioService) // Isso é padrão: colocar WeatherForecastService weatherForecastService como parametro é para injeção de pedendencia
        {
            _usuarioService = usuarioService;
        }
        [HttpGet("GetUsuario")] // sou foda
        public List<Usuario> ListarUsuariosController()
        {
            return _usuarioService.ListarUsuarios();
        }

        [HttpPost]
        public IActionResult CriarUsuario([FromBody] UsuarioCriacaoDto usuarioCriacaoController)     // IActionResult é uma função pronta 
        {
            _usuarioService.AdicionarNovoUsuario(usuarioCriacaoController);
            return Ok("tudo ok"); // o nome Ok é uma função pré ponta que transforma tudo que ta dentro dele em IActionResult
        }

        [HttpGet("BuscarPorId")]
        public UsuarioCriacaoDto BuscarPorId([FromQuery] int id) 
        {
            return _usuarioService.BuscarDadoPorId(id);
        }
    }
}
