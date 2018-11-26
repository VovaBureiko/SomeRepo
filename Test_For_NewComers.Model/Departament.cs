using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_For_NewComers.Model
{
    [Table("Departament")]
    public class Departament
    {
        [Key]
        [Column("id_departament")]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("id_faculty")]
        public Faculty Faculty { get; set; }

        public List<Departament_Specialties> Departament_Specialties { get; set; }
    }
}