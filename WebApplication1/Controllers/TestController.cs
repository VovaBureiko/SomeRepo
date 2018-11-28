using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Test_For_NewComers.BLL.Interfaces;

namespace Test_For_NewComers.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly ITestPreparationService _testPreparation;
        private readonly ITestAnalyzer _testAnalyzer;

        public TestController(
            ITestPreparationService testPreparation,
            ITestAnalyzer testAnalyzer)
        {
            _testPreparation = testPreparation;
            _testAnalyzer = testAnalyzer;
        }


        [HttpGet("specialization")]
        public async Task<IActionResult> Specialization()
        {
            var specializations = await _testPreparation.GetAllSpecializations();

            var model = new
            {
                UserId = specializations.UserId,
                disciples = specializations.SpecializationDTO
            };

            return Json(model);
        }

        public async Task<IActionResult> ProcessSpecialization(Dictionary<int, float> userChoose, string userId)
        {
            var blocks = await _testAnalyzer.AnalyzeSelectedSpecialization(userId, userChoose);

            var model = blocks.Take(10).Select(block => new
            {
                block.Id,
                block.Label
            });

            return Json(model);
        }
    }
}
