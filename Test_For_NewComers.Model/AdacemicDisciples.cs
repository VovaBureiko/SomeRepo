using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_For_NewComers.Model
{
    [Table("Academic_Disciplines")]
    public class AdacemicDisciples
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int Term { get; set; }

        public decimal? Credit { get; set; }

        public decimal? Score { get; set; }

        [Column("Course_project")]
        public bool? CourseProject { get; set; }

        public virtual List<AcedemicDiscipleBlocks> AcedemicDiscipleBlocks { get; set; }

        public virtual List<Departament_Specialties> Departament_Specialties { get; set; }
    }
}