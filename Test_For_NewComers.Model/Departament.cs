using System.ComponentModel.DataAnnotations;

namespace Test_For_NewComers.Model
{
    public class Departament
    {
        [Key]
        public int Id { get; set; }

        public int Name { get; set; }

        public virtual Faculty Faculty { get; set; }
    }
}