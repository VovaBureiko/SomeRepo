using System.Collections.Generic;

namespace Test_For_NewComers.BLL.DTO
{
    public class TestPreparationDTO
    {
        public List<DiscipleDTO> Disciples { get; set; }

        public List<DepartSpecialDTO> DepartSpecialDTO { get; set; }

        public List<SpecializationDTO> SpecializationDTO { get; set; }

        public List<DisciplesBlocksDTO> BlocksDTO { get; set; }

        public List<AcademicDiscipleDTO> AcademicDiscipleDTO { get; set; }
    }
}