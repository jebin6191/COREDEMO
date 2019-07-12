using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZILDING_CORE.Nlog;

namespace ZILDING_CORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        private ILoggerManager _logger;
        private readonly IAccountService _accountService;

        public ValuesController(ILoggerManager logger, IAccountService  accountService)
        {
            _logger = logger;
            _accountService = accountService;
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var result = _accountService.GetAllAccountDetails();
            return new string[] { "value1", "value2" };
        }
    }
}
