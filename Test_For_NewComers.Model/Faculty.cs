using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_For_NewComers.Model
{
    [Table("Faculty")]
    public class Faculty
    {
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        public virtual ICollection<Departament> Departaments { get; set; }
    }
}