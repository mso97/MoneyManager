using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MM.Domain;
using MM.Domain.Core;
using MM.Domain.Interface.Repository;
using MM.Domain.Notifications;
using MM.Service.Interface;

namespace MM.Service
{
    public class LoginService : ILoginService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly NotificationContext _notificationContext;
        private Usuario usuarioBanco;

        public LoginService(IUsuarioRepository usuarioRepository, IUsuarioService usuarioService, NotificationContext notificationContext)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _notificationContext = notificationContext;
        }

        public Usuario Login(Usuario usuario)
        {
            if (!ValidarLogin(usuario))
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, usuarioBanco.Nome),
                    new Claim(ClaimTypes.Email, usuarioBanco.Email),
                    new Claim("NossoDinheiro", usuarioBanco.Role)
                }),
                Expires = DateTime.UtcNow.AddDays(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            usuarioBanco.Token = tokenHandler.WriteToken(token);

            usuarioBanco.Senha = null;

            return usuarioBanco;
        }

        public bool ValidarLogin(Usuario usuario)
        {
            usuarioBanco = _usuarioRepository.SelecionarPorEmail(usuario.Email);
            if (usuarioBanco != null)
            {
                if (_usuarioService.CreateHash(usuario.Senha, usuarioBanco.Salt) == usuarioBanco.Senha)
                {
                    return true;
                }
                else
                {
                    _notificationContext.AddNotification("E-mail e/ou senha incorreto(s).");
                    return false;
                }
            }

            _notificationContext.AddNotification("E-mail não encontrado.");
            return false;
        }
    }
}
