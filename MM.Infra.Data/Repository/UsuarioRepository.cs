using MM.Domain;
using MM.Domain.Interface.Repository;
using MM.Infra.Data.Contexts;

namespace MM.Infra.Data.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(Context context)
            : base(context)
        {
        }
    }
}
