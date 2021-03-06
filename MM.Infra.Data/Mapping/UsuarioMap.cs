﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MM.Domain;
using System.Security.Cryptography.X509Certificates;

namespace MM.Infra.Data.Mapping
{
    public class UsuarioMap : MapBase<Usuario>
    {
        public override void Configure(EntityTypeBuilder<Usuario> builder)
        {
            base.Configure(builder);
            builder.ToTable("Usuario");

            builder.Property(c => c.Nome).IsRequired().HasMaxLength(50);

            builder.Property(c => c.Apelido).HasMaxLength(50);

            builder.Property(c => c.Email).IsRequired().HasMaxLength(100);

            builder.Property(c => c.DataNascimento);

            builder.Property(c => c.Cpf).HasMaxLength(11);

            builder.Property(c => c.Telefone);

            builder.Property(c => c.Genero);

            builder.Property(c => c.DataCadastro).IsRequired();

            builder.Property(c => c.Senha).IsRequired().HasMaxLength(500);

            builder.Property(c => c.Salt).IsRequired().HasMaxLength(500);

            builder.Property(c => c.Role).IsRequired().HasMaxLength(100);

            builder.Ignore(c => c.Token);
        }
    }
}
