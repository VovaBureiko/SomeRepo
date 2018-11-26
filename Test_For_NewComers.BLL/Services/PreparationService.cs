using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_For_NewComers.BLL.DTO;
using Test_For_NewComers.BLL.Interfaces;
using Test_For_NewComers.BLL.Mapper;
using Test_For_NewComers.DAL;
using Test_For_NewComers.Model;

namespace Test_For_NewComers.BLL.Services
{
    public class PreparationService : ITestPreparationService
    {
        private readonly DisciplesContext _disciplesContext;

        public PreparationService(DisciplesContext disciplesContext)
        {
            _disciplesContext = disciplesContext;
        }

        public async Task<TestPreparationDTO> GetAllSpecializations()
        {
            var specialties = GetAllSpealities();
            var departamnetSpecilities =  GetAllDepartamnetSpecility();
            var disciples =  GetAllDisciples();
            var acadimSubjects =  GetAllAcademicDisciples();
            var blocks =  GetAllBlocks();

            await Task.WhenAll(specialties, departamnetSpecilities, disciples, acadimSubjects, blocks);

            var result = new TestPreparationDTO
            {
                Disciples = disciples.Result.Select(disc => disc.ToDiscipleDto()).ToList(),
                AcademicDiscipleDTO = acadimSubjects.Result.Select(subject => subject.ToAcademicDiscDto()).ToList(),
                BlocksDTO = blocks.Result.Select(block => block.ToDesciplesBlockDto()).ToList(),
                DepartSpecialDTO = departamnetSpecilities.Result.Select(depart => depart.ToDepartamnetSpecializationDto()).ToList(),
                SpecializationDTO = specialties.Result.Select(special => special.ToSpecializationDto()).ToList()
            };

            return result;
        }

        private Task<List<Disciplines>>GetAllDisciples()
        {
            return _disciplesContext.Disciplines
                .Include(disciple => disciple.AdacemicDisciples)
                .Where(disciple => disciple.AdacemicDisciples != null && disciple.AdacemicDisciples.Count != 0)
                .ToListAsync();
        }

        private  Task<List<AdacemicDisciples>> GetAllAcademicDisciples()
        {
           return _disciplesContext.AdacemicDisciples
                .Include(discpl => discpl.AcedemicDiscipleBlocks)
                .Where(academic => academic.AcedemicDiscipleBlocks != null)
                .ToListAsync();
        }

        private Task<List<AcedemicDiscipleBlocks>> GetAllBlocks()
        {
            return _disciplesContext.AcedemicDiscipleBlocks
                .Include(block => block.Departament_Specialties)
                .ToListAsync();
        }

        private Task<List<Specialty>> GetAllSpealities()
        {
            return _disciplesContext.Specialties.ToListAsync();
        }

        private Task<List<Departament_Specialties>> GetAllDepartamnetSpecility()
        {
            return _disciplesContext.Departament_Specialties
                .Include(depart => depart.Departament)
                .Include(special => special.Specialty)
                .ToListAsync();
        }
    } 
}