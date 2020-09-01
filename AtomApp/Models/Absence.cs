using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtomApp.Models
{
    public class Absence 
    {
        public int etudiantId { get; set; }
        public int seanceId { get; set; }
        public virtual Etudiant etudiant { get; set; }
        public virtual Seance seance { get; set; }
    }
}
