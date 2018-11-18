using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_For_NewComers.Model
{
    [Table("Disciple")]
    public class Disciplines
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
    }
}