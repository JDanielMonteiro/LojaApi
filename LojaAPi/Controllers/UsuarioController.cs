using LojaAPi.Entites;
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
        public IActionResult CriarUsuario(  // IActionResult é uma função pronta 
         [FromForm] string password,
         [FromForm] string email,
         [FromForm] int tipo)
        {
            _usuarioService.AdicionarNovoUsuario(password, email, tipo);
            return Ok("tudo ok"); // o nome Ok é uma função pré ponta que transforma tudo que ta dentro dele em IActionResult
        }
    }
}
