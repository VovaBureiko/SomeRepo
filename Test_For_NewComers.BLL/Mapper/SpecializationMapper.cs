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
    }
}