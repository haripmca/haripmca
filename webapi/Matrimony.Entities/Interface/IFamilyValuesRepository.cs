using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface IFamilyValuesRepository
    {
        List<FamilyValues> GetFamilyValues(string familyValues);

        Task<int> PostFamilyValues(FamilyValues familyValues);

        int DeleteFamilyValues(int familyvaluesId);
    }
}
