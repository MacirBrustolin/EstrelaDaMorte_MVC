using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstrelaDaMorte_MVC.Models {

    public class Nave {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdNave { get; set; }
        public string Nome { get; set; }
        public string Modelo { get; set; }
        public int Passageiros { get; set; }
        public double Carga { get; set; }
        public string Classe { get; set; }
    }
}