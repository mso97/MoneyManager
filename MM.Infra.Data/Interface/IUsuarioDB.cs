using Google.Cloud.Firestore;
using MM.Domain;
using System.Threading.Tasks;

namespace MM.Infra.Data.Interface
{
    public interface IUsuarioDB
    {
        Task<WriteResult> Inserir(Usuario usuario);
    }
}
