using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Entities
{
    public class FamilyStatus
    {
        public int FamilyStatusId { get; set; }

        public string FamilyStatusName { get; set; }

        public DateTime FamilyStatusCreatedDate { get; set; }

        public int FamilyStatusCreatedBy { get; set; }

        public DateTime FamilyStatusModifiedDate { get; set; }

        public int FamilyStatusModifiedBy { get; set; }

        public int FamilyStatusStatus { get; set; }
    }
}
