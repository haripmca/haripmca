using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Entities
{
    public class Height
    {
        public int HeightId { get; set; }
        public string HeightFeetorInches { get; set; }
        public DateTime HeightCreatedDate { get; set; }
        public int HeightCreatedBy { get; set; }
        public DateTime HeightModifiedDate { get; set; }
        public int HeightModifiedBy { get; set; }
        public int HeightStatus { get; set; }
    }
}
