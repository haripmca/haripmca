using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface IOccupationSpecificationRepository
    {        
        List<OccupationSpecification> OccupationSpecificationServiceResults(string occupationSpecification);
        Task<int> PostOccupationSpec(OccupationSpecification occupationSpecificationInsertUpdate);
        int DeleteOccupationSpec(int occupationSpecificationId);
    }
}
