﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_For_NewComers.Model
{
    [Table("Specializations")]
    public class Specializations
    {
        [Key]
        public int Id { get; set; }

        [Column("num_specializations")]
        public decimal? NumberSpecialization { get; set; }

        public string Name { get; set; }

        public int? Departament_SpecialtiesId { get; set; }

        public Departament_Specialties Departament_Specialties { get; set; }
    }
}
