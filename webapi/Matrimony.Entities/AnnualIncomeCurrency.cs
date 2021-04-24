using System;
using System.Collections.Generic;
using System.Text;

namespace Matrimony.Entities
{
    public class AnnualIncomeCurrency
    {
        public int AnnualIncomeCurrencyId { get; set; }

        public string AnnualIncomeCurrencyName { get; set; }

        public DateTime AnnualIncomeCreatedDate { get; set; }

        public int AnnualIncomeCreatedBy { get; set; }

        public DateTime AnnualIncomeModifiedDate { get; set; }

        public int AnnualIncomeModifiedBy { get; set; }

        public int AnnualIncomeStatus { get; set; }
    }
}
