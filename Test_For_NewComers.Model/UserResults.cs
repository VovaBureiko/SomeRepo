using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_For_NewComers.Model
{
    [Table("User_Results")]
    public class UserResults
    {
        [Key]
        public string UserId { get; set; }

        [Column("speciality_by_department")]
        public string SpecialityByDepartment { get; set; }

        public string Disciple { get; set; }

        [Column("Academic_Disciple")]
        public string AcademicDisciple { get; set; }

        [Column("disciple_block")]
        public string DiscipleBlock { get; set; }

        [Column("is_all_specialities")]
        public bool IsSpecializationProcessed { get; set; }
    }
}