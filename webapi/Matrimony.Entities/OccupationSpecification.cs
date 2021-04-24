using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Entities
{
    public class OccupationSpecification
    {
        public int OccupationSpecificationId { get; set; }

        public int OccupationId { get; set; }
        public string OccupationSpecificationType { get; set; }        
        public DateTime OccupationSpecificationCreatedDate { get; set; }
        public int OccupationSpecificationCreatedBy { get; set; }
        public DateTime OccupationSpecificationModifiedDate { get; set; }
        public int OccupationSpecificationModifiedBy { get; set; }
        public int OccupationSpecificationStatus { get; set; }
    }
}
