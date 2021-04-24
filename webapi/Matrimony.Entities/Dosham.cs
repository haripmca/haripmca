using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Entities
{
    public class Dosham
    {
        public int DoshamId { get; set; }

        public string DoshamName { get; set; }

        public DateTime DoshamCreatedDate { get; set; }

        public int DoshamCreatedBy { get; set; }

        public DateTime DoshamModifiedDate { get; set; }

        public int DoshamModifiedBy { get; set; }
        public int DoshamStatus { get; set; }
    }
}
