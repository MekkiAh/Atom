using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace AtomApp.Models
{
    public class EcoleContext: DbContext
    {
        public EcoleContext(DbContextOptions<EcoleContext> options): base(options)
        { 
        }
        public DbSet<Classe> classes { get; set; }
        public DbSet<Etudiant> etudiants { get; set; }
        public DbSet<Absence> absences { get; set; }
        public DbSet<Seance> seances { get; set; }
        public DbSet<Matiere> matieres { get; set; }
        public DbSet<Module> modules { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Absence>()
                .HasKey(ab => new { ab.etudiantId, ab.seanceId });
        }


    }
}
