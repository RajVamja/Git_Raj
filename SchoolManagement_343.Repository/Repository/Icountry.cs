using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement_343.Models.Context;


namespace SchoolManagement_343.Repository.Repository
{
    public interface Icountry
    {
        IEnumerable<Country> GetCountryList();

        void AddCountry(Country addC);

        Country Editcountry(int? cId);
        int Editcountry(Country editC);

        int DeleteCountry(int? cId);
    }
}
