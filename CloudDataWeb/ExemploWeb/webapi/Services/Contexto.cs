using Microsoft.EntityFrameworkCore;
using RH.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RH.WebApi.Services
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }
        public DbSet<Funcionario> Funcionario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Nome).HasMaxLength(300);
                entity.Property(e => e.Salario).HasColumnType("decimal(18, 2)");
            });
        }
    }
}
