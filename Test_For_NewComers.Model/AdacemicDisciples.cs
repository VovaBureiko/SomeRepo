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

        public double Credit { get; set; }

        public double Score { get; set; }

        [Column("course_project")]
        public bool? CourseProject { get; set; }

        [ForeignKey("block_id")]
        public AcedemicDiscipleBlocks AcedemicDiscipleBlocks { get; set; }

        [ForeignKey("depart_spec_id")]
        public Departament_Specialties Departament_Specialties { get; set; }

        [ForeignKey("disc_id")]
        public Disciplines Disciplines { get; set; }
    }
}