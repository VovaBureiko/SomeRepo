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
        private const int MaxValue = 198;

        public ResultService(DisciplesContext disciplesContext)
        {
            _disciplesContext = disciplesContext;
        }

        //public async Task GetSpecialityRaiting(string userId)
        //{
        //    var userValue = await _disciplesContext.UserResults.FirstAsync(id => id.UserId == userId);

        //    var academicDisciples = JsonConvert.DeserializeObject<List<AcademicDiscipleDTO>>(userValue.Disciple);

        //    var groupedAcademicDisciples = academicDisciples.GroupBy(group => group.SpecialDepartment)
        //                                                    .Select(group => new
        //                                                    {
        //                                                        SpecializDepartamnetId = group.Key,
        //                                                        Sum = group.Sum(score => score.NewScore)
        //                                                    }).ToList();

        //    var departamnets = await _disciplesContext.Departament_Specialties.ToListAsync();

        //    departamnets.Join(groupedAcademicDisciples,
        //                       departamnets => departamnets.)

        //}
    }
}
