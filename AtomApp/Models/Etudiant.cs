using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtomApp.Models
{
    public class Etudiant
    {   [Key]
        public int Id { get; set; }
        public string nom { get; set; }
        public string adresse { get; set; }
        public string cin{ get; set; }
        public string numTel { get; set; }
        public string email { get; set; }
        public virtual Classe classe { get; set; }
        public virtual ICollection<Absence> absences { get; set; }
    }
}
