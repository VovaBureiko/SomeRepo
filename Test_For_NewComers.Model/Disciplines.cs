using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_For_NewComers.Model
{
    [Table("Disciple")]
    public class Disciplines
    {
        [Key]
        [Column("id_discipl")]
        public int Id { get; set; }

        public string Name { get; set; }

        public List<AdacemicDisciples> AdacemicDisciples { get; set; }
    }
}