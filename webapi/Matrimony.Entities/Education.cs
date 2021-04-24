using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Entities
{
    public class Education
    {
        public int EducationId { get; set; }

        public string EducationBranch { get; set; }

        public string EducationDegree { get; set; }

        public DateTime EducationCreatedDate { get; set; }

        public int EducationCreatedBy { get; set; }

        public DateTime EducationModifiedDate { get; set; }

        public int EducationModifiedBy { get; set; }

        public int EducationStatus { get; set; }
    }
}
