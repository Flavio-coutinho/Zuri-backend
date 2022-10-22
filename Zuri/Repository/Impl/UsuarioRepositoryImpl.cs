using Zuri.Models;

namespace Zuri.Repository.Impl
{
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {

        private readonly ZuriContext _context;

        public UsuarioRepositoryImpl(ZuriContext context)
        {
            _context = context;
        }

        public Usuario GetUsuarioPorId(int id)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Id == id);
        }

        public Usuario GetUsuarioPorLogin(string email, string senha)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public void Salvar(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }

        public bool VerificarEmail(string email)
        {
            return _context.Usuarios.Any(u => u.Email == email);
        }
    }
}
