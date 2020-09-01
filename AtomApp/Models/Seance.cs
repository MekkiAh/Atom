using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtomApp.Models
{
    public class Seance
    {   
        [Key]
        public int Id { get; set; }
        public string date { get; set; }
        public virtual Classe classe { get; set; }
        public virtual Matiere matiere { get; set; }
        public virtual ICollection<Absence> absences { get; set; }
    }
}
