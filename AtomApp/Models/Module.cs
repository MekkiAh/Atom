using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AtomApp.Models
{
    public class Module
    {
        [Key]
        public int Id { get; set; }
        public string nomModule { get; set; }
        public virtual ICollection<Matiere> matieres { get; set; }
    }
}
