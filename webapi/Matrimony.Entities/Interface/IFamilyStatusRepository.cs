using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface IFamilyStatusRepository
    {
        List<FamilyStatus> GetFamilyStatus(string familystatus);

        Task<int> PostFamilyStatus(FamilyStatus familyStatus);

        int DeleteFamilyStatus(int familyStatusId);
    }
}
