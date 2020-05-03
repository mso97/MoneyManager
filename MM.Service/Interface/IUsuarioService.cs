using Google.Cloud.Firestore;
using MM.Domain;
using System;
using System.Threading.Tasks;

namespace MM.Service.Interface
{
    public interface IUsuarioService
    {
        Guid Inserir(Usuario usuario);
    }
}
