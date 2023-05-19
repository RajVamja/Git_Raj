using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement_343.Models.Context;

namespace SchoolManagement_343.Repository.Repository
{
    public interface Icity
    {
        IEnumerable<City> GetCityList();

        void AddCity(City addcity);

        IEnumerable<SP_cityList_Result3> CityList();

        City editCity(int? cityId);

        int editCity(City city);

        int DeleteCity(int? cityId);
    }
}
