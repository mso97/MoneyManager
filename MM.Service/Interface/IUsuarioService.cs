using MM.Domain;
using System;

namespace MM.Service.Interface
{
    public interface IUsuarioService
    {
        Guid Inserir(Usuario usuario);
        string CreateHash(string password, string salt);
    }
}
