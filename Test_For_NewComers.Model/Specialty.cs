using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_For_NewComers.Model
{
    [Table("Specialties")]
    public class Specialty
    {
        [Key]
        public int Id { get; set; }

        [Column("Name")]
        public string Name { get; set; }

        public virtual AcedemicDiscipleBlocks AcedemicDiscipleBlocks { get; set; }
    }
}