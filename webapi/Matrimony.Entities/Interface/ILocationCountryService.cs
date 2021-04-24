using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Entities.Interface
{
    public interface ILocationCountryService
    {
        List<LocationCountry> GetLocationCountries(string locationCountryName);

        Task<int> PostLocationCountry(LocationCountry locationCountry);

        int DeleteLocationCountry(int locationid);
    }
}
