using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstrelaDaMorte_MVC.Models {
    public class PilotosNaves {

        public int IdPiloto { get; set; }
        public int IdNave { get; set; }
        public bool FlagAutorizado { get; set; }
    }
}
