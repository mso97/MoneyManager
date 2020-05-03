using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MM.Domain.Core;

namespace MM.Infra.Data.Mapping
{
    public class MapBase<T> : IEntityTypeConfiguration<T> where T : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).IsRequired();
        }
    }
}
