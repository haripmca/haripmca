using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface IMaritalService
    {
        List<Marital> GetMaritals(string martialName);
        Task<int> PostMarital(Marital marital);
        int DeleteMarital(int maritalid);
    }
}
