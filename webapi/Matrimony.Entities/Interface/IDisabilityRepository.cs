using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface IDisabilityRepository
    {
        List<Disability> GetDisability(string disabilityName);

        Task<int> PostDisability(Disability disability);

        int DeleteDisability(int anyDisabilityId);
    }
}
