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

        public int Term { get; set; }

        public decimal? Credit { get; set; }

        public decimal? Score { get; set; }

        [Column("course_project")]
        public bool? CourseProject { get; set; }

        public AcedemicDiscipleBlocks AcedemicDiscipleBlocks { get; set; }

        public Departament_Specialties Departament_Specialties { get; set; }

        public Disciplines Disciplines { get; set; }
    }
}