using Matrimony.Entities;
using Matrimony.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class EmployeementInService : IEmployeementInRepository
    {
        readonly IEmployeementInRepository employeementInRepositoryobj;

        public EmployeementInService(IEmployeementInRepository employeementInRepository)
        {
            employeementInRepositoryobj = employeementInRepository;
        }

        public List<EmployeementIn> GetEmployeementIns(string EmployeementInName)
        {
            return employeementInRepositoryobj.GetEmployeementIns(EmployeementInName);
        }


        public Task<int> PostEmployeementIn(EmployeementIn employeementIn)
        {
            return employeementInRepositoryobj.PostEmployeementIn(employeementIn);
        }

        public int DeleteEmployeementIn(int familyStatusId)
        {
            return employeementInRepositoryobj.DeleteEmployeementIn(familyStatusId);
        }
    }
}
