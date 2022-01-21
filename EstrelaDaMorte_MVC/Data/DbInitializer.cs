using EstrelaDaMorte_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EstrelaDaMorte_MVC.Data {
    public static class DbInitializer {
        public static void Initialize(ApplicationDbContext context) {
            context.Database.EnsureCreated();

            // Verifica se há alguma nave, planeta ou piloto.
            if (context.Naves.Any() && context.Pilotos.Any() && context.Planetas.Any()) {
                return;   // DB has been seeded
            }

            var naves = new Nave[]
            {
            
            };
            foreach (Nave s in naves) {
                context.Naves.Add(s);
            }
            context.SaveChanges();

            var pilotos = new Piloto[]
            {
            
            };
            foreach (Piloto c in pilotos) {
                context.Pilotos.Add(c);
            }
            context.SaveChanges();

            var planetas = new Planeta[]
            {
            
            };
            foreach (Planeta e in planetas) {
                context.Planetas.Add(e);
            }
            context.SaveChanges();
        }
    }
}
