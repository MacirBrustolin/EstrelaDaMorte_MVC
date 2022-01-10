using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstrelaDaMorte_MVC.Models {
    public class PilotosNaves {

        [ForeignKey("Piloto")]
        public int IdPiloto { get; set; }
        public Piloto Piloto { get; set; }

        [ForeignKey("Nave")]
        public int IdNave { get; set; }
        public Nave Nave { get; set; }

        public bool FlagAutorizado { get; set; }

        //public List<Nave> Naves { get; set; }
        //public List<Piloto> Pilotos { get; set; }
    }
}
