using MM.Domain;
using System;
using System.IdentityModel.Tokens.Jwt;

namespace MM.Service.Interface
{
    public interface ILoginService
    {
        Usuario Login(Usuario usuario);
        JwtSecurityToken DecryptToken(string token);
    }
}
