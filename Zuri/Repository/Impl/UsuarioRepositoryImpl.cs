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

        public void Salvar(Usuario usuario)
        {
            _context.Add(usuario);
            _context.SaveChanges();
        }
    }
}
