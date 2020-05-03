using MM.Domain.Core;
using System;

namespace MM.Domain.Interface.Repository
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        Guid Inserir(TEntity entity);
        void Excluir(TEntity entity);
        void Alterar(TEntity entity);
        TEntity SelecionarPorId(int id);
    }
}
