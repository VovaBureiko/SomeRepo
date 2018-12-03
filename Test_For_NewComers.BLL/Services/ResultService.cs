using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_For_NewComers.BLL.DTO;
using Test_For_NewComers.BLL.Interfaces;
using Test_For_NewComers.DAL;

namespace Test_For_NewComers.BLL.Services
{
    public class ResultService : IResultService
    {
        private readonly DisciplesContext _disciplesContext;
        private readonly ILogger<ResultService> _logger;
        private const int MaxValue = 198;

        public ResultService(DisciplesContext disciplesContext,
                            ILogger<ResultService> logger)
        {
            _disciplesContext = disciplesContext;
            _logger = logger;
        }

        public async Task<List<ResultDTO>> GetSpecialityRaiting(string userId)
        {
            var userValue = await _disciplesContext.UserResults.FirstAsync(id => id.UserId == userId);

            var academicDisciples = JsonConvert.DeserializeObject<List<AcademicDiscipleDTO>>(userValue.AcademicDisciple);

            var groupedAcademicDisciples = academicDisciples.GroupBy(group => group.SpecialDepartment)
                                                            .Select(group => new
                                                            {
                                                                SpecializDepartamnetId = group.Key,
                                                                Sum = group.Sum(score => score.NewScore)
                                                            }).ToList();

            var departamnets = await _disciplesContext.Specializations
                .Include(p => p.Departament_Specialties)
                .ToListAsync();

            List<ResultDTO> totalResult = departamnets.Join(groupedAcademicDisciples,
                               specialization => specialization.Departament_Specialties.Id,
                               grouped => grouped.SpecializDepartamnetId,
                               (spec, grouped) => new ResultDTO
                               {
                                   Id = spec.Id,
                                   Name = spec.Name,
                                   Score = grouped.Sum / MaxValue
                               }).ToList();

            var logData = JsonConvert.SerializeObject(totalResult);
            _logger.LogCritical("The final result is", userId, logData);
            return totalResult;
        }
    }
}
