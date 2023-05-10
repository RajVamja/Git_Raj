using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using studentRegistration.Models;

namespace studentRegistration.Controllers
{
    public class countriesController : Controller
    {
        db_RajVamjaEntities cs = new db_RajVamjaEntities();

        // GET: countries
        public ActionResult Index()
        {
            db_RajVamjaEntities cs = new db_RajVamjaEntities();
            ViewBag.CountryList = new SelectList(GetCountryList(), "cid", "cName");
            return View();
        }

        public List<Country> GetCountryList()
        {
            db_RajVamjaEntities cs = new db_RajVamjaEntities();
            List<Country> countries = cs.Countries.ToList();
            return countries;
        }

        public ActionResult GetStateList(int cid)
        {
            db_RajVamjaEntities cs = new db_RajVamjaEntities();
            List<State> selectList = cs.States.Where(a => a.cId == cid).ToList();
            @ViewBag.Slist = new SelectList(selectList, "sId", "sName");
            return PartialView("DisplayStates");
        }

        public ActionResult GetCityList(int sid)
        {
            db_RajVamjaEntities cs = new db_RajVamjaEntities();
            List<City> selectList = cs.Cities.Where(a => a.sId == sid).ToList();
            @ViewBag.Citylist = new SelectList(selectList, "cityId", "cityName");
            return PartialView("DisplayCities");
        }
    }
}