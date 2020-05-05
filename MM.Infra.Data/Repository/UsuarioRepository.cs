using MM.Domain;
using MM.Domain.Interface.Repository;
using MM.Infra.Data.Contexts;
using System.Linq;

namespace MM.Infra.Data.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context context) : base(context)
        {
        }

        public Usuario SelecionarPorEmail(string email)
        {
            return context.Set<Usuario>().Where(x => x.Email.Equals(email)).FirstOrDefault();
        }
    }
}
