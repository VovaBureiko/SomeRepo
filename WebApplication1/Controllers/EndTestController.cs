﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Test_For_NewComers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EndTestController : ControllerBase
    {
        public async Task<IActionResult> Result(string userId)
        {

        }
    }
}