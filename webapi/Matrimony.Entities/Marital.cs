using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Entities
{
    public class Marital
    {
        public int MaritalId { get; set; }

        public string MaritalName { get; set; }

        public DateTime MaritalCreatedDate { get; set; }

        public int MaritalCreatedBy { get; set; }

        public DateTime MaritalModifiedDate { get; set; }

        public int MaritalModifiedBy { get; set; }

        public int MaritalStatus { get; set; }
    }
}
