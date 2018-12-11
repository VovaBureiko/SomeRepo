using Test_For_NewComers.BLL.DTO;
using Test_For_NewComers.Model;

namespace Test_For_NewComers.BLL.Mapper
{
    public static class SpecializationMapper
    {
        private static int SpecialityWeight = 1;

        public static SpecializationDTO ToSpecializationDto(this Specialty source)
        {
            return new SpecializationDTO
            {
                Id = source.Id,
                Label = source.Name,
                Weight = SpecialityWeight
            };
        }

        public static DisciplesBlocksDTO ToDesciplesBlockDto(this AcedemicDiscipleBlocks source)
        {
            return new DisciplesBlocksDTO
            {
                Id = source.Id,
                Label = source.Label,
                Score = source.Sum,
                IsShown = false,
                SpecialDepartment = source.Departament_Specialties.Id
            };
        }

        public static DiscipleDTO ToDiscipleDto(this Disciplines source)
        {
            return new DiscipleDTO
            {
                Id =source.Id,
                Weight = 0,
                IsShown = false
            };

        }

        public static DepartSpecialDTO ToDepartamnetSpecializationDto(this Departament_Specialties source)
        {
            return new DepartSpecialDTO
            {
                Id = source.Id,
                DepartamnetId = source.Departament.Id,
                SpecialId = source.Specialty.Id
            };
        }

        public static AcademicDiscipleDTO ToAcademicDiscDto(this AdacemicDisciples source)
        {
            return new AcademicDiscipleDTO
            {
                Id = source.Id,
                Credit = source.Credit,
                DiscplId = source.Disciplines.Id,
                Term = source.Term,
                SpecialDepartment = source.Departament_Specialties.Id,
                BlockId = source.AcedemicDiscipleBlocks.Id,
                IsShown = false,
                Score = (float)source.Score
            };
        }
    }
}