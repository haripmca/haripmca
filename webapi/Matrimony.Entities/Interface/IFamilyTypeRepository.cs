using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface IFamilyTypeRepository
    {
        List<FamilyType> GetFamilyTypes(string familytype);

        Task<int> PostFamilyType(FamilyType familyType);

        int DeleteFamilyType(int familyTypeId);
    }
}
