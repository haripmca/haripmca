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
    public class OccupationController : ControllerBase
    {
        readonly IOccupationService occupationServiceobj;

        public OccupationController(IOccupationService occupationService)
        {
            occupationServiceobj = occupationService;
        }

        [HttpPost("PostAddEditOccupation")]
        public async Task<int> PostAddEditOccupation(Occupation occupation)
        {
            try
            {
                return await occupationServiceobj.PostOccuptions(occupation).ConfigureAwait(false);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("GetoccupationsResults")]

        public List<Occupation> occupationsResults(string occupationName)
        {
            try
            {
                return occupationServiceobj.Occupations(occupationName);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("GetDeleteOccupation")]
        public int DeleteOccupation(int occupationId)
        {
            return occupationServiceobj.DeleteOccupation(occupationId);
        }
    }
}