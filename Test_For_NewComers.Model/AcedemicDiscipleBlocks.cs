using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_For_NewComers.Model
{
    [Table("Academic_Disciples_Block")]
    public class AcedemicDiscipleBlocks
    {
        [Key]
        public int Id { get; set; }

        [Column("block_sum")]
        public double Sum { get; set; }

        public string Label { get; set; }

        public List<AdacemicDisciples> AdacemicDisciples { get; set; }

        [ForeignKey("depart_spec_id")]
        public Departament_Specialties Departament_Specialties { get; set; }
    }
}