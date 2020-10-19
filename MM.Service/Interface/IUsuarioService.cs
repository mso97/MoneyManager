using MM.Domain;
using System;

namespace MM.Service.Interface
{
    public interface IUsuarioService
    {
        Guid Inserir(Usuario usuario);
        Usuario Consultar(Guid id);
        string CreateHash(string password, string salt);
    }
}
