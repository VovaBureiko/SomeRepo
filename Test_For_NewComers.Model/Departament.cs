using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test_For_NewComers.Model
{
    public class Departament
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }

        public Faculty Faculty { get; set; }

        public List<Departament_Specialties> Departament_Specialties { get; set; }
    }
}