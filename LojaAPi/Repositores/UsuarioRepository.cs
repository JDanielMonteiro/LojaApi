using LojaAPi.Entites;

namespace LojaAPi.Repositores
{
    public class UsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext appDbContext)
        { 
            _context = appDbContext;
        }

        public void Adicionar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public List<Usuario> ListarTodosUsuarios() 
        { 
            return _context.Usuarios.ToList();  // _context.Usuarios já tem todas as funções ex: get, push // ToList é para o back transformar a tabela do banco em uma lista
        }
    }
}
