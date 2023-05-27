using ApiProjrct.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApiProjrct.Controllers
{
    public class CountriesController : Controller
    {
        // GET: Countries
        RajVamja_webapiEntities cs = new RajVamja_webapiEntities();

        // GET: countries
        public ActionResult Index()
        {
            RajVamja_webapiEntities cs = new RajVamja_webapiEntities();;
            ViewBag.CountryList = new SelectList(GetCountryList(), "cid", "cName");
            return View();
        }

        public List<Country> GetCountryList()
        {
            RajVamja_webapiEntities cs = new RajVamja_webapiEntities();;
            List<Country> countries = cs.Countries.ToList();
            return countries;
        }

        public ActionResult GetStateList(int cid)
        {
            RajVamja_webapiEntities cs = new RajVamja_webapiEntities();;
            List<State> selectList = cs.States.Where(a => a.cId == cid).ToList();
            @ViewBag.Slist = new SelectList(selectList, "sId", "sName");
            return PartialView("DisplayStates");
        }

        public ActionResult GetCityList(int sid)
        {
            RajVamja_webapiEntities cs = new RajVamja_webapiEntities();;
            List<City> selectList = cs.Cities.Where(a => a.sId == sid).ToList();
            @ViewBag.Citylist = new SelectList(selectList, "cityId", "cityName");
            return PartialView("DisplayCities");
        }
    }
}