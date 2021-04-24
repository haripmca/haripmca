using Matrimony.DataAccess;
using Matrimony.Entities;
using Matrimony.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class DisabilityService : IDisabilityRepository
    {
        readonly IDisabilityRepository disabilityRepositoryobj;

        public DisabilityService(IDisabilityRepository disabilityRepository)
        {
            disabilityRepositoryobj = disabilityRepository;
        }

        public List<Disability> GetDisability(string disabiltiesName)
        {
          return  disabilityRepositoryobj.GetDisability(disabiltiesName);
        }

        public Task<int> PostDisability(Disability disability)
        {
            return disabilityRepositoryobj.PostDisability(disability);
        }

        public int DeleteDisability(int anyDisabilityId)
        {
            return disabilityRepositoryobj.DeleteDisability(anyDisabilityId);
        }


    }
}
