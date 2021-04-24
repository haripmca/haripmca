using Matrimony.Entities;
using Matrimony.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class AnnualIncomeCurrencyService : IAnnualIncomeCurrencyRepository
    {
        readonly IAnnualIncomeCurrencyRepository annualIncomeCurrencyRepositoryobj;

        public AnnualIncomeCurrencyService(IAnnualIncomeCurrencyRepository annualIncomeCurrencyRepository)
        {
            annualIncomeCurrencyRepositoryobj = annualIncomeCurrencyRepository;
        }

        public List<AnnualIncomeCurrency> GetAnnualIncomeCurrencies(string annualIncomeCurrencyName)
        {
            return annualIncomeCurrencyRepositoryobj.GetAnnualIncomeCurrencies(annualIncomeCurrencyName);
        }

        public Task<int> PostAnnualIncomeCurrency(AnnualIncomeCurrency annualIncomeCurrency)
        {
            return annualIncomeCurrencyRepositoryobj.PostAnnualIncomeCurrency(annualIncomeCurrency);
        }

        public int DeleteAnnualIncomeCurrency(int anyCasteId)
        {
            return annualIncomeCurrencyRepositoryobj.DeleteAnnualIncomeCurrency(anyCasteId);
        }
    }
}
