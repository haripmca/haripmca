using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrimony.Entities;
using Matrimony.Entities.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Matrimony.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DisabilityController : ControllerBase
    {

        readonly IDisabilityService disabilityServiceobj;

        public DisabilityController(IDisabilityService disabilityService)
        {
            disabilityServiceobj = disabilityService;
        }

        [HttpGet("GetDisability")]
        public List<Disability> GetDisability(string disabiltiesName)
        {
            return disabilityServiceobj.GetDisability(disabiltiesName);
        }

        [HttpPost("PostDisability")]
        public Task<int> PostDisability(Disability disability)
        {
            return disabilityServiceobj.PostDisability(disability);
        }

        [HttpPost("DeleteDisability")]
        public int DeleteDisability(int anyDisabilityId)
        {
            return disabilityServiceobj.DeleteDisability(anyDisabilityId);
        }
    }
}