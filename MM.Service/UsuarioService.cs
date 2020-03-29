using Google.Cloud.Firestore;
using MM.Domain;
using MM.Infra.Data.Interface;
using MM.Service.Interface;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MM.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioDB _usuarioDB;

        public UsuarioService(IUsuarioDB usuarioDB)
        {
            _usuarioDB = usuarioDB;
        }

        public Task<string> Inserir(Usuario usuario)
        {
            usuario.SetSalt(CreateSalt());
            usuario.SetSenha(CreateHash(usuario.Senha, usuario.Salt));

            return _usuarioDB.Inserir(usuario);
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
