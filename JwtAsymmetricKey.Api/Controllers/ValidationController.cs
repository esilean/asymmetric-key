﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAsymmetricKey.Api.Controllers
{
    [Route("identity/[controller]")]
    public class ValidationController : ControllerBase
    {
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public IActionResult Validate()
        {
            return Ok();
        }
    }
}
