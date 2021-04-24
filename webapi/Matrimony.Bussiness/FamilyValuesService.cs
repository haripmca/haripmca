using Matrimony.Entities;
using Matrimony.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class FamilyValuesService
    {
        readonly IFamilyValuesRepository familyValuesRepositoryobj;

        public FamilyValuesService(IFamilyValuesRepository familyValuesRepository)
        {
            familyValuesRepositoryobj = familyValuesRepository;
        }

        public List<FamilyValues> GetFamilyValues(string familyvalues)        
        {
            return familyValuesRepositoryobj.GetFamilyValues(familyvalues);
        }

        public Task<int> FamilyValues(FamilyValues familyValues)
        {
            return familyValuesRepositoryobj.PostFamilyValues(familyValues);
        }

        public int DeleteFamilyValues(int familyvaluesId)
        {
            return familyValuesRepositoryobj.DeleteFamilyValues(familyvaluesId);
        }
    }
}
