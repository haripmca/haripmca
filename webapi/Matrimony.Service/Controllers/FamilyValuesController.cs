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
    public class FamilyValuesController : ControllerBase
    {
        readonly IFamilyValuesService familyValuesServiceobj;

        [HttpGet("GetHeights")]
        public List<FamilyValues> GetFamilyValues(string familyvalues)
        {
            return familyValuesServiceobj.GetFamilyValues(familyvalues);
        }

        [HttpPost("PostFamilyValues")]
        public Task<int> FamilyValues(FamilyValues familyValues)
        {
            return familyValuesServiceobj.PostFamilyValues(familyValues);
        }

        [HttpPost("DeleteFamilyValues")]
        public int DeleteFamilyValues(int familyvaluesId)
        {
            return familyValuesServiceobj.DeleteFamilyValues(familyvaluesId);
        }
    }
}