using System;

namespace MM.Domain.Core
{
    public abstract class EntityBase<TEntity> where TEntity : class
    {
        private Guid Id { get; }
    }
}
