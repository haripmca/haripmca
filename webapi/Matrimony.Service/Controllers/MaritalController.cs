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
    public class MaritalController : ControllerBase
    {
        readonly IMaritalService maritalServiceobj;

        public MaritalController(IMaritalService maritalService)
        {
            maritalServiceobj = maritalService;
        }

        [HttpPost("PostAddEditMarital")]
        public async Task<int> PostAddEditMarital(Marital marital)
        {
            return await maritalServiceobj.PostMarital(marital);
        }

        [HttpGet("GetMaritalsResults")]
        public List<Marital> GetMaritals(string maritalname)
        {
            return maritalServiceobj.GetMaritals(maritalname);
        }

        [HttpGet("DeleteMaritalResults")]
        public int DeleteMarital(int maritalid)
        {
            return maritalServiceobj.DeleteMarital(maritalid);
        }
    }
}