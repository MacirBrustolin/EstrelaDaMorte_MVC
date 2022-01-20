using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstrelaDaMorte_MVC.Models {
    public class Piloto {

        [Column("IdPiloto")]
        public int PilotoId { get; }
        public string Nome { get; set; }
        public string AnoNascimento { get; set; }

        [Column("IdPlaneta")]
        public int PlanetasId { get; set; }
        public Planeta Planetas { get; set; }

        public virtual ICollection<PilotosNaves> PilotoNaves { get; set; }

        //public List<Nave> Naves { get; set; }
    }
}