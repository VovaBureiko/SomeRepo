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

        public TestController(ITestPreparationService testPreparation)
        {
            _testPreparation = testPreparation;
        }


        [HttpGet("specialization")]
        public async Task<IActionResult> Specialization()
        {
            var specializations = await _testPreparation.GetAllSpecializations();

            return Json(specializations);
        }
    }
}
