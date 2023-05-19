using SchoolManagement_343.Models.Context;
using SchoolManagement_343.Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement_343.Repository.Services
{
    public class CountryServices : Icountry
    {
        RajVamja_schoolmanagement_343Entities cs = new RajVamja_schoolmanagement_343Entities();
        public IEnumerable<Country> GetCountryList()
        {
            try
            {
                List<Country> countries = cs.Countries.ToList();
                return countries;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void AddCountry(Country country)
        {
            try
            {
                var existingCountry = cs.Countries.FirstOrDefault(c => c.cName == country.cName);
                if (existingCountry == null)
                {
                    // country already exists, return an error or redirect to a different action
                    cs.Countries.Add(country);
                    cs.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Country Editcountry(int? cId)
        {
            try
            {
                Country c;
                c = cs.Countries.Find(cId);
                return c;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int Editcountry(Country co)
        {
            try
            {
                cs.Entry(co).State = System.Data.Entity.EntityState.Modified;
                cs.SaveChanges();
                return 1;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public int DeleteCountry(int? cId)
        {
            try
            {
                var delCountry = cs.sp_DeleteCountry(cId);
                cs.SaveChanges();
                return delCountry;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
