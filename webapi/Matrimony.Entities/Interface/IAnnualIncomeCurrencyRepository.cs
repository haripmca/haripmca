using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface IAnnualIncomeCurrencyRepository
    {
        List<AnnualIncomeCurrency> GetAnnualIncomeCurrencies(string annualIncomeCurrencyName);

        Task<int> PostAnnualIncomeCurrency(AnnualIncomeCurrency annualIncomeCurrency);

        int DeleteAnnualIncomeCurrency(int anyCasteId);
    }
}
