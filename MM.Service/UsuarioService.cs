using FluentValidation.Results;
using MM.Domain;
using MM.Domain.Interface.Repository;
using MM.Domain.Notifications;
using MM.Service.Interface;
using System;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MM.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly NotificationContext _notificationContext;

        public UsuarioService(IUsuarioRepository usuarioRepository, NotificationContext notificationContext)
        {
            _usuarioRepository = usuarioRepository;
            _notificationContext = notificationContext;
        }

        public Guid Inserir(Usuario usuario)
        {
            usuario.SetSalt(CreateSalt());
            usuario.SetSenha(CreateHash(usuario.Senha, usuario.Salt));

            return _usuarioRepository.Inserir(usuario);
        }

        public string CreateSalt()
        {
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[32];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public string CreateHash(string password, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(salt + password);
            SHA256Managed sHA256ManagedString = new SHA256Managed();
            byte[] hash = sHA256ManagedString.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }
}
