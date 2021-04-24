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
    public class AnnualIncomeCurrencyController : ControllerBase
    {
        readonly IAnnualIncomeCurrencyService annualIncomeCurrencyServiceobj;

        public AnnualIncomeCurrencyController(IAnnualIncomeCurrencyService annualIncomeCurrencyService)
        {
            annualIncomeCurrencyServiceobj = annualIncomeCurrencyService;
        }

        [HttpGet("GetCastes")]
        public List<AnnualIncomeCurrency> GetCastes(string casteName)
        {
            return annualIncomeCurrencyServiceobj.GetAnnualIncomeCurrencies(casteName);
        }

        [HttpPost("PostCastes")]
        public Task<int> PostAnnualIncomeCurrency(AnnualIncomeCurrency annualIncomeCurrency)
        {
            return annualIncomeCurrencyServiceobj.PostAnnualIncomeCurrency(annualIncomeCurrency);
        }

        [HttpDelete("DeleteCaste")]
        public int DeleteAnnualIncomeCurrency(int anyCasteId)
        {
            return annualIncomeCurrencyServiceobj.DeleteAnnualIncomeCurrency(anyCasteId);
        }
    }
}