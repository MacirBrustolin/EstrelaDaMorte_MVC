using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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


        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.Entity<Nave>().HasKey(ba => new { ba.NaveId }).HasName("PK_Naves");
            modelBuilder.Entity<Planeta>().HasKey(ba => new { ba.PlanetaId }).HasName("PK_Pilotos");
            modelBuilder.Entity<Piloto>().HasKey(ba => new { ba.PilotoId }).HasName("PK_Planetas");
            modelBuilder.Entity<PilotosNaves>().HasKey(ba => new { ba.PilotoId }).HasName("PK_PilotosNaves");


            modelBuilder.Entity<PilotosNaves>()
                .HasOne(x => x.Naves)
                .WithMany(x => x.PilotoNaves)
                .HasForeignKey(x => x.NaveId);

            modelBuilder.Entity<PilotosNaves>()
              .HasOne(x => x.Pilotos)
              .WithMany(x => x.PilotoNaves)
              .HasForeignKey(x => x.PilotoId);

            
        }
        #endregion


    }
}
