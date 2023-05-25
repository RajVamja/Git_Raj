using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiRepo_Models.Context;
using WebApiRepo_Repository.Repository;

namespace WebApiRepo_Repository.Service
{
    public class CountryService : ICountry
    {
        RajVamja_webapiEntities rv = new RajVamja_webapiEntities();
        public IEnumerable<Country> GetCountryList()
        {
            List<Country> countries = rv.Countries.ToList();
            return countries;
        }
    }
}
