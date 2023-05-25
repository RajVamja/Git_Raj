using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiRepo_Models.Context;
using WebApiRepo_Repository.Repository;

namespace WebApiRepo_Repository.Service
{
    public class CityService : ICity
    {
        RajVamja_webapiEntities rv = new RajVamja_webapiEntities();

        public IEnumerable<City> GetCityList()
        {
            List<City> cities = rv.Cities.ToList();
            return cities;
        }
    }
}
