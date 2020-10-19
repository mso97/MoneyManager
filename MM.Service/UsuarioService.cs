using MM.Domain;
using MM.Domain.Interface.Repository;
using MM.Domain.Notifications;
using MM.Service.Interface;
using System;
using System.Security.Cryptography;
using System.Text;

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
            usuario.SetRole("default");
            usuario.SetDataCadastro();

            if (!ValidarInserir(usuario))
                return new Guid();

            return _usuarioRepository.Inserir(usuario);
        }

        public Usuario Consultar(Guid id)
        {
            Usuario usuario = _usuarioRepository.SelecionarPorId(id);
            usuario.LimpaConsulta();
            return usuario;
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

        public bool ValidarInserir(Usuario usuario)
        {
            if (_usuarioRepository.SelecionarPorEmail(usuario.Email) != null)
            {
                _notificationContext.AddNotification("Já existe um cadastro com este e-mail.");
                return false;
            }

            return true;
        }
    }
}
