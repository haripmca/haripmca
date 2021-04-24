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
    public class EducationController : ControllerBase
    {
        readonly IEducationService educationServiceobj;

        public EducationController(IEducationService educationService)
        {
            educationServiceobj = educationService;
        }

        [HttpGet("GetEducations")]
        public List<Education> GetEducations(string EducationName)
        {
            return educationServiceobj.GetEducations(EducationName);
        }

        [HttpGet("PostEducation")]
        public Task<int> PostEducation(Education education)
        {
            return educationServiceobj.PostEducation(education);
        }

        [HttpGet("DeleteEducation")]
        public int DeleteEducation(int educationId)
        {
            return educationServiceobj.DeleteEducation(educationId);
        }
    }
}