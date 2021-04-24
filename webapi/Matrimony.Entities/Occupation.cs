using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Entities
{
    public class Occupation
    {
        public int OccupationId { get; set; }

        public string OccupationDepartment { get; set; }

        public DateTime OccupationCreatedDate { get; set; }

        public int OccupationCreatedBy { get; set; }

        public DateTime OccupationModifiedDate { get; set; }
        public int OccupationModifiedBy { get; set; }
        public int OccupationStatus { get; set; }
    }
}
