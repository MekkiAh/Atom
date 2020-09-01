using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtomApp.Models
{
    public class Classe
    {
        [Key]
        public int Id { get; set; }
        public string nomClasse { get; set; }
        public int nbMaxEt { get; set; }
        public virtual ICollection<Etudiant> Etudiants { get; set; }
        public virtual ICollection<Seance> Seances { get; set; }

    }
}
