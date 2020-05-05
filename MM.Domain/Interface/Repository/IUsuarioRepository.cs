namespace MM.Domain.Interface.Repository
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
        Usuario SelecionarPorEmail(string email);
    }
}
