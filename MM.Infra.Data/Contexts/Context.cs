using Microsoft.EntityFrameworkCore;
using System.Linq;
using MM.Domain;
using Microsoft.EntityFrameworkCore.Storage;
using MM.Infra.Data.Mapping;
using System;

namespace MM.Infra.Data.Contexts
{
    public class Context : DbContext
    {
        private string _connectionString = @"Data Source=(localdb)\MoneyManager;Initial Catalog=master;Integrated Security=True;Connect ";

        public DbSet<Usuario> Usuarios { get; set; }

        public IDbContextTransaction Transaction { get; private set; }

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(_connectionString);
        }

        public IDbContextTransaction InitTransacao()
        {
            if (Transaction == null) Transaction = this.Database.BeginTransaction();
            return Transaction;
        }


        private void RollBack()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
            }
        }
        private void Salvar()
        {
            try
            {
                ChangeTracker.DetectChanges();
                SaveChanges();
            }
            catch (Exception ex)
            {
                RollBack();
                throw new Exception(ex.Message);
            }
        }

        private void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction.Dispose();
                Transaction = null;
            }
        }

        public void SendChanges()
        {
            Salvar();
            Commit();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }
    }
}
