using Microsoft.EntityFrameworkCore;
using Test_For_NewComers.Model;

namespace Test_For_NewComers.DAL
{
    public class DisciplesContext : DbContext
    {

        public DbSet<AcedemicDiscipleBlocks> AcedemicDiscipleBlocks { get; set; }

        public DbSet<AdacemicDisciples> AdacemicDisciples { get; set; }

        public DbSet<Departament> Departaments { get; set; }

        public DbSet<Disciplines> Disciplines { get; set; }

        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Specialty> Specialties { get; set; }

        public DbSet<Departament_Specialties> Departament_Specialties { get; set; }

        public DisciplesContext(DbContextOptions<DisciplesContext> options) : base(options)
        {
        }
    }
}