using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AtomApp.Models
{
    public class Matiere
    {   
        [Key]
        public int Id { get; set; }
        public string nomMatiere { get; set; }
        public virtual Module module { get; set; }

    }
}
