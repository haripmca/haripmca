using Matrimony.Entities;
using Matrimony.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class FamilyTypeService : IFamilyTypeRepository
    {
        readonly IFamilyTypeService familyTypeServiceobj;

        public FamilyTypeService(IFamilyTypeService familyTypeRepository)
        {
            familyTypeServiceobj = familyTypeRepository;
        }

        public List<FamilyType> GetFamilyTypes(string familytype)
        {
            return familyTypeServiceobj.GetFamilyTypes(familytype);
        }

        public Task<int> PostFamilyType(FamilyType familyType)
        {
            return familyTypeServiceobj.PostFamilyType(familyType);
        }

        public int DeleteFamilyType(int familytypesId)
        {
            return familyTypeServiceobj.DeleteFamilyType(familytypesId);
        }
    }
}
