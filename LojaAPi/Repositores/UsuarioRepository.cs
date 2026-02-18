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
            _context.SaveChanges();   // SaveChanges serve para comitar no banco a alteração feita, lembrar do T no DBeaver
        }

        public List<Usuario> ListarTodosUsuarios() 
        { 
            return _context.Usuarios.ToList();  // _context.Usuarios já tem todas as funções ex: get, push // ToList é para o back transformar a tabela do banco em uma lista
        }

        public Boolean VerificarSeJaExisteEmail(String emailCriado)
        {
            var usuarioEncontrado = _context.Usuarios.ToList().Find(x => x.Email == emailCriado);        // Find é como se fosse um if e um for, percorre toda a lista até achar o que vc quer 
            return (usuarioEncontrado != null);
        }

        public Usuario? BuscarDadoPorId(int idProcurado)
        {
            var usuarioEncontrado = _context.Usuarios.ToList().Find(x => x.Id == idProcurado);        // Find é como se fosse um if e um for, percorre toda a lista até achar o que vc quer 
            return usuarioEncontrado;
        }

        public void Atualizar(Usuario usuario) 
        {
          _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Deletar(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }
    }
}
