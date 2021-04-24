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
    public class FamilyStatusController : ControllerBase
    {

        readonly IFamilyStatusService familyStatusServiceobj;

        public FamilyStatusController(IFamilyStatusService familyStatusService)
        {
            familyStatusServiceobj = familyStatusService;
        }

        [HttpGet("GetFamilyStatus")]
        public List<FamilyStatus> GetFamilyStatus(string familystatus)
        {
            return familyStatusServiceobj.GetFamilyStatus(familystatus);
        }

        [HttpPost("PostFamilyStatus")]
        public Task<int> PostFamilyStatus(FamilyStatus familyStatus)
        {
            return familyStatusServiceobj.PostFamilyStatus(familyStatus);
        }

        [HttpDelete("DeleteFamilyStatus")]
        public int DeleteFamilyStatus(int familyStatusId)
        {
            return familyStatusServiceobj.DeleteFamilyStatus(familyStatusId);
        }
    }
}