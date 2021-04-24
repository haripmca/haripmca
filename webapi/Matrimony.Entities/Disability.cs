using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Entities
{
    public class Disability
    {
        public int AnyDisabilityId { get; set; }

        public bool AnyDisabilityOrNot { get; set; }

        public DateTime AnyDisabilityCreatedDate { get; set; }

        public int AnyDisabilityCreatedBy { get; set; }

        public DateTime AnyDisabilityModifiedDate { get; set; }

        public int AnyDisabilityModifiedBy { get; set; }

        public int AnyDisabilityStatus { get; set; }

    }
}
