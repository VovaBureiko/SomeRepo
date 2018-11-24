using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_For_NewComers.Model
{
    [Table("Specialties")]
    public class Specialty
    {
        [Key]
        [Column("id_Speciaties")]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        public List<Departament_Specialties> AcedemicDiscipleBlocks { get; set; }
    }
}