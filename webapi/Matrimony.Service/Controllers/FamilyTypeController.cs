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
    public class FamilyTypeController : ControllerBase
    {
        readonly IFamilyTypeService familyTypeServiceobj;

        
        public FamilyTypeController(IFamilyTypeService familyTypeService)
        {
            familyTypeServiceobj = familyTypeService;
        }

        [HttpGet("GetFamilyTypes")]
        public List<FamilyType> GetFamilyTypes(string familytype)
        {
            return familyTypeServiceobj.GetFamilyTypes(familytype);
        }

        [HttpPost("PostFamilyTypes")]
        public Task<int> FamilyTypes(FamilyType familyType)
        {
            return familyTypeServiceobj.PostFamilyType(familyType);
        }

        [HttpGet("DeleteFamilyTypes")]
        public int DeleteFamilyTypes(int familytypesId)
        {
            return familyTypeServiceobj.DeleteFamilyType(familytypesId);
        }
    }
}