using MM.Domain.Interface;
using MM.Service.Interface;

namespace MM.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuario _domain;

        public UsuarioService(IUsuario domain)
        {
            _domain = domain;
        }

        public string resultado()
        {
            return _domain.resultado();
        }
    }
}
