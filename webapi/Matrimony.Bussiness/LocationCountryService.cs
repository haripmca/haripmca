using Matrimony.Entities;
using Matrimony.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Matrimony.Bussiness
{
    public class LocationCountryService : ILocationCountryService
    {
        readonly ILocationCountryRepository locationCountryRepositoryobj;

        public LocationCountryService(ILocationCountryRepository locationCountryRepository)
        {
            locationCountryRepositoryobj = locationCountryRepository;
        }

        public List<LocationCountry> GetLocationCountries(string locationName)
        {
            return locationCountryRepositoryobj.GetLocationCountries(locationName);
        }

        public Task<int> PostLocationCountry(LocationCountry locationCountry)
        {
            return locationCountryRepositoryobj.PostLocationCountry(locationCountry);
        }

        public int DeleteLocationCountry(int locationId)
        {
            return locationCountryRepositoryobj.DeleteLocationCountry(locationId);
        }
    }
}
