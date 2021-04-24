using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Entities
{
    public class Caste
    {
        public int CasteId { get; set; }
        public string CasteName { get; set; }

        public DateTime CasteCreatedDate { get; set; }

        public int CasteCreatedBy { get; set; }

        public DateTime CasteModifiedDate { get; set; }

        public int CasteModifiedBy { get; set; }

        public int CasteStatus { get; set; }
    }
}
