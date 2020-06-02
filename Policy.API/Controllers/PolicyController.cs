using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Policy.Service.Entity;
using Policy.Service.Interface;


namespace Policy.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PolicyController : ControllerBase
    {

        private readonly ILogger<PolicyController> _logger;
        private readonly IPolicyService _policyService;

        public PolicyController(IPolicyService policyService, ILogger<PolicyController> logger)
        {
            _policyService = policyService;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get(string policyNumber)
        {
            if(string.IsNullOrEmpty(policyNumber.Trim()))
            {
                return BadRequest("Please provide the valid policy number");
            }            
            return Ok(_policyService.GetPolicyDetail(policyNumber));
        }
    }
}
