using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test_For_NewComers.BLL.Interfaces;

namespace Test_For_NewComers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndTestController : Controller
    {
        private readonly IResultService _resultService;

        public EndTestController(IResultService resultService)
        {
            _resultService = resultService;
        }

        [HttpGet("result")]
        public async Task<IActionResult> Result(string userId)
        {
            var result = await _resultService.GetSpecialityRaiting(userId);

            return Json(result);
        }
    }
}