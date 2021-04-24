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
    public class CasteController : ControllerBase
    {
        readonly ICasteService casteServiceobj;

        public CasteController(ICasteService casteService)
        {
            casteServiceobj = casteService;
        }

        [HttpGet("GetCastes")]
        public List<Caste> GetCastes(string casteName)
        {
            return casteServiceobj.GetCastes(casteName);
        }

        [HttpPost("PostCastes")]
        public Task<int> PostCastes(Caste caste)
        {
            return casteServiceobj.PostCastes(caste);
        }

        [HttpDelete("DeleteCaste")]
        public int DeleteCaste(int anyCasteId)
        {
            return casteServiceobj.DeleteCaste(anyCasteId);
        }
    }
}