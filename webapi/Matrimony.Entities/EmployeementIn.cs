using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Entities
{
    public class EmployeementIn
    {
        public int EmployeementId { get; set; }

        public string EmployeementInName { get; set; }

        public DateTime EmployeementCreatedDate { get; set; }

        public int EmployeementCreatedBy { get; set; }

        public DateTime EmployeementModifiedDate { get; set; }

        public int EmployeementModifiedBy { get; set; }

        public int EmployeementStatus { get; set; }
    }
}
