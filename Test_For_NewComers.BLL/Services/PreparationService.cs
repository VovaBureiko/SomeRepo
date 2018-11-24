using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test_For_NewComers.BLL.DTO;
using Test_For_NewComers.BLL.Interfaces;
using Test_For_NewComers.BLL.Mapper;
using Test_For_NewComers.DAL;

namespace Test_For_NewComers.BLL.Services
{
    public class PreparationService : ITestPreparationService
    {
        private readonly DisciplesContext _disciplesContext;

        public PreparationService(DisciplesContext disciplesContext)
        {
            _disciplesContext = disciplesContext;
        }

        public async Task<List<SpecializationDTO>> GetAllSpecializations()
        {
            var disciples = await _disciplesContext.Specialties.ToListAsync();

            return disciples.Select(disciple => disciple.ToSpecializationDto()).ToList();
        }

        public async Task<List<>>
    }
}