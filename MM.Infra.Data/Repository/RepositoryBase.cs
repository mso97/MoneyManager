using Microsoft.EntityFrameworkCore;
using MM.Domain.Core;
using MM.Domain.Interface.Repository;
using MM.Infra.Data.Contexts;
using System;

namespace MM.Infra.Data.Repository
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly Context context;
        public RepositoryBase(Context context)
            : base()
        {
            this.context = context;
        }

        public void Alterar(TEntity entity)
        {
            context.InitTransacao();
            context.Set<TEntity>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            context.SendChanges();
        }

        public void Excluir(TEntity entity)
        {
            context.InitTransacao();
            context.Set<TEntity>().Remove(entity);
            context.SendChanges();
        }

        public Guid Inserir(TEntity entity)
        {
            context.InitTransacao();
            var id = context.Set<TEntity>().Add(entity).Entity.Id;
            context.SendChanges();
            return id;
        }

        public TEntity SelecionarPorId(Guid id)
        {
            return context.Set<TEntity>().Find(id);
        }
    }
}
