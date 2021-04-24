using Matrimony.Entities;
using Matrimony.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class OccupationSpecificationService : IOccupationSpecificationRepository
    {
        readonly IOccupationSpecificationRepository occupationSpecificationRepositoryobj;

        public OccupationSpecificationService(IOccupationSpecificationRepository occupationSpecificationRepository)
        {
            occupationSpecificationRepositoryobj = occupationSpecificationRepository;
        }

        public async Task<int> PostOccupationSpec(OccupationSpecification occupationSpecification)
        {
            return await occupationSpecificationRepositoryobj.PostOccupationSpec(occupationSpecification);
        }

        public List<OccupationSpecification> OccupationSpecificationServiceResults(string occupationSpecification)
        {
            return  occupationSpecificationRepositoryobj.OccupationSpecificationServiceResults(occupationSpecification);
        }

        public int DeleteOccupationSpec(int occupationSpecificationId)
        {
            return occupationSpecificationRepositoryobj.DeleteOccupationSpec(occupationSpecificationId);
        }
    }
}
