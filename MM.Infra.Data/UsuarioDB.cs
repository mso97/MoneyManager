using MM.Domain;
using MM.Infra.Data.Core;
using MM.Infra.Data.Interface;

namespace MM.Infra.Data
{
    public class UsuarioDB : DatabaseBase<Usuario>, IUsuarioDB
    {
        public UsuarioDB()
        {
            SetCollection("Usuario");
        }
    }
}
