using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstrelaDaMorte_MVC.Models {
    public class Piloto {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPiloto { get; set; }
        public string Nome { get; set; }
        public string AnoNascimento { get; set; }

        [ForeignKey("Planeta")]
        public int IdPlaneta { get; set; }
        public Planeta Planeta { get; set; }

        //public List<Nave> Naves { get; set; }
    }
}