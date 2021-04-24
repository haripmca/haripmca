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
    public class HeightController : ControllerBase
    {
        readonly IHeightSerice heightSericeobj;

        public HeightController(IHeightSerice heightSerice)
        {
            heightSericeobj = heightSerice;
        }

        [HttpPost("GetHeights")]
        public List<Height> GetHeights(string heightType)
        {
            return heightSericeobj.GetHeights(heightType);
        }

        [HttpPost("PostHeight")]
        public Task<int> PostHeight(Height height)
        {
            return heightSericeobj.PostHeight(height);
        }

        [HttpPost("DeleteHeight")]
        public int DeleteHeight(int heightId)
        {
            return heightSericeobj.DeleteHeight(heightId);
        }
    }
}