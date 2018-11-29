using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test_For_NewComers.BLL.DTO;
using Test_For_NewComers.DAL;

namespace Test_For_NewComers.BLL.Services
{
    public class ResultService
    {
        private readonly DisciplesContext _disciplesContext;

        public ResultService(DisciplesContext disciplesContext)
        {
            _disciplesContext = disciplesContext;
        }

        public async Task GetSpecialityRaiting(string userId)
        {
            var userValue = await _disciplesContext.UserResults.FirstAsync(id => id.UserId == userId);

            var academicDisciples = JsonConvert.DeserializeObject<List<AcademicDiscipleDTO>>(userValue.Disciple);

            var groupedAcademicDisciples = academicDisciples.GroupBy(id => id.SpecialDepartment)
                                                            .Select(grouped =>
                                                            new
                                                            {
                                                                disciples = grouped.Select(disc => disc.DiscplId),
                                                                departament = grouped.Key
                                                            }).ToList();

            var disciples = JsonConvert.DeserializeObject<List<DiscipleDTO>>(userValue.Disciple);
            var result = new Dictionary<int, float>();
            foreach(var item in groupedAcademicDisciples)
            {
                var sum = disciples.Where(id => item.disciples.Any(disc => disc == id.Id)).Sum(sumDisc => sumDisc.Weight);
                result.Add(item.departament, sum);
            }

            var specializ = await _disciplesContext.Specializations.ToListAsync();

            var resultBySpecialization = new Dictionary<string, float>();

            foreach(var item in result.Keys)
            {
                var spec = specializ.First(id => id.Departament_Specialties.Id == item).Name;
                resultBySpecialization.Add(spec, result[item]);
            }


        }
    }
}
