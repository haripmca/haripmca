using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface IEmployeementInService
    {
        List<EmployeementIn> GetEmployeementIns(string EmployeementInName);

        Task<int> PostEmployeementIn(EmployeementIn familyStatus);

        int DeleteEmployeementIn(int familyStatusId);
    }
}
