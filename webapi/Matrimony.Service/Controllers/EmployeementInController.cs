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
    public class EmployeementInController : ControllerBase
    {
        readonly IEmployeementInService employeementInServiceobj;

        public EmployeementInController(IEmployeementInService employeementInService)
        {
            employeementInServiceobj = employeementInService;
        }

        [HttpGet("GetEmployeementIns")]
        public List<EmployeementIn> GetEmployeementIns(string EmployeementInName)
        {
           return employeementInServiceobj.GetEmployeementIns(EmployeementInName);
        }

        [HttpPost("PostEmployeementIn")]
        public Task<int> PostEmployeementIn(EmployeementIn familyStatus)
        {
            return employeementInServiceobj.PostEmployeementIn(familyStatus);
        }

        [HttpDelete("DeleteEmployeementIn")]
        public int DeleteEmployeementIn(int familyStatusId)
        {
            return employeementInServiceobj.DeleteEmployeementIn(familyStatusId);
        }
    }
}