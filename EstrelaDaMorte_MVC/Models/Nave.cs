using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstrelaDaMorte_MVC.Models {

    public class Nave {

        [Key]
        [Column("IdNave")]
        public int NaveId { get; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public int Passageiros { get; set; }
        public double Carga { get; set; }
        public string Classe { get; set; }


        public virtual ICollection<PilotosNaves> PilotoNaves { get; set; }
    }
}