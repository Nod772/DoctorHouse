using DoctorHouse.DAL.Entity;
using DoctorHouse.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorHouse.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<DbUser> _userManager;
        public AccountController(UserManager<DbUser> userManager)
        {
            _userManager = userManager;
        }
      //  [HttpPost("login")]
    //    public async Task<IActionResult> Login([FromBody] UserLoginModel model)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            return BadRequest();
    //        }
    //
    //    }
    }
}
