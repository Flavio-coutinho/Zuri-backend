using Zuri.Models;

namespace Zuri.Repository
{
    public interface IUsuarioRepository
    {
        public void Salvar(Usuario usuario);

        public bool VerificarEmail(string email);
    }
}
