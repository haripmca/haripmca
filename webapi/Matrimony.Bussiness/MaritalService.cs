using Matrimony.Entities;
using Matrimony.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class MaritalService : IMaritalService
    {
        readonly IMaritalRepository maritalRepositoryobj;

        public MaritalService(IMaritalRepository maritalRepository)
        {
            maritalRepositoryobj = maritalRepository;
        }

        public List<Marital> GetMaritals(string maritalName)
        {
            return maritalRepositoryobj.GetMaritals(maritalName);
        }

        public Task<int> PostMarital(Marital marital)
        {
            return maritalRepositoryobj.PostMarital(marital);
        }

        public int DeleteMarital(int maritalId)
        {
            return maritalRepositoryobj.DeleteMarital(maritalId);
        }
    }
}
