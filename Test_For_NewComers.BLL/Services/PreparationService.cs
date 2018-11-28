using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
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
            var specialties = await GetAllSpealities();
            var userId = Guid.NewGuid().ToString();

            await SaveUserInformationInDatabase(userId);

            var result = new TestPreparationDTO
            {
                UserId = userId,
                SpecializationDTO = specialties.Select(speciality => speciality.ToSpecializationDto()).ToList()
            };

            return result;
        }

        private async Task SaveUserInformationInDatabase(string userId)
        {
            var departamnetSpecilities = GetAllDepartamnetSpecility();
            var disciples = GetAllDisciples();
            var acadimSubjects = GetAllAcademicDisciples();
            var blocks = GetAllBlocks();

            await Task.WhenAll(departamnetSpecilities, disciples, acadimSubjects, blocks);

            

            var departamnetSpecialityString = JsonConvert.SerializeObject(departamnetSpecilities.Result.Select(element => element.ToDepartamnetSpecializationDto()).ToList());
            var discipleString = JsonConvert.SerializeObject(disciples.Result.Select(element => element.ToDiscipleDto()));
            var academicDiscipleString = JsonConvert.SerializeObject(acadimSubjects.Result.Select(element => element.ToAcademicDiscDto()).ToList());
            var blockString = JsonConvert.SerializeObject(blocks.Result.Select(block => block.ToDesciplesBlockDto()).ToList());

            var user = new UserResults
            {
                UserId = userId,
                AcademicDisciple = academicDiscipleString,
                Disciple = discipleString,
                SpecialityByDepartment = departamnetSpecialityString,
                DiscipleBlock = blockString
            };

            await _disciplesContext.UserResults.AddAsync(user);

            await _disciplesContext.SaveChangesAsync();
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