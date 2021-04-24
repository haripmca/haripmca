using Matrimony.Entities;
using Matrimony.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class FamilyStatusService : IFamilyStatusRepository
    {
        readonly IFamilyStatusService familyStatusServiceobj;

        public FamilyStatusService(IFamilyStatusService familyStatusService)
        {
            familyStatusServiceobj = familyStatusService;
        }

        public List<FamilyStatus> GetFamilyStatus(string familystatus)
        {
            return familyStatusServiceobj.GetFamilyStatus(familystatus);
        }


        public Task<int> PostFamilyStatus(FamilyStatus familyStatus)
        {
            return familyStatusServiceobj.PostFamilyStatus(familyStatus);
        }

        public int DeleteFamilyStatus(int familyStatusId)
        {
            return familyStatusServiceobj.DeleteFamilyStatus(familyStatusId);
        }
    }
}
