using Zuri.Models;

namespace Zuri.Repository
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuarioPorLogin(string email, string senha);
        public void Salvar(Usuario usuario);

        public bool VerificarEmail(string email);
    }
}
