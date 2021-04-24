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
    public class LocationCountryController : ControllerBase
    {
        readonly ILocationCountryService locationCountryServiceobj;

        public LocationCountryController(ILocationCountryService locationCountryService)
        {
            locationCountryServiceobj = locationCountryService;
        }

        [HttpPost("PostLocationCountry")]
        public async Task<int> PostLocationCountry(LocationCountry locationCountry)
        {
            return await locationCountryServiceobj.PostLocationCountry(locationCountry);
        }

        [HttpGet("GetLocationCountry")]
        public List<LocationCountry> GetLocationCountries(string locationName)
        {
            return locationCountryServiceobj.GetLocationCountries(locationName);
        }

        [HttpDelete("DeleteLocationCountry")]
        public int DeleteLocationCountry(int locationId)
        {
            return locationCountryServiceobj.DeleteLocationCountry(locationId);
        }
    }
}