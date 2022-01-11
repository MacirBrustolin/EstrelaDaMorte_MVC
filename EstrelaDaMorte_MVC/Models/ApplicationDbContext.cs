using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstrelaDaMorte_MVC.Models {
    public class ApplicationDbContext : DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
            
        }


        public DbSet<Nave> Naves { get; set; }
        public DbSet<Piloto> Pilotos { get; set; }
        public DbSet<Planeta> Planetas { get; set; }
        public DbSet<PilotosNaves> PilotosNaves { get; set; }
        public DbSet<HistoricoViagens> HistoricoViagens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Nave>().HasKey(ba => new { ba.IdNave });
            modelBuilder.Entity<Planeta>().HasKey(ba => new { ba.IdPlaneta });
            modelBuilder.Entity<Piloto>().HasKey(ba => new { ba.IdPiloto });
            modelBuilder.Entity<PilotosNaves>().HasKey(ba => new { ba.IdPiloto, ba.IdNave });
            modelBuilder.Entity<HistoricoViagens>().HasKey(ba => new { ba.IdPiloto, ba.IdNave });
        }


    }
}
