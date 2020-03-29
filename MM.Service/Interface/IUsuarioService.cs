using Google.Cloud.Firestore;
using MM.Domain;
using System.Threading.Tasks;

namespace MM.Service.Interface
{
    public interface IUsuarioService
    {
        Task<string> Inserir(Usuario usuario);
    }
}
