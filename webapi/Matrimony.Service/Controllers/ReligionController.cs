using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Matrimony.Entities;
using Matrimony.Entities.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Matrimony.Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReligionController : ControllerBase
    {
        readonly IReligionService religionServiceobj;

        public ReligionController(IReligionService religionService)
        {
            religionServiceobj = religionService;
        }

        //// GET api/values
        //[HttpGet]
        //public ActionResult<IEnumerable<string>> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/values/5
        //[HttpGet("{id}")]
        //public ActionResult<string> Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost("PostReligionsInsert")]
        public async Task<int> PostAdd(Religion religions)
        {
            try
            {
                return await religionServiceobj.PostReligionsAsync(religions).ConfigureAwait(false); ;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        [HttpPost("PostReligionsUpdate")]
        public async Task<int> PostUpdate(Religion religions)
        {
            try
            {
                return await religionServiceobj.PostReligionsAsyncUpdate(religions).ConfigureAwait(false); ;
            }
            catch (Exception ex)
            {
                return 0;
                throw ex;
            }
        }

        [HttpGet("ReligionResultsView")]
        public List<ReligionResult> ReligionResults(Religion religions)
        {
            try
            {
                return religionServiceobj.ReligionResults(religions);
            }
            catch (Exception ex)
            {
               throw;
            }
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/values/5
        [HttpDelete("ReligionDelete")]
        public async Task<IActionResult> Delete([FromBody] List<Religion> religions)
        {
             await religionServiceobj.ReligionDelete(religions).ConfigureAwait(false);
            return StatusCode((int)HttpStatusCode.Gone);
        }
    }
}
