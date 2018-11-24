using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_For_NewComers.Model
{
    [Table("Departament_Specialties")]
    public class Departament_Specialties
    {
        public int Id { get; set; }

        public virtual Specialty Specialty { get; set; }

        public virtual Departament Departament { get; set; }

        public virtual List<AdacemicDisciples> AdacemicDisciples { get; set; }

        public virtual List<AcedemicDiscipleBlocks> AcedemicDiscipleBlocks { get; set; }
    }
}