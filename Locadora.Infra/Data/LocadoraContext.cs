using Locadora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Locadora.Infra.Data
{
    public class LocadoraContext : DbContext
    {
        public LocadoraContext() { }

        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options) { }

        public DbSet<Filme> Filmes { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                    entry.Property("UltimaAlteracao").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UltimaAlteracao").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Deleted)
                {
                    entry.Property("UltimaAlteracao").CurrentValue = DateTime.Now;
                    entry.Property("Deletado").CurrentValue = true;
                }
            }
            return base.SaveChanges();
        }
    }
}
