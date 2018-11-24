using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_For_NewComers.Model
{
    [Table("Departament_Specialties")]
    public class Departament_Specialties
    {
        public int Id { get; set; }

        public Specialty Specialty { get; set; }

        public Departament Departament { get; set; }

        public List<AdacemicDisciples> AdacemicDisciples { get; set; }

        public List<Specializations> Specializations { get; set; }
    }
}