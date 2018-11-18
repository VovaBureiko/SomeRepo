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

        public virtual Specialty Specialty { get; set; }

        public virtual ICollection<AdacemicDisciples> AdacemicDisciples { get; set; }
    }
}