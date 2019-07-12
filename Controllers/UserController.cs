using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ZILDING_CORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userServices;

        public UserController(IUserService user)
        {
            _userServices = user;
        }

        [HttpGet]
        [Route("AllUsers")]
        public IActionResult Get()
        {
            //try
            //{
            //    var User = _userServices. GetAllUsers();
            //    return Request.CreateResponse(HttpStatusCode.OK, User);
            //}
            //catch (Exception ex)
            //{
            //}
            return BadRequest();
        }
    }
}