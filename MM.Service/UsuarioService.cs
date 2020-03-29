using Google.Cloud.Firestore;
using MM.Domain;
using MM.Infra.Data.Interface;
using MM.Service.Interface;
using System.Threading.Tasks;

namespace MM.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioDB _usuarioDB;

        public UsuarioService(IUsuarioDB usuarioDB)
        {
            _usuarioDB = usuarioDB;
        }

        public Task<string> Inserir(Usuario usuario)
        {
            return _usuarioDB.Inserir(usuario);
        }
    }
}
