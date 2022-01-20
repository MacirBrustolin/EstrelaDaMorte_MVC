using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EstrelaDaMorte_MVC.Models {
    public class Planeta {

        [Column("IdPlaneta")]
        public int PlanetaId { get; }
        public string Nome { get; set; }
        public double Rotacao { get; set; }
        public double Orbita { get; set; }
        public double Diametro { get; set; }
        public string Clima { get; set; }
        public int Populacao { get; set; }

        public List<Piloto> Pilotos { get; set; }
    }
}