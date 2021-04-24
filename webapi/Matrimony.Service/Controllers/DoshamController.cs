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
    public class DoshamController : ControllerBase
    {
        readonly IDoshamService doshamServiceobj;

        public DoshamController(IDoshamService doshamService)
        {
            doshamServiceobj = doshamService;
        }

        [HttpGet("GetDosham")]
        public List<Dosham> GetDosham(string EducationName)
        {
            return doshamServiceobj.GetDoshams(EducationName);
        }

        [HttpPost("PostDosham")]
        public Task<int> PostDosham(Dosham dosham)
        {
            return doshamServiceobj.PostDosham(dosham);
        }

        [HttpDelete("DeleteDosham")]
        public int DeleteDosham(int doshamId)
        {
            return doshamServiceobj.DeleteDosham(doshamId);
        }

        }
}