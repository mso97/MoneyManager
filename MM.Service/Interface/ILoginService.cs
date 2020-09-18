using MM.Domain;
using System;

namespace MM.Service.Interface
{
    public interface ILoginService
    {
        Usuario Login(Usuario usuario);
    }
}
