using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EstrelaDaMorte_MVC.Models {
    public class PilotosNaves {

        [Column("IdPiloto")]
        public int PilotoId { get; set; }
        [Column("IdNave")]
        public int NaveId { get; set; }

        public Nave Naves { get; set; }
        public Piloto Pilotos { get; set; }
    }
}
