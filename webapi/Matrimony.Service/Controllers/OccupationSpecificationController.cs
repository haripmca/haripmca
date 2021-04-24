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
    public class OccupationSpecificationController : ControllerBase
    {
        readonly IOccupationSpecificationService occupationSpecificationServiceobj;

        public OccupationSpecificationController(IOccupationSpecificationService occupationSpecificationService)
        {
            occupationSpecificationServiceobj = occupationSpecificationService;
        }


        [HttpPost("PostAddEdit")]
        public async Task<int> PostAddEdit(OccupationSpecification occupationSpecification)
        {
            try
            {
                return await occupationSpecificationServiceobj.PostOccupationSpec(occupationSpecification).ConfigureAwait(true);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("GetOccupationSpecDetails")]
        public List<OccupationSpecification> OccupationSpecificationsResults(string occupationSpecification)
        {
            try
            {
                return occupationSpecificationServiceobj.OccupationSpecificationServiceResults(occupationSpecification);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("DeleteOccupationSpec")]
        public int DeleteOccupationSpec(int occupationSpecificationId)
        {
            return occupationSpecificationServiceobj.DeleteOccupationSpec(occupationSpecificationId);
        }
    }
}