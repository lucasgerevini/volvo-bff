using System;
using Microsoft.EntityFrameworkCore;
using Volvo.BFF.Models;

namespace Volvo.BFF.Data
{
    public class VolvoContext : DbContext
    {
        public VolvoContext(DbContextOptions<VolvoContext> options) : base(options)
        {
        }
        public DbSet<Caminhao> Caminhoes { get; set; }
        public DbSet<Modelo> Modelos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){
            optionsBuilder.EnableSensitiveDataLogging();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Caminhao>().HasKey(c => c.Id);
            builder.Entity<Caminhao>().Property(c => c.Id)
                                    .ValueGeneratedOnAdd();

            builder.Entity<Modelo>().HasKey(c => c.Sigla);
            
            #region Seed
            builder.Entity<Modelo>().HasData(new[] {
                new Modelo { Sigla = "FH", Permitido = true },
                new Modelo { Sigla = "FM", Permitido = true }
            });

            builder.Entity<Caminhao>().HasData(new[] {
                new Caminhao {Id = 1, SiglaModelo = "FH", AnoFabricacao = DateTime.Now.Year, AnoModelo = DateTime.Now.Year },
                new Caminhao {Id = 2, SiglaModelo = "FM",  AnoFabricacao = DateTime.Now.Year, AnoModelo = DateTime.Now.AddYears(1).Year }
            });
            #endregion

            base.OnModelCreating(builder);
        }
    }
}