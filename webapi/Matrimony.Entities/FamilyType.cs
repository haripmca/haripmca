using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Entities
{
    public class FamilyType
    {
        public int FamilyValuesId { get; set; }
        public string FamilyValuesName { get; set; }

        public DateTime FamilyValuesCreatedDate { get; set; }

        public int FamilyValuesCreatedBy { get; set; }

        public int FamilyValuesModifiedDate { get; set; }

        public int FamilyValuesModifiedBy { get; set; }

        public int FamilyValuesStatus { get; set; }
    }
}
