using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Entities
{
    public class LocationCountry
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public DateTime LocationCreatedDate { get; set; }
        public int LocationCreatedBy { get; set; }

        public DateTime LocationModifiedDate { get; set; }
        public int LocationModifiedBy { get; set; }
        public int LocationStatus { get; set; }
    }
}
