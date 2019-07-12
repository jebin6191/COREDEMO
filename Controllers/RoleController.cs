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
    public class RoleController : ControllerBase
    {
        //private readonly IRoleServices _roleServices;

        //public RoleController(IRoleServices role)
        //{
        //    _roleServices = role;
        //}

        //[HttpGet]
        //[Route("AllRoles")]
        //public HttpResponseMessage Get()
        //{
        //    try
        //    {
        //        var Role = _roleServices.GetAllRoles();
        //        return Request.CreateResponse(HttpStatusCode.OK, Role);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ApiDataException(1000, "Role Not Found", HttpStatusCode.NotFound);
        //    }
        //}
    }
}