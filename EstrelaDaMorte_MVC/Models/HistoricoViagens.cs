using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstrelaDaMorte_MVC.Models {
    public class HistoricoViagens {

        public int IdNave { get; set; }
        public int IdPiloto { get; set; }
        public DateTime DtSaida { get; set; }
        public DateTime DtChegada { get; set; }

    }
}
