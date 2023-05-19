using SchoolManagement_343.Models.Context;
using SchoolManagement_343.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_343.Repository.Services
{

    public class CityServices : Icity
    {
        RajVamja_schoolmanagement_343Entities cs = new RajVamja_schoolmanagement_343Entities();

        public void AddCity(City city)
        {
            try
            {
                var existingCity = cs.Cities.FirstOrDefault(c => c.cityName == city.cityName);
                if (existingCity == null)
                {
                    cs.Cities.Add(city);
                    cs.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<SP_cityList_Result3> CityList()
        {
            var citydata = cs.SP_cityList().ToList();
            return citydata;
        }

        public int DeleteCity(int? cityId)
        {
            try
            {
                var del = cs.sp_DeleteCity(cityId);
                cs.SaveChanges();
                return del;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public City editCity(int? cityId)
        {
            try
            {
                City c;
                c = cs.Cities.Find(cityId);
                return c;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public int editCity(City city)
        {
            try
            {
                cs.Entry(city).State = System.Data.Entity.EntityState.Modified;
                cs.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<City> GetCityList()
        {
            try
            {
                List<City> cities = cs.Cities.ToList();
                return cities;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
